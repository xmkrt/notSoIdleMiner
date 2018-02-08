using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject shaftGameObject;
    List<GameObject> shafts = new List<GameObject>();
    [SerializeField]
    private float shaftDistance = 5;
    private int shaftCount;
    private float cash;
    public int ShaftCount
    {
        get
        {
            return shaftCount;
        }

        set
        {
            shaftCount = value;
        }
    }
    public float Cash
    {
        get
        {
            return cash;
        }

        set
        {
            cash = value;
        }
    }

    void Start()
    {
        GameObject firstShaft = Instantiate(shaftGameObject, transform.GetChild(0).transform) as GameObject;
        shafts.Add(firstShaft);
        ShaftCount++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddShaft()
    {
        if (shaftCount < 16)
        {
            GameObject shaft = Instantiate(shaftGameObject, transform.GetChild(0).transform) as GameObject;
            shafts.Add(shaft);
            shaft.transform.position = new Vector2(shaft.transform.position.x, shaft.transform.position.y - shaftCount * shaftDistance);
            ShaftCount++;
            shaft.GetComponent<Shaft>().Multi = shaftCount;
            shaft.GetComponent<Shaft>().SetMultiplier(ShaftCount);
        }
    }

    public void AddCash(float cash)
    {
        this.Cash += cash;
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
