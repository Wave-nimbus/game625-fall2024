using System.Collections.Generic;
using UnityEngine;

public class Factory_TBLane : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject TBLane;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newTopButton = Instantiate(TBLane, parent);
        return newTopButton.GetComponent<TB_Lane>();
    }
}
