using System.Collections.Generic;
using UnityEngine;

public class Factory_TopButton : MonoBehaviour, IFactory_UI
{
    [SerializeField]
    GameObject topButton;
    public IProduct_UI BuildProduct(Transform parent)
    {
        GameObject newTopButton = Instantiate(topButton, parent);
        return newTopButton.GetComponent<TopButton>();
    }
}
