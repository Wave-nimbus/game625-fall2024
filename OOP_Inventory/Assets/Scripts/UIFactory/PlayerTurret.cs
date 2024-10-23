using System.Collections;
using UnityEngine;

public class PlayerTurret : ShotFactory
{
    private IEnumerator multiShot(int shots)
    {
        int shotsLeft = shots;
        while(shotsLeft > 0)
        {
            Debug.Log("Fired a shot");
            FireShot();
            shotsLeft--;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void StartMultishot(int shots)
    {
        Debug.Log("Begin Fireing Sequence");
        StartCoroutine(multiShot(shots));
    }
}
