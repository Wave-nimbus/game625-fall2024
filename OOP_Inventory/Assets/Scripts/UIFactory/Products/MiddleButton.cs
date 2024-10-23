using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiddleButton : IProduct_UI
{
    [SerializeField]
    protected string buttonName;
    [SerializeField]
    TMP_Text buttonText;

    Button UIButton;

    private void Start()
    {
        BuildMyself();
    }


    public override void AddToSelf(IProduct_UI thingToAdd)
    {
        RectTransform tempRect = thingToAdd.GetComponent<RectTransform>();
        Vector2 spawnPos = new Vector2(tempRect.sizeDelta.x, 0);
        tempRect.anchoredPosition = spawnPos;
    }

    protected override void BuildMyself()
    {
        buttonText.text = buttonName;
        UIButton = GetComponent<Button>();
        UIButton.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        UIFactorySingleton.UIFac.ClearTopLevel();
        Debug.Log("Clicked on Button " + name);
    }


    
}
