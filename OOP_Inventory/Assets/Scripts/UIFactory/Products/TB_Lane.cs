using TMPro;
using UnityEngine;

public class TB_Lane : TopButton
{
    int myLane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildMyself();
    }

    protected override void OnClick()
    {
        UIFac_GameControl.GC.currLane = myLane;

        DropdownMenu drop = (DropdownMenu)UIFactorySingleton.UIFac.facDrop.BuildProduct(transform);
        AddToSelf(drop);

        int randNum = Random.Range(1, 5);
        for (int i = 1; i < randNum; i++)
        {
            MB_Fire midB = (MB_Fire)UIFactorySingleton.UIFac.facMBFire.BuildProduct(drop.transform);
            midB.SetShots(i);
            drop.AddToSelf(midB);
        }

        MB_Dropdown midDrop = (MB_Dropdown)UIFactorySingleton.UIFac.facMBDropdown.BuildProduct(drop.transform);
        drop.AddToSelf(midDrop);
    }

    public void SetMyLane(int lane)
    {
        myLane = lane;
    }

}
