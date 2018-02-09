using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHouse : MonoBehaviour
{

    private float cash;
    private float movementSpeed = 2f;
    private float loadingSpeed = 5;
    private float maxCapacity = 20;
    private int level = 1; 
    public float Cash
    {
        get { return cash; } set { cash = value; }
    }

    public float MovementSpeed
    {   
        get { return movementSpeed; } set { movementSpeed = value; }
    }

    public float LoadingSpeed
    {  
        get { return loadingSpeed; } set { loadingSpeed = value; }
    }

    public float MaxCapacity
    {
        get { return maxCapacity; } set { maxCapacity = value; }
    }

    public int Level
    {
        get { return level; } set { level = value; }
    }

    public void AddCash(float cash)
    {
        this.Cash += cash;
    }
    public void RemoveCash(float cash)
    {
        this.Cash -= cash;
    }

    public void LevelUp()
    {
        Level++;
        MovementSpeed += 0.02f;
        MaxCapacity = Level*Level*Level*10;
        LoadingSpeed = Level*Level*5;
    }
}
