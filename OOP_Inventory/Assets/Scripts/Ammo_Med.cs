using UnityEngine;
using System;
using Unity.VisualScripting;

public class Ammo_Med : Ammunition
{

    private void Start()
    {
        myType = AmmoType.medium;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            onPickUp();
        }
    }

    protected override void onPickUp()
    {
        base.onPickUp();
        gameObject.SetActive(false);
    }
}
