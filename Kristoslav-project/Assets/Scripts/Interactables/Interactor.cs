using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    [Required]
    GameObject host = null;
    [SerializeField]
    float range = 10f;
    [SerializeField]
    Color gizmoColor = Color.white;
    [SerializeField]
    LayerMask interactableMask;
    [SerializeField]
    Text interactPromp;

    IInteractable focusInteractable;

    private void OnDrawGizmos()
    {
        if (host != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(host.transform.position, range);
        }

    }

    void FixedUpdate()
    {
        DetectInteractable();
    }

    private void DetectInteractable()
    {
        var cols = Physics.OverlapSphere(host.transform.position, range, interactableMask);
        if (cols.Length > 0)
        {
            var interactable = cols[0].GetComponent<IInteractable>();
            if (interactable)
            {
                interactPromp.gameObject.SetActive(true);
                interactPromp.text = "E - " + interactable.GetKindOfInteraction();
                if (focusInteractable)
                {
                    if (focusInteractable != interactable)
                    {
                        focusInteractable.Defocus(host);
                    }
                }
                else
                {
                    focusInteractable = interactable;
                    focusInteractable.Focus(host);
                }
            }
        }
        else
        {
            interactPromp.gameObject.SetActive(false);
            if (focusInteractable)
            {
                focusInteractable.Defocus(host);
                focusInteractable = null;
            }
        }
    }

    void Update()
    {
        if (GameMaster.GetInstance().IsGamePaused() == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (focusInteractable)
                {
                    focusInteractable.Interact(host);
                }
                focusInteractable = null;
            }
        }
    }
}
