using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WareHouseWorker : Worker
{
    private WareHouse wareHouse;

    private ElevatorHouse elevatorHouse;

    private Manager wareHouseManager;

    private bool stop;

    void Start()
    {
        wareHouse = GetComponentInParent<WareHouse>();
        elevatorHouse = GameObject.FindGameObjectWithTag("ElevatorHouse").GetComponent<ElevatorHouse>();
        wareHouseManager = GameObject.FindGameObjectWithTag("WareHouseManager").GetComponent<Manager>();
    }

    void Update()
    {
        if (wareHouseManager.IsWorking && !isWorking)
        {
            Work();
        }
    }

    IEnumerator WalkRight()
    {
        while (!stop)
        {
            transform.Translate(Vector2.right * Time.deltaTime * wareHouse.MovementSpeed);
            yield return null;
        }
        stop = false;
        StartCoroutine(UnLoad());
    }

    IEnumerator WalkLeft()
    {
        while (!stop)
        {
            transform.Translate(Vector2.left * Time.deltaTime * wareHouse.MovementSpeed);
            yield return null;
        }
        stop = false;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        while (load <= wareHouse.MaxCapacity && elevatorHouse.Cash > 0)
        {
            float amount = Time.deltaTime * wareHouse.LoadingSpeed;
            load += amount;
            elevatorHouse.RemoveCash(amount);
            yield return null;
        }
        StartCoroutine(WalkRight());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WareHouse" || other.tag == "ElevatorHouse")
        {
            stop = true;
        }
    }

    IEnumerator UnLoad()
    {
        while (load > 0)
        {
            float amount = Time.deltaTime * wareHouse.LoadingSpeed;
            load -= amount;
            wareHouse.Cash += amount;
            yield return null;
        }
        load = 0;
        isWorking = false;
    }

    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            StartCoroutine(WalkLeft());
        }
    }
}
