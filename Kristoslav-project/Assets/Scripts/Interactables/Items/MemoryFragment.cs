using UnityEngine;

public class MemoryFragment : IInteractable
{
    public override void Defocus(GameObject interacter)
    {
        base.Defocus(interacter);
    }

    public override void Focus(GameObject interacter)
    {
        base.Focus(interacter);
    }

    public override string GetKindOfInteraction()
    {
        return "Remember";
    }

    public override bool Interact(GameObject interacter)
    {
        if (base.Interact(interacter) == false) return false;

        Debug.Log("Interact with memory");
        this.gameObject.SetActive(false);
        return true;
    }

}
