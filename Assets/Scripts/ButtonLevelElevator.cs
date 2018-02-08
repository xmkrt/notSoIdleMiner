using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelElevator : MonoBehaviour
{

    private ElevatorHouse elevatorHouse;
	private TextMesh levelText;
    void Start()
    {
		elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
		levelText = GetComponentInChildren<TextMesh>();
    }

    void OnMouseDown()
    {
		elevatorHouse.LevelUp();
		levelText.text = elevatorHouse.Level.ToString();
    }
}