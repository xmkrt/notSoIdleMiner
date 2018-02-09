using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    //stats for all workers of this shaft
    private int multi = 1;
    private float walkingSpeed = 1f;
    private float miningSpeed = 3f;
    private float maxCapacity = 10f;
    //stats of this shaft
    private float cash;
    private int level = 1;
    private Vector3 offset = new Vector3(-1f, -0.2f, 0);
    [SerializeField]
    GameObject workerGameObject;
    //unnecessary for now
    List<GameObject> workers = new List<GameObject>();

    //properties
    public float MaxCapacity
    {
        get { return maxCapacity; } set { maxCapacity = value; }
    }

    public float MiningSpeed
    {
        get { return miningSpeed; } set { miningSpeed = value; }
    }

    public float WalkingSpeed
    {
        get { return walkingSpeed; } set { walkingSpeed = value; }
    }

    public int Level
    {
        get { return level; } set { level = value; }
    }

    public int Multi
    {
        get { return multi; } set { multi = value; }
    }

    void Start()
    {
        workers.Add(GetComponentInChildren<ShaftWorker>().gameObject);
    }

    public void LevelUp()
    {
        Level++;
        WalkingSpeed += 0.02f;
        MaxCapacity = Level * Level * 3 * Multi;
        MiningSpeed = Level * Level + Multi;
        if (Level % 10 == 0)
        {
            AddWorker();
        }
    }

    void AddWorker()
    {
        GameObject worker = Instantiate(workerGameObject, transform.position + offset, Quaternion.identity, transform) as GameObject;
        workers.Add(worker);
    }

    public void UnLoad(float cash)
    {
        this.cash += cash;
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