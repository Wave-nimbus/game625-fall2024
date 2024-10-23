using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopButton : IProduct_UI
{
    [SerializeField]
    protected string buttonName;
    [SerializeField]
    protected TMP_Text buttonText;

    protected Button UIButton;

    private void Start()
    {
        BuildMyself();
    }


    public override void AddToSelf(IProduct_UI thingToAdd)
    {
        RectTransform tempRect = thingToAdd.GetComponent<RectTransform>();
        Vector2 spawnPos = new Vector2(0, -tempRect.sizeDelta.y);
        tempRect.anchoredPosition = spawnPos;

    }

    public void DestroyChildren()
    {
        IProduct_UI[] UIChildren = GetComponentsInChildren<IProduct_UI>();
        foreach (IProduct_UI ui in UIChildren)
        {
            if(ui == this)
            {
                continue;
            }
            Destroy(ui.gameObject);
        }
    }

    protected override void BuildMyself()
    {
        buttonText.text = buttonName;
        UIButton = GetComponent<Button>();
        UIButton.onClick.AddListener(OnClick);
    }


    protected virtual void OnClick()
    {
        Debug.Log("Clicked on Button " + name);
    }


    
}
