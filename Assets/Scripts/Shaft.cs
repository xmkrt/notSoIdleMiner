using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : Structure
{
    private int multi = 1;

    //offset for the worker Object
    private Vector3 offset = new Vector3(-1f, -0.2f, 0);

    [SerializeField]
    GameObject workerGameObject;
    
    //unnecessary for now
    List<GameObject> workers = new List<GameObject>();

    public int Multi
    {
        get { return multi; } set { multi = value; }
    }

    void Start()
    {
        workers.Add(GetComponentInChildren<ShaftWorker>().gameObject);
        movementSpeed = 1f;
        maxCapacity = 10f;
        loadingSpeed = 3f;
    }

    public override void LevelUp()
    {
        Level++;
        MovementSpeed += 0.02f;
        MaxCapacity = Level * Level * 3 * Multi;
        LoadingSpeed = Level * Level + Multi;

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
}