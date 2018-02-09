
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLevelElevator : MonoBehaviour, IPointerClickHandler
{
    private ElevatorHouse elevatorHouse;
    private TextMesh levelText;
    void Start()
    {
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
        levelText = GetComponentInChildren<TextMesh>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        elevatorHouse.LevelUp();
        levelText.text = elevatorHouse.Level.ToString();
    }
}