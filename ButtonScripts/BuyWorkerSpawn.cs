using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using System.ComponentModel;

public class BuyWorkerSpawn : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    public InventoryStats _inventoryStats;
    public WorkerAssignment _workerAssignment;
    int AvailableFood;
    public int WorkerCount = 1;

    [SerializeField] GameObject Worker;
    [SerializeField] GameObject SpawnPoint;


    private void Start()
    {
    }
    private void Update()
    {
        AvailableFood = _inventoryStats.food;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnNewUnit();
    }

    public void SpawnNewUnit()
    {
        if (AvailableFood >= 50)
        {
            Instantiate(Worker, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            
         
            Worker.tag = "IdleWorker";
            Worker.GetComponent<Gathering>().isLoaded = false;
            WorkerCount++;
            _inventoryStats.OneWorkerBought();
            _workerAssignment.NewUnitSpawn();

        }
        else 
        {
            Debug.Log("Not enough food... The unit can not be bought.");
        }
    }


}