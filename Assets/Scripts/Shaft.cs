using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    //multiplier for shaftLevel
    private int multi = 1;
    private float walkingSpeed = 1f;
    private float miningSpeed = 3f;
    private float maxCapacity = 10f;
    private float cash;
    private int level = 1;
    [SerializeField]
    GameObject workerGameObject;
    List<GameObject> workers = new List<GameObject>();
    List<GameObject> managers = new List<GameObject>();

    public float MaxCapacity
    {
        get
        {
            return maxCapacity;
        }

        set
        {
            maxCapacity = value;
        }
    }

    public float MiningSpeed
    {
        get
        {
            return miningSpeed;
        }

        set
        {
            miningSpeed = value;
        }
    }

    public float WalkingSpeed
    {
        get
        {
            return walkingSpeed;
        }

        set
        {
            walkingSpeed = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    void Start()
    {
        workers.Add(GetComponentInChildren<ShaftWorker>().gameObject);
    }

    void Update()
    {

    }

    public void LevelUp()
    {
        Level++;
        WalkingSpeed += 0.02f;
        MaxCapacity = Level * Level * 3 * multi;
        MiningSpeed = Level * Level + multi;
        if (Level % 10 == 0)
        {
            AddWorker();
        }
    }

    void AddWorker()
    {
        GameObject worker = Instantiate(workerGameObject, transform.position + new Vector3(-1f, -0.2f, 0), Quaternion.identity, transform) as GameObject;
        workers.Add(worker);
    }

    public void UnLoad(float cash)
    {
        this.cash += cash;
    }

    public int getWorkers()
    {
        return workers.Count;
    }

    public float GetCash()
    {
        return cash;
    }

    public void SetCash(float amount)
    {
        cash -= amount;
    }

    public void SetMultiplier(int multi)
    {

    }

}