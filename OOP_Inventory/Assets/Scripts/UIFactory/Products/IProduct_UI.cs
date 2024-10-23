using UnityEngine;

public abstract class IProduct_UI : MonoBehaviour
{
    protected abstract void BuildMyself();

    public abstract void AddToSelf(IProduct_UI thingToAdd);
}
