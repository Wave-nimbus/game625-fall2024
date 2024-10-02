using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    NavMeshAgent pathfinding;
    [SerializeField]
    SkinnedMeshRenderer rend;
    [SerializeField]
    Material normalGhost;
    [SerializeField]
    Material frozenGhost;

    bool frozen;
    void Start()
    {
        frozen = false;
        pathfinding = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfinding.isStopped = frozen;
        pathfinding.destination = GameController.GC.GetPacPos();
        
    }

    public void FreezeControl(bool freeze)
    {
        frozen = freeze;
        if(frozen)
        {
            rend.material = frozenGhost;
        }
        else
        {
            rend.material = normalGhost;
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = new Vector3(1.5f, 0f, 0f);
    }
}
