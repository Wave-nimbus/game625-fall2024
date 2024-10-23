using Unity.VisualScripting;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    float travelSpeed;
    
    Vector3 trajectory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trajectory = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += trajectory * travelSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyShot"))
        {
            Destroy(gameObject);
        }
    }
}
