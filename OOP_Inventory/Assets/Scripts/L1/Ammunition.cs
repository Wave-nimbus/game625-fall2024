using System;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    public event Action<AmmoType> PickUp;

    protected AmmoType myType;

    protected abstract void OnCollisionEnter(Collision collision);

    protected virtual void onPickUp()
    {
        PickUp?.Invoke(myType);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }
    
    public virtual void LaunchMe(Vector3 forward, Vector3 starting)
    {
        transform.position = starting;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce((forward + Vector3.up) * 500);
    }
 }   
public enum AmmoType
{
    light,
    medium,
    heavy
};

    
