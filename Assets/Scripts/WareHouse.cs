//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareHouse : MonoBehaviour
{
    private float walkingSpeed = 1f;
    private float loadingSpeed = 2f;
    private float maxCapacity = 10f;
    [SerializeField]
    private GameObject wareHouseWorkerObject;
    private int level = 1;
    public int Level
    {
        get { return level; } set { level = value; }
    }

    public float WalkingSpeed
    {   
        get { return walkingSpeed; } set { walkingSpeed = value; }
    }

    public float LoadingSpeed
    {
        get { return loadingSpeed; } set { loadingSpeed = value; }
    }

    public float MaxCapacity
    {
        get { return maxCapacity; } set { maxCapacity = value; }
    }

    void Start()
    {
        AddWorker();
    }

    public void AddWorker()
    {
        GameObject worker = Instantiate(wareHouseWorkerObject, transform) as GameObject;
    }

    public void LevelUp()
    {
        Level++;
        WalkingSpeed += 0.02f;
        LoadingSpeed = Level*Level;
        MaxCapacity = Level * Level * 3;
        if (Level % 20 == 0)
        {
            AddWorker();
        }
    }
}