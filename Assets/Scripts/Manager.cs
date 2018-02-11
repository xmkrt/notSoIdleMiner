using UnityEngine;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour, IPointerClickHandler
{
    private bool isWorking;

    private SpriteRenderer spriteRenderer;

    public bool IsWorking { get; set; }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsWorking)
        {
            IsWorking = false;
            spriteRenderer.color = Color.white;
        }
        else
        {
            IsWorking = true;
            spriteRenderer.color = Color.red;
        }
    }
}
