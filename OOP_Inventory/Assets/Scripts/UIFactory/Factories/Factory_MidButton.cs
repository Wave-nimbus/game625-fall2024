using System.Collections.Generic;
using UnityEngine;

public class Factory_MidButton : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject midButton;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newMidButton = Instantiate(midButton, parent);
        return newMidButton.GetComponent<MiddleButton>();
    }
}
