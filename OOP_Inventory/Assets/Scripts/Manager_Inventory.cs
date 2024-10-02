using System;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Inventory : MonoBehaviour
{

    [SerializeField]
    List<Ammunition> ammoList = new List<Ammunition>();
    [SerializeField]
    Player thisPlayer;
    [SerializeField]
    AudioSource playerAudio;
    [SerializeField]
    AudioClip pickupSound1, pickupSound2, pickupSound3;

    int lightAmmo, medAmmo, heavyAmmo;

    public event Action<int, int, int> InvChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightAmmo = 0;
        medAmmo = 0;
        heavyAmmo = 0;

        foreach(Ammunition ammo in ammoList)
        {
            ammo.PickUp += OnPickup;
        }
        thisPlayer.Launch += OnLaunch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnPickup(AmmoType thisType)
    {
        switch (thisType)
        {
            case AmmoType.light:
                playerAudio.resource = pickupSound1;
                playerAudio.Play();
                lightAmmo++;
                break;
            case AmmoType.medium:
                playerAudio.resource = pickupSound2;
                playerAudio.Play();
                medAmmo++;
                break;
            case AmmoType.heavy:
                playerAudio.resource = pickupSound3;
                playerAudio.Play();
                heavyAmmo++;
                break;
            default: break;
        }
        InvChange?.Invoke(lightAmmo, medAmmo, heavyAmmo);

        //Debug.Log("lightAmmo Count: " + lightAmmo + "\tmedAmmo Count: " + medAmmo + "\theavyAmmo Count: " + heavyAmmo);
    }

    protected void OnLaunch(int type)
    {
        //Debug.Log("Launching type " + type);
        switch (type)
        {
            case 1:
                if (lightAmmo > 0)
                {
                    lightAmmo--;
                    ammoList[0].gameObject.SetActive(true);
                    ammoList[0].LaunchMe(thisPlayer.transform.forward, thisPlayer.transform.position + thisPlayer.transform.forward * 2);
                }
                break;
            case 2:
                if (medAmmo > 0)
                {
                    medAmmo--;
                    ammoList[1].gameObject.SetActive(true);
                    ammoList[1].LaunchMe(thisPlayer.transform.forward, thisPlayer.transform.position + thisPlayer.transform.forward * 2);
                }
                break;
            case 3:
                if (heavyAmmo > 0)
                {
                    heavyAmmo--;
                    ammoList[2].gameObject.SetActive(true);
                    ammoList[2].LaunchMe(thisPlayer.transform.forward, thisPlayer.transform.position + thisPlayer.transform.forward * 2);
                }
                break;
            default:
                break;    
        }

        InvChange?.Invoke(lightAmmo, medAmmo, heavyAmmo);
    }
}
