using System.Collections.Generic;
using UnityEngine;

public class Factory_MBFire : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject mbFire;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newMidButton = Instantiate(mbFire, parent);
        return newMidButton.GetComponent<MB_Fire>();
    }
}
