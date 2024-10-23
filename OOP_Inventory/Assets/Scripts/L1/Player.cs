using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    CharacterController charCont;
    [SerializeField]
    float speed;

    Vector3 moveDir;
    [SerializeField]
    private float mouseSens = 200f;
    private float mouseX;

    public event Action<int> Launch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5;
        moveDir = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        moveDir = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveDir += transform.forward;
        }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveDir -= transform.forward;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveDir -= transform.right;
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            moveDir += transform.right;
        }
        moveDir.Normalize();
        moveDir *= speed;
        charCont.Move(moveDir * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Launch?.Invoke(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Launch?.Invoke(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Launch?.Invoke(3);
        }

    }
}
