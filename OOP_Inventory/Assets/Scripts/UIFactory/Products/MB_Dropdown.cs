using TMPro;
using UnityEngine;

public class MB_Dropdown: MiddleButton
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonName = "Roll Again?";
        BuildMyself();
    }

    protected override void OnClick()
    {
        DropdownMenu drop = (DropdownMenu)UIFactorySingleton.UIFac.facDrop.BuildProduct(transform);
        AddToSelf(drop);

        int randNum = Random.Range(0, 5);
        for (int i = 0; i < randNum; i++)
        {
            MB_Fire midB = (MB_Fire)UIFactorySingleton.UIFac.facMBFire.BuildProduct(drop.transform);
            midB.SetShots(i);
            drop.AddToSelf(midB);
        }

        MB_Dropdown midDrop = (MB_Dropdown)UIFactorySingleton.UIFac.facMBDropdown.BuildProduct(drop.transform);
        drop.AddToSelf(midDrop);
    }

}
