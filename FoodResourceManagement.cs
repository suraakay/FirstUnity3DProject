using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodResourceManagement : MonoBehaviour
{
    public int AmountOfResourcesLeft;

    void Start()
    {
        AmountOfResourcesLeft = 500;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FoodWorker" && collision.gameObject.GetComponent<Gathering>().isLoaded == false) 
        {
            collision.gameObject.GetComponent<Gathering>().isLoaded = true;
            AmountOfResourcesLeft--;

            if (AmountOfResourcesLeft == 0)
            {
                gameObject.tag = "Destroyed";
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                //Destroy(gameObject); Burasi bug yaratir
            }
        }
        
    }
}




