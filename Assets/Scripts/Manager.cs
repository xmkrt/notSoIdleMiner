using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{

    //movement or walkingSpeed
    protected int speedBoost;
    protected float multiplier;
    protected string managerName = "Mr. ";
    // Junior, Senior and Executive type
    protected int type;

    private

    void Start()
    {   // 0 = Junior, 1 = Senior, 2 = Executive
        type = Random.Range(0, 3);
        GenerateName();

        switch (type)
        {
            case 0:
                multiplier = 0.3f;
                speedBoost = 3;
                break;
            case 1:
                multiplier = 0.7f;
                speedBoost = 5;
                break;
            case 2:
                multiplier = 0.8f;
                speedBoost = 7;
                break;
            default:
                multiplier = 1f;
                break;
        }
    }
    private void GenerateName()
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
}
