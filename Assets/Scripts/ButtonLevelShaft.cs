
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLevelShaft : MonoBehaviour, IPointerClickHandler
{

    private Shaft parentShaft;
    private TextMesh levelText;
    void Start()
    {
        parentShaft = GetComponentInParent<Shaft>();
        levelText = GetComponentInChildren<TextMesh>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        parentShaft.LevelUp();
        levelText.text = parentShaft.Level.ToString();
    }
}
