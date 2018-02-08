using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelShaft : MonoBehaviour
{

    private Shaft parentShaft;
	private TextMesh levelText;
    void Start()
    {
		parentShaft = GetComponentInParent<Shaft>();
		levelText = GetComponentInChildren<TextMesh>();
    }

    void OnMouseDown()
    {
		parentShaft.LevelUp();
		levelText.text = parentShaft.Level.ToString();
    }
}
