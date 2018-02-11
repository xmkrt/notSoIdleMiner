// basic game controller.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject shaftGameObject;

    public List<GameObject> shafts = new List<GameObject>();

    [SerializeField]
    private float shaftDistance = 5;
    
    //for nat having to use .Count all the time
    private int shaftCount;
    private float cash;

    public int ShaftCount
    {
        get { return shaftCount; }
        set { shaftCount = value; }
    }
    public float Cash
    {
        get { return cash; }
        set { cash = value; }
    }

    void Start()
    {
        AddShaft();
    }

    //adds a new shaft to the game
    public void AddShaft()
    {
        if (shaftCount < 17)
        {
            GameObject shaft = Instantiate(shaftGameObject, transform.GetChild(0).transform) as GameObject;
            shafts.Add(shaft);
            shaft.transform.position = new Vector2(shaft.transform.position.x, shaft.transform.position.y - shaftCount * shaftDistance);
            ShaftCount++;
            shaft.GetComponent<Shaft>().Multi = shaftCount;
        }
    }

    public float GetShaftPosition(int index)
    {
        return shafts[index - 1].transform.position.y;
    }

    public float GetShaftCash(int index)
    {
        return shafts[index - 1].GetComponent<Shaft>().GetCash();
    }

    public void SetShaftCash(int index, float amount)
    {
        shafts[index - 1].GetComponent<Shaft>().SetCash(amount);
    }
}
