using UnityEngine;

public class DZPlayer : MonoBehaviour
{
    [SerializeField]
    protected CharacterController charCont;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float gravity;

    protected Vector3 moveDir;
    protected Vector3 lastPos;

    private Manager_Time_Rewind manTimeRewind;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5.5f;
        gravity = 10;
        moveDir = Vector3.zero;
        manTimeRewind = FindFirstObjectByType<Manager_Time_Rewind>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manTimeRewind.GetIsRewinding())
        {
            moveDir = Vector3.zero;
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moveDir += (transform.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moveDir += (-transform.forward);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveDir += (-transform.right);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveDir += (transform.right);
            }

            moveDir = moveDir.normalized * speed;
            //moveDir += Vector3.down * gravity;
            moveDir *= Time.deltaTime;
            transform.position += moveDir;
            Command_Move moveRecord = new Command_Move(transform, transform.position - lastPos);
            moveRecord.Execute();
            manTimeRewind.RecordCommand(moveRecord);
            lastPos = transform.position;

            //charCont.Move(moveDir);
            //charCont.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit a Trigger");
        if(other.gameObject.CompareTag("DangerZone"))
        {
            Debug.Log(other.gameObject.GetComponent<Zone_Base>().currSafe);
            if(!other.gameObject.GetComponent<Zone_Base>().currSafe)
            {
                Debug.Log("Touched Lava");
                //Die();
            }
        } 
    }

    private void Die()
    {
        transform.position = Vector3.zero;
    }
}
