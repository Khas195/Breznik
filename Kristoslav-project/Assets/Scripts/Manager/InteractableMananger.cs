using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableMananger : SingletonMonobehavior<InteractableMananger>
{
    [SerializeField]
    GameObject host = null;
    List<IInteractable> inRangeList = new List<IInteractable>();
    [SerializeField]
    Text interactCue = null;

    IInteractable highlightInteractable = null;

    public void OnInteractableEnter(Collider other)
    {
        var enteredInteractable = other.GetComponentInChildren<IInteractable>();

        if (enteredInteractable)
        {
            Logger.InventoryDebug("Interactable in range: " + enteredInteractable);
            inRangeList.Add(enteredInteractable);
            enteredInteractable.Focus(this.gameObject);
            HighlightInteractable(enteredInteractable);
        }
    }
    public void OnInteractableExit(Collider other)
    {
        var exitedInteractable = other.GetComponentInChildren<IInteractable>();
        if (exitedInteractable)
        {
            Logger.InventoryDebug("Interactable out of range: " + exitedInteractable);
            if (inRangeList.Contains(exitedInteractable))
            {
                inRangeList.Remove(exitedInteractable);
                exitedInteractable.Defocus(this.gameObject);
            }
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
            TryToInteract();
        }
    }

    private void TryToInteract()
    {
        if (highlightInteractable)
        {
            highlightInteractable.Interact(host);
            inRangeList.Remove(highlightInteractable);
            highlightInteractable = null;
        }
        if (inRangeList.Count > 0)
        {
            var lastIndex = inRangeList.Count - 1;
            lastIndex = lastIndex < 0 ? 0 : lastIndex;
            inRangeList[lastIndex].Focus(host);
            HighlightInteractable(inRangeList[lastIndex]);
        }
    }
}
