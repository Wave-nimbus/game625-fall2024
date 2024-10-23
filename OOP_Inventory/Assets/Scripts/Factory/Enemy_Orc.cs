using UnityEngine;
using UnityEngine.AI;

public class Enemy_Orc : Enemy
{
    protected override void Start()
    {
        walkSpeed = 3;
        base.Start();
    }

}
