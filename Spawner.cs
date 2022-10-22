using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnNewUnit(GameObject UnitToSpawn) 
    {
        Instantiate(UnitToSpawn, transform.position, transform.rotation);
    }

}
