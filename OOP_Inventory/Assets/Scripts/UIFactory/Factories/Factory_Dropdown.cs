using System.Collections.Generic;
using UnityEngine;

public class Factory_Dropdown : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject dropdown;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newDropdown = Instantiate(dropdown, parent);
        return newDropdown.GetComponent<DropdownMenu>();
    }
}
