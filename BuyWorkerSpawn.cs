using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class BuyWorkerSpawn : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    [SerializeField] GameObject Worker;
    [SerializeField] GameObject SpawnPoint;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        SpawnNewUnit();
    }

    public void SpawnNewUnit()
    {
        Instantiate(Worker, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }
}