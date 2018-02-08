using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashText : MonoBehaviour {

	private GameController myGameController;
	private Text cashText;
	void Start () {
		myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		cashText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		cashText.text = (Mathf.Round(myGameController.Cash)).ToString();
	}
}
