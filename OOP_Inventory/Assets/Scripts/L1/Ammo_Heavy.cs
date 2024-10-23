using UnityEngine;
using System;
using Unity.VisualScripting;

public class Ammo_Heavy : Ammunition
{

    private void Start()
    {
        myType = AmmoType.heavy;
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
