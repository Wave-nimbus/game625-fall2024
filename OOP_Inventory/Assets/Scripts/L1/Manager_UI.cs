using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    TMP_Text quantityLA, quantityMA, quantityHA;
    [SerializeField]
    Manager_Inventory inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory.InvChange += UpdateHotBar;
    }

    void UpdateHotBar(int light, int medium, int heavy)
    {
        quantityLA.text = light.ToString();
        quantityMA.text = medium.ToString();
        quantityHA.text = heavy.ToString();
    }
}
