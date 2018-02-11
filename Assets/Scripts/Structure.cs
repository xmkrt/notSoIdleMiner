// base class for Warehouse, ElevatorHouse and Shaft with common members
using UnityEngine;

public abstract class Structure : MonoBehaviour
{
    protected float movementSpeed;

    protected float loadingSpeed;

    protected float maxCapacity;

    protected int level = 1;
    
    protected float cash;

    public float Cash
    {
        get { return cash; }
        set { cash = value; }
    }
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public float LoadingSpeed
    {
        get { return loadingSpeed; }
        set { loadingSpeed = value; }
    }

    public float MaxCapacity
    {
        get { return maxCapacity; }
        set { maxCapacity = value; }
    }

    public abstract void LevelUp();
}

