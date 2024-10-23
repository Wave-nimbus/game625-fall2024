using UnityEngine;

public class UIFactorySingleton : MonoBehaviour
{
    public Factory_Dropdown facDrop;

    public Factory_TopButton facTopButton;
        public Factory_TBLane facTBLane;

    public Factory_MidButton facMidButton;
        public Factory_MBDropdown facMBDropdown;
        public Factory_MBFire facMBFire;

    public static UIFactorySingleton UIFac;

    private void Awake()
    {
        if(UIFac == null)
        {
            UIFac = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ClearTopLevel();
            UIFac_GameControl.GC.currLane = -1;
        }
    }

    public void ClearTopLevel()
    {
        TopButton[] menuBtns = FindObjectsByType<TopButton>(FindObjectsSortMode.None);
        foreach (TopButton btn in menuBtns)
        {
            btn.DestroyChildren();
        }
    }
}
