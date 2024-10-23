using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DropdownMenu : IProduct_UI
{
    [SerializeField]
    RectTransform rectTrans;

    Vector2 currSize = new Vector2(100, 0);
    int verticalPadding = 2;

    private void Start()
    {
        BuildMyself();
    }

    public override void AddToSelf(IProduct_UI thingToAdd)
    {
        RectTransform tempRect = thingToAdd.GetComponent<RectTransform>();
        currSize.y += tempRect.sizeDelta.y + verticalPadding;
        rectTrans.sizeDelta = currSize;
    }

    protected override void BuildMyself()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.sizeDelta = currSize;
    }
}
