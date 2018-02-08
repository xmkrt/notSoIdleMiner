using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNewShaft : MonoBehaviour {
	void OnMouseDown () {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddShaft();
	}
}