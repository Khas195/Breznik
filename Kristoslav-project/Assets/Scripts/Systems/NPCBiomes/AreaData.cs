using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct InhabitantRatio
{
    public GameObject inhabitant;
    [Range(0, 1)]
    public float ratio;
}
[CreateAssetMenu(fileName = "AreaData", menuName = "Data/Area", order = 1)]
public class AreaData : ScriptableObject
{
    public string areaName;
    public List<InhabitantRatio> typeOfInhabitants = new List<InhabitantRatio>();
    public int maxPopulation;
    public int size;

}
