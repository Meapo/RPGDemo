using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform Target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            moveToPoint(Target.position);
            FaceTarget(Target);
        }
    }
    public void moveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowingTarget(Interactable newtarget)
    {
        agent.stoppingDistance = newtarget.radius * .8f;
        agent.updateRotation = false;
        Target = newtarget.interactableTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        Target = null;
    }

    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion LookAtRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAtRotation, Time.deltaTime * 5f);
    }
}
