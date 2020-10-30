using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public  LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.moveToPoint(hit.point);
                StopFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                    
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (focus != newFocus)
        {
            if (focus != null)
            {
                focus.OnDefocus();
            }
            focus = newFocus;
        }

        focus.OnFocus(transform);
        motor.FollowingTarget(focus);
    }

    void StopFocus()
    {
        if (focus != null)
        {
            focus.OnDefocus();
        }
        focus = null;
        motor.StopFollowingTarget();
    }

}
