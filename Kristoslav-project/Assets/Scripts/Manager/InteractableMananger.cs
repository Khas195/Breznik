using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMananger : SingletonMonobehavior<InteractableMananger>
{
    List<IInteractable> inRangeList = new List<IInteractable>();
    [SerializeField]
    Text interactCue = null;

    IInteractable highlightInteractable = null;

    public void OnInteractableEnter(IInteractable enteredInteractable)
    {
        Logger.InventoryDebug("Item in range: " + enteredInteractable);
        inRangeList.Add(enteredInteractable);
        enteredInteractable.Focus(this.gameObject);
        HighlightInteractable(enteredInteractable);
    }
    public void OnInteractableExit(IInteractable exitedInteractable)
    {
        Logger.InventoryDebug("Interactable out of range: " + exitedInteractable);
        if (inRangeList.Contains(exitedInteractable))
        {
            inRangeList.Remove(exitedInteractable);
            exitedInteractable.Defocus(this.gameObject);
        }
    }
    void HighlightInteractable(IInteractable interact)
    {
        interactCue.gameObject.SetActive(true);
        interactCue.text = "E - " + interact.GetKindOfInteraction() + " " + interact.GetName();
        highlightInteractable = interact;
    }
    void TurnOffHightlight()
    {
        interactCue.gameObject.SetActive(false);
        highlightInteractable = null;
    }
    void Update()
    {
        if (inRangeList.Count <= 0)
        {
            TurnOffHightlight();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (highlightInteractable)
            {
                highlightInteractable.Interact(this.gameObject);
                inRangeList.Remove(highlightInteractable);
                highlightInteractable = null;
            }
            if (inRangeList.Count > 0)
            {
                var lastIndex = inRangeList.Count - 1;
                lastIndex = lastIndex < 0 ? 0 : lastIndex;
                inRangeList[lastIndex].Focus(this.gameObject);
                HighlightInteractable(inRangeList[lastIndex]);
            }
        }
    }
}
