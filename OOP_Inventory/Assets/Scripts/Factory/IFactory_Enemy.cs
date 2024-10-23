using UnityEngine;

public interface IFactory_Enemy
{
    Enemy CreateEnemy(Vector3 spawnpoint);
}
