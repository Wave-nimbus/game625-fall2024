using UnityEngine;

public class Factory_Orc : MonoBehaviour, IFactory_Enemy
{
    [SerializeField]
    GameObject orcPrefab;
    public Enemy CreateEnemy(Vector3 spawnpoint)
    {
        GameObject orc = GameObject.Instantiate(orcPrefab, spawnpoint, Quaternion.identity);
        return orc.GetComponent<Enemy>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            CreateEnemy(transform.position + transform.right * 2);
        }
    }
}
