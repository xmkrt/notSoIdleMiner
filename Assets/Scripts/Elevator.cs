using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Elevator : Worker
{
    private int destinationLevel;

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
    }

    IEnumerator MoveDown()
    {
        while (transform.position.y > gameController.GetShaftPosition(destinationLevel))
        {
            transform.Translate(Vector2.down * elevatorHouse.MovementSpeed * Time.deltaTime);
            yield return null;
        }
        Decide();

    }
    IEnumerator MoveUp()
    {
        while (transform.position.y < upperPosition.y)
        {
            transform.Translate(Vector2.up * elevatorHouse.MovementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Decide()
    {
        //load cash if maxCapacity is not reached
        if (gameController.GetShaftCash(destinationLevel) > 0 && load < elevatorHouse.MaxCapacity)
        {
            StartCoroutine(Load());
        }
        //End of mine -> go up
        else if (gameController.ShaftCount == destinationLevel)
        {
            StartCoroutine(MoveUp());
        }
        //go down if there is another shaft and maxCapacity not reached
        else if (gameController.GetShaftCash(destinationLevel) < gameController.ShaftCount && load < elevatorHouse.MaxCapacity)
        {
            destinationLevel++;
            StartCoroutine(MoveDown());
        }
        //go up if maxCapacity is reached
        else if (load >= elevatorHouse.MaxCapacity)
        {
            StartCoroutine(MoveUp());
        }
    }

    IEnumerator Load()
    {   
        float amount  = 0f;  
        while (load < elevatorHouse.MaxCapacity && gameController.GetShaftCash(destinationLevel) > amount)
        {
            amount = Time.deltaTime * elevatorHouse.LoadingSpeed;
            load += amount;
            gameController.SetShaftCash(destinationLevel, amount);
            yield return null;
        }
        
        Decide();
    }

    IEnumerator UnLoad()
    {
        float amount  = 0f;
        while (load > 0)
        {
            amount = Time.deltaTime * elevatorHouse.LoadingSpeed;
            load -= amount;
            elevatorHouse.AddCash(amount);
            yield return null;
        }
        destinationLevel = 0;
        Invoke("Delay", 0.1f);      

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ElevatorHouse")
        {
            StartCoroutine(UnLoad());
        }
    }

    private void Delay(){
        isWorking = false;
    }

    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            destinationLevel++;
            StartCoroutine(MoveDown());
        }
    }
}
