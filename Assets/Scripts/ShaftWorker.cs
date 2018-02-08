using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftWorker : MonoBehaviour
{
    private bool isWorking;
    private bool isMining;
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private float load;
    Shaft parentShaft;
    void Start()
    {
        parentShaft = GetComponentInParent<Shaft>();
    }

    void Update()
    {
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

    void OnMouseDown()
    {
        if (!isWorking)
        {
            isWorking = true;
            isWalkingRight = true;
        }
    }
}
