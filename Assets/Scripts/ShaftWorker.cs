using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftWorker : Worker
{

    Shaft parentShaft;

    Manager manager;

    private bool stop;

    void Start()
    {
        parentShaft = GetComponentInParent<Shaft>();
        manager = parentShaft.GetComponentInChildren<Manager>();
    }

    void Update()
    {
        if (manager.IsWorking && !isWorking)
        {
            Work();
        }
    }

    IEnumerator WalkRight()
    {
        while (!stop)
        {
            transform.Translate(Vector2.right * Time.deltaTime * parentShaft.MovementSpeed);
            yield return null;
        }
        stop = false;
        StartCoroutine(Mine());
    }

    IEnumerator WalkLeft()
    {
        while (!stop)
        {
            transform.Translate(Vector2.left * Time.deltaTime * parentShaft.MovementSpeed);
            yield return null;
        }
        stop = false;
        UnLoad();
    }

    void UnLoad()
    {
        parentShaft.UnLoad(load);
        isWorking = false;
        load = 0;
    }

    IEnumerator Mine()
    {
        while (load < parentShaft.MaxCapacity)
        {
            load += parentShaft.LoadingSpeed * Time.deltaTime;
            yield return null;
        }
        load = parentShaft.MaxCapacity;
        StartCoroutine(WalkLeft());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        stop = true;
    }

    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            StartCoroutine(WalkRight());
        }
    }
}
