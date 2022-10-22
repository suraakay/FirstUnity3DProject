using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class BuySoldierSpawn : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    [SerializeField] GameObject Soldier;
    [SerializeField] GameObject SpawnPoint;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        SpawnNewUnit();
    }

    public void SpawnNewUnit()
    {
        Instantiate(Soldier, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }
}