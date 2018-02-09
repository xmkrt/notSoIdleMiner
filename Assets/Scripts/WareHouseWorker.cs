using UnityEngine;
using UnityEngine.EventSystems;

public class WareHouseWorker : Worker
{
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private bool isLoading;
    private WareHouse wareHouse;
    private GameController myGameController;
    private ElevatorHouse elevatorHouse;
    private Manager wareHouseManager;

    void Start()
    {
        wareHouse = GetComponentInParent<WareHouse>();
        myGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingLeft = true;
        }
    }
}
