using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelWareHouse : MonoBehaviour {

    private WareHouse wareHouse;
	private TextMesh levelText;
    void Start()
    {
		wareHouse = GetComponentInParent<WareHouse>();
		levelText = GetComponentInChildren<TextMesh>();
    }

    void OnMouseDown()
    {
		wareHouse.LevelUp();
		levelText.text = wareHouse.Level.ToString();
    }
}
