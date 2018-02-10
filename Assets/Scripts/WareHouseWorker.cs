﻿using UnityEngine;
using UnityEngine.EventSystems;

public class WareHouseWorker : Worker
{
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private bool isLoading;
    private bool isUnloading;
    private WareHouse wareHouse;
    private GameController gameController;
    private ElevatorHouse elevatorHouse;
    private Manager wareHouseManager;

    void Start()
    {
        wareHouse = GetComponentInParent<WareHouse>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
        wareHouseManager = GameObject.FindGameObjectWithTag("WareHouseManager").GetComponent<Manager>();
    }
    void Update()
    {
        if (wareHouseManager.IsWorking && !isWorking)
        {
            Work();
        }
        if (isWalkingLeft)
        {
            WalkLeft();
        }
        else if (isWalkingRight)
        {
            WalkRight();
        }
        else if (isLoading)
        {
            Load();
        }
        else if (isUnloading)
        {
            UnLoad();
        }
    }

    void WalkRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * wareHouse.WalkingSpeed);
    }

    void WalkLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * wareHouse.WalkingSpeed);
    }

    void Load()
    {
        if (load <= wareHouse.MaxCapacity && elevatorHouse.Cash > 0)
        {
            float amount = Time.deltaTime * wareHouse.LoadingSpeed;
            load += amount;
            elevatorHouse.RemoveCash(amount);
        }
        else
        {
            isLoading = false;
            isWalkingRight = true;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Warehouse")
        {
            isWalkingRight = false;
            isUnloading = true;
        }
        else if (other.tag == "ElevatorHouse")
        {
            isWalkingLeft = false;
            isLoading = true;
        }

    }

    private void UnLoad()
    {
        if (load > 0)
        {
            float amount = Time.deltaTime * wareHouse.LoadingSpeed;
            load -= amount;
            gameController.AddCash(amount);
        }
        else
        {
            load = 0;
            isUnloading = false;
            isWorking = false;
        }
    }

    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingLeft = true;
        }
    }
}
