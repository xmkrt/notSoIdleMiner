// just displays cummulated cash on UI
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour
{
    private WareHouse wareHouse;
    
    private Text cashText;

    void Start()
    {
        wareHouse = GameObject.FindGameObjectWithTag("WareHouse").GetComponent<WareHouse>();
        cashText = GetComponent<Text>();
    }

    void Update()
    {
        cashText.text = (Mathf.Round(wareHouse.Cash)).ToString();
    }
}
