using UnityEngine;
using UnityEngine.AI;

public class Enemy_Skeleton : Enemy
{
    protected override void Start()
    {
        walkSpeed = 4.5f;
        base.Start();
    }  
}
