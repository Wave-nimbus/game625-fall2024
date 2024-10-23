using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.AI.Navigation;

public class Manager_Zone : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface NMGround;

    List<Zone_Interface> allZones = new List<Zone_Interface>();
    public event Action Warning;
    public event Action Switch;

    [SerializeField]
    float switchTimer;
    float countDownRate;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switchTimer = 7f;
        countDownRate = 1;
        NMGround.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        switchTimer -= countDownRate * Time.deltaTime;
        if(switchTimer <= 0)
        {
            Switch?.Invoke();
            switchTimer = 7f;
            
        }
        else if(switchTimer < 3f)
        {
            Warning?.Invoke();
        }
    }

    private void LateUpdate()
    {
        if (switchTimer > 6.5)
        {
            NMGround.BuildNavMesh();
        }

    }
}
