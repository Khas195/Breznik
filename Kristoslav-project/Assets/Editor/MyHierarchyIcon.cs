using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using NaughtyAttributes;

[InitializeOnLoad]
public class MyHierarchyIcon
{
    static Texture2D texture;
    static List<int> markedObjects;

    static MyHierarchyIcon()
    {
        // Init
        texture = AssetDatabase.LoadAssetAtPath("Assets/Editor/Testicon.png", typeof(Texture2D)) as Texture2D;
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
        markedObjects = new List<int>();
    }


    static void HierarchyItemCB(int instanceID, Rect selectionRect)
    {
        var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (go)
        {
            var components = go.GetComponents<Component>();
            if (components.Length> 0)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    FieldInfo[] fields = GetAllSerializedField(components, i);

                    bool componentHasAllRef = true;

                    for (int j = 0; j < fields.Length; j++)
                    {
                        if (fields[j].GetValue(components[i]) == null)
                        {
                            componentHasAllRef = false;
                        }
                    }
                    if (componentHasAllRef == false)
                    {
                        DrawIcon(selectionRect);
                    }
                }
            }

        }
    }

    private static FieldInfo[] GetAllSerializedField(Component[] components, int i)
    {
        return components[i].GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
        .Where(f => f.GetCustomAttribute<RequiredAttribute>() != null).ToArray();
    }

    private static void DrawIcon(Rect selectionRect)
    {
        // place the icoon to the right of the list:
        Rect r = new Rect(selectionRect);
        r.width = 20;
        r.x = r.width - 20;
        GUI.Label(r, texture);
    }
}
