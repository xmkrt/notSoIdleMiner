using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour, IPointerClickHandler
{

    //movement or walkingSpeed
    protected int speedBoost;
    protected float boostTime;
    protected float multiplier;
    protected string managerName = "Mr. ";
    protected int type;
    private bool isWorking;
    protected bool isBoosting;

    private SpriteRenderer spriteRenderer;

    public bool IsWorking
    {
        get
        {
            return isWorking;
        }

        set
        {
            isWorking = value;
        }
    }

    protected virtual void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        GenerateName();

        // 0 = Junior, 1 = Senior, 2 = Executive
        type = Random.Range(0, 3);
        switch (type)
        {
            case 0:
                multiplier = 0.3f;
                speedBoost = 3;
                boostTime = 1f;
                break;
            case 1:
                multiplier = 0.7f;
                speedBoost = 5;
                boostTime = 3f;
                break;
            case 2:
                multiplier = 0.8f;
                speedBoost = 7;
                boostTime = 5f;
                break;
            default:
                multiplier = 1f;
                break;
        }
    }
    protected virtual void GenerateName()
    {
        string firstLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string letters = "abcdefghijklmnopqrstuvwxyz";
        int length = Random.Range(3, 8);

        managerName += firstLetter[Random.Range(0, firstLetter.Length)];

        for (int i = 0; i < length; i++)
        {
            managerName += letters[Random.Range(0, letters.Length)];
        }
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
