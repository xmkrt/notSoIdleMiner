using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouseWorker : MonoBehaviour
{
    private float load;
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private bool isLoading;
    private bool isWorking;
    private WareHouse parentWareHouse;
    private GameController myGameController;
    private ElevatorHouse elevatorHouse;
    void Start()
    {
        parentWareHouse = GetComponentInParent<WareHouse>();
        myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
    }
    void Update()
    {
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
    }
    void onMouseDown()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingLeft = true;
        }
    }

    void WalkRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * parentWareHouse.WalkingSpeed);
    }

    void WalkLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * parentWareHouse.WalkingSpeed);
    }

    void Load()
    {
        if (load <= parentWareHouse.MaxCapacity && elevatorHouse.Cash > 0)
        {
            float amount = Time.deltaTime * parentWareHouse.LoadingSpeed;
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
            myGameController.AddCash(load);
            load = 0;
            isWalkingRight = false;
            isWorking = false;
        }
        else if (other.tag == "ElevatorHouse")
        {
            isWalkingLeft = false;
            isLoading = true;
        }

    }

    void OnMouseDown()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingLeft = true;
        }
    }
}
