using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorHouse : Structure
{
    void Start()
    {
        movementSpeed = 2f;
        loadingSpeed = 5;
        maxCapacity = 20;
    }

    public void AddCash(float cash)
    {
        this.Cash += cash;
    }
    
    public void RemoveCash(float cash)
    {
        this.Cash -= cash;
    }

    public override void LevelUp()
    {
        Level++;
        MovementSpeed += 0.02f;
        MaxCapacity = Level * Level * Level * 10;
        LoadingSpeed = Level * Level * Level * 2;
    }
}
