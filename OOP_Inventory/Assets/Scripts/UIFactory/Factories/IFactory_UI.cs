using UnityEngine;

public interface IFactory_UI
{
    public IProduct_UI BuildProduct(Transform parent);
}
