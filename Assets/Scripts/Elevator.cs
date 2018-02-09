using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Elevator : Worker
{
    private int destinationLevel;
    private bool isGoingDown;
    private bool isGoingUp;
    private bool isLoading;
    private bool isUnLoading;
    GameController myGameController;
    ElevatorHouse elevatorHouse;
    Vector2 startingPos;

    Manager elevatorManager;

    void Start()
    {
        myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
        startingPos = transform.position;
        elevatorManager = GameObject.FindGameObjectWithTag("ElevatorManager").GetComponent<Manager>();
    }

    void Update()
    {
        if (elevatorManager.IsWorking && !isWorking)
        {
            Work();
        }
        else if (isGoingDown)
        {
            MoveDown();
        }
        else if (isGoingUp)
        {
            MoveUp();
        }
        else if (isLoading)
        {
            Load();
        }
        else if (isUnLoading)
        {
            UnLoad();
        }
    }

    void MoveDown()
    {
        if (transform.position.y > myGameController.GetShaftPosition(destinationLevel))
        {
            transform.Translate(Vector2.down * elevatorHouse.MovementSpeed * Time.deltaTime);
        }
        else
        {
            isGoingDown = false;
            isLoading = true;
        }
    }
    void MoveUp()
    {
        if (transform.position.y <= startingPos.y)
        {
            transform.Translate(Vector2.up * elevatorHouse.MovementSpeed * Time.deltaTime);
        }
        else
        {
            isGoingUp = false;
            destinationLevel = 0;
        }
    }

    void Load()
    {
        //load cash if maxCapacity is not reached
        if (myGameController.GetShaftCash(destinationLevel) > 0 && load < elevatorHouse.MaxCapacity)
        {
            float amount = Time.deltaTime * elevatorHouse.LoadingSpeed;
            load += amount;
            myGameController.SetShaftCash(destinationLevel, amount);
        }
        //End of mine -> go up
        else if (myGameController.ShaftCount == destinationLevel)
        {
            isGoingUp = true;
            isLoading = false;
        }
        //go down if there is another shaft and maxCapacity not reached
        else if (myGameController.GetShaftCash(destinationLevel) < myGameController.ShaftCount && load < elevatorHouse.MaxCapacity)
        {
            destinationLevel++;
            isGoingDown = true;
            isLoading = false;
        }
        //go up if maxCapacity is reached
        else if (load >= elevatorHouse.MaxCapacity)
        {
            isLoading = false;
            isGoingUp = true;
            destinationLevel = 0;
        }
    }
    void UnLoad()
    {
        if (load > 0)
        {
            float amount;
            amount = Time.deltaTime * elevatorHouse.LoadingSpeed;
            load -= amount;
            elevatorHouse.AddCash(amount);
        }
        else
        {
            isUnLoading = false;
            isWorking = false;
        }
    }
    void OnTriggerEnter2D()
    {
        isUnLoading = true;
    }

    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            isGoingDown = true;
            destinationLevel++;
        }
    }
}
