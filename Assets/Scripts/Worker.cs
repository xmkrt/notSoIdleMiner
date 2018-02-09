// base class for ShaftWorker, Elevator and WareHouseWorker
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Worker : MonoBehaviour, IPointerClickHandler
{
    protected bool isWorking;
    protected float load;

    public void OnPointerClick(PointerEventData eventData)
    {
        Work();
    }

    protected abstract void Work();

}
