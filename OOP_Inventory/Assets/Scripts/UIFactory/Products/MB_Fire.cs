using TMPro;
using UnityEngine;

public class MB_Fire: MiddleButton
{
    int numShots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildMyself();
        
    }

    protected override void OnClick()
    {
        UIFac_GameControl.GC.FireShots(numShots);
        UIFactorySingleton.UIFac.ClearTopLevel();
    }

    public void SetShots(int num)
    {
        numShots = num;
        buttonName = "Fire " + num;
    }

}
