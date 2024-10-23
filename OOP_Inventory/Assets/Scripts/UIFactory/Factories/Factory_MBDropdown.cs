using System.Collections.Generic;
using UnityEngine;

public class Factory_MBDropdown : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject mbDropdown;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newMidButton = Instantiate(mbDropdown, parent);
        return newMidButton.GetComponent<MB_Dropdown>();
    }
}
