using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShaftWorker : Worker
{
    private bool isMining;
    private bool isWalkingRight;
    private bool isWalkingLeft;

    Shaft parentShaft;
    Manager manager;

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
        if (isMining)
        {
            Mine();
        }

        if (isWalkingRight)
        {
            WalkRight();
        }
        else if (isWalkingLeft)
        {
            WalkLeft();
        }
    }
    void WalkRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * parentShaft.WalkingSpeed);
    }

    void WalkLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * parentShaft.WalkingSpeed);
    }

    void UnLoad()
    {
        parentShaft.UnLoad(load);
        isWorking = false;
        load = 0;
    }

    void Mine()
    {
        load += parentShaft.MiningSpeed * Time.deltaTime;
        if (load >= parentShaft.MaxCapacity)
        {
            load = parentShaft.MaxCapacity;
            isMining = false;
            isWalkingLeft = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ShaftRight")
        {
            isMining = true;
            isWalkingRight = false;
        }
        else if (other.tag == "ShaftLeft")
        {
            UnLoad();
            isWalkingLeft = false;
        }
    }
    
    protected override void Work()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingRight = true;
        }
    }
}
