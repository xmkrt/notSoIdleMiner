using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLevelWareHouse : MonoBehaviour, IPointerClickHandler
{
    private WareHouse wareHouse;
    
    private TextMesh levelText;

    void Start()
    {
        wareHouse = GetComponentInParent<WareHouse>();
        levelText = GetComponentInChildren<TextMesh>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        wareHouse.LevelUp();
        levelText.text = wareHouse.Level.ToString();
    }
}
