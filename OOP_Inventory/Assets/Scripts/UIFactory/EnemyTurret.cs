using UnityEngine;

public class EnemyTurret : ShotFactory
{
    [SerializeField]
    float shotTimer, startTimer;

    private void Update()
    {
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0)
        {
            FireShot();
            shotTimer = startTimer;
        }
    }
}
