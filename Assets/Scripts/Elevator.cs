using UnityEngine;
using UnityEngine.EventSystems;

public class Elevator : Worker
{
    private int destinationLevel;

    private bool isGoingDown;

    private bool isGoingUp;

    private bool isLoading;

    private bool isUnLoading;

    private GameController gameController;

    private ElevatorHouse elevatorHouse;

    private Vector2 upperPosition;

    private Manager elevatorManager;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
        upperPosition = transform.position;
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
            Decide();
        }
        else if (isUnLoading)
        {
            UnLoad();
        }
    }

    void MoveDown()
    {
        if (transform.position.y > gameController.GetShaftPosition(destinationLevel))
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
        if (transform.position.y <= upperPosition.y)
        {
            transform.Translate(Vector2.up * elevatorHouse.MovementSpeed * Time.deltaTime);
        }
        else
        {
            isGoingUp = false;
            destinationLevel = 0;
        }
    }

    void Decide()
    {
        //load cash if maxCapacity is not reached
        if (gameController.GetShaftCash(destinationLevel) > 0 && load < elevatorHouse.MaxCapacity)
        {
            Load();
        }
        //End of mine -> go up
        else if (gameController.ShaftCount == destinationLevel)
        {
            isGoingUp = true;
            isLoading = false;
        }
        //go down if there is another shaft and maxCapacity not reached
        else if (gameController.GetShaftCash(destinationLevel) < gameController.ShaftCount && load < elevatorHouse.MaxCapacity)
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

    private void Load()
    {
        float amount = Time.deltaTime * elevatorHouse.LoadingSpeed;
        load += amount;
        gameController.SetShaftCash(destinationLevel, amount);
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ElevatorHouse")
        {
            isUnLoading = true;
        }
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
