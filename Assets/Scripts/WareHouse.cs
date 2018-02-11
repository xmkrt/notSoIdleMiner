using UnityEngine;

public class WareHouse : Structure
{
    [SerializeField]
    private GameObject wareHouseWorkerObject;

    void Start()
    {
        AddWorker();
    }

    public void AddWorker()
    {
        GameObject worker = Instantiate(wareHouseWorkerObject, transform) as GameObject;
        movementSpeed = 1f;
        loadingSpeed = 2f;
        maxCapacity = 10f;
    }

    public override void LevelUp()
    {
        Level++;
        MovementSpeed += 0.02f;
        LoadingSpeed = Level * Level;
        MaxCapacity = Level * Level * 3;
        if (Level % 20 == 0)
        {
            AddWorker();
        }
    }
}