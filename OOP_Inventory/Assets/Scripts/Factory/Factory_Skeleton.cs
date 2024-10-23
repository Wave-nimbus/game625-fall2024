using UnityEngine;

public class Factory_Skeleton : MonoBehaviour, IFactory_Enemy
{

    [SerializeField]
    GameObject skeletonPrefab;
    public Enemy CreateEnemy(Vector3 spawnpoint)
    {
        GameObject skelly = GameObject.Instantiate(skeletonPrefab, spawnpoint, Quaternion.identity);
        return skelly.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateEnemy(transform.position - transform.right * 2);
        }
    }
}
