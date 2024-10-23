using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected NavMeshAgent pathfinding;
    protected Transform target;
    protected float walkSpeed;

    protected Manager_Time_Rewind manTimeRewind;
    protected Vector3 lastPos;

    protected virtual void Start()
    {
        pathfinding = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        pathfinding.speed = walkSpeed;

        manTimeRewind = FindFirstObjectByType<Manager_Time_Rewind>();
        lastPos = transform.position;
    }

    protected void Update()
    {
        if (!manTimeRewind.GetIsRewinding())
        {
            pathfinding.SetDestination(target.position);

            Command_Move commMove = new Command_Move(transform, transform.position - lastPos);
            commMove.Execute();
            manTimeRewind.RecordCommand(commMove);
            lastPos = transform.position;
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + " caught the Player");
        }
    }

}
