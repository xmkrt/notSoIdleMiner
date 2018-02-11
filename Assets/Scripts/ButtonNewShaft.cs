using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonNewShaft : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddShaft();
    }
}