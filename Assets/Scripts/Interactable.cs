using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Transform interactableTransform;

    bool isFocus = false;

    bool hasInteract = false;

    Transform player;
    private void OnDrawGizmosSelected()
    {
        if (interactableTransform == null)
        {
            interactableTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position, radius);
    }

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        // Debug.Log("Interact with " + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteract)
        {
            float distance = Vector3.Distance(player.position, interactableTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteract = true;
            }
        }
    }

    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        hasInteract = false;
        player = playerTransform;
    }

    public void OnDefocus()
    {
        isFocus = false;
        hasInteract = false;
        player = null;
    }
}
