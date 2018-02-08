using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour
{
    private GameController gameController;
    private Text cashText;
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        cashText = GetComponent<Text>();
    }

    void Update()
    {
        cashText.text = (Mathf.Round(gameController.Cash)).ToString();
    }
}
