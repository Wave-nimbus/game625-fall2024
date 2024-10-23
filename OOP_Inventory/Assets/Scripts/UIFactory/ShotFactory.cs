using UnityEngine;

public class ShotFactory : MonoBehaviour
{

    [SerializeField]
    protected GameObject shot;

    protected void FireShot()
    {
        Instantiate(shot, transform);
    }
}
