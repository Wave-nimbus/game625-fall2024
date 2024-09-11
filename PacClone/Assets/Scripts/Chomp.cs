using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Chomp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    CharacterController charControl;
    [SerializeField]
    private float speed;

    private bool powered;
    void Start()
    {
        speed = 5;
        powered = false;
    }

    // Update is called once per frame
    void Update()
    {
        charControl.Move(transform.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeDir(0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changeDir(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeDir(2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            changeDir(3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherTag = collision.gameObject.tag;

        if (otherTag == "PacDot")
        {
            Destroy(collision.gameObject);
            GameController.GC.IncreaseScore(10);
        }
        else if (otherTag == "PowerPellet")
        {
            Destroy(collision.gameObject);
            GameController.GC.FreezeGhosts();
            powered = true;
            Invoke("Depower", 5);
            GameController.GC.IncreaseScore(50);
        }
        else if (otherTag == "Ghost")
        {
            if(powered)
            {
                collision.gameObject.GetComponent<Ghost>().Respawn();
                GameController.GC.IncreaseScore(400);
            }
            else
            {
                speed = 0;
                GameController.GC.EndGame();
            }
        }
    }

    private void changeDir(int dir)
    {
        switch (dir)
        {
            case 0: //Up
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1: //Right
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 2: //Down
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
            default:
                break;
        }
    }

    private void Depower()
    {
        powered = false;
    }
}
