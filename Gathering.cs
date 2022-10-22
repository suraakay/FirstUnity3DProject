using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    GameObject[] Foods;
    GameObject[] Woods;
    GameObject[] Rocks;
    GameObject[] ResourceContainers;
    GameObject CurrentResourceContainer;
    GameObject CurrentDestination;
    int NumberOfResourcePointLeft;

    //to animate worker
    private Animator animator;
    //to rotate worker to new direction
    public Transform target;
    private IEnumerator coroutine;

    // Worker's variables
    [SerializeField] float speed = 3f;
    public bool isIdle = true;
    public bool isLoaded = false;

    //to assign worker to new resource type
    string ResourceTypeToAssign; // bu bilgi oyuncudan alinacak
    GameObject[] ObjectsForSelectedResourceType;
    void Start()
    {
        ResourceTypeToAssign = "Food"; 
        NumberOfResourcePointLeft = GameObject.FindGameObjectsWithTag(ResourceTypeToAssign).Length;
        CurrentDestination = GetClosestEnemy(GameObject.FindGameObjectsWithTag(ResourceTypeToAssign));
        CurrentResourceContainer = GetClosestEnemy(GameObject.FindGameObjectsWithTag("ResourceContainer"));
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //kaynak bittiyse depoya yollama ve durdurma
        if (NumberOfResourcePointLeft == 1) // sifir vermek yerine bir tane agaci haritada sakladim. obur turlu hata veriyor
        {
            ResourceTypeToAssign = null;
        }
        if (ResourceTypeToAssign == null)
        {
            if (isLoaded)
            {
                transform.position = Vector3.MoveTowards(transform.position, CurrentResourceContainer.transform.position, speed * Time.deltaTime);
            }
            else 
            {
                animator.SetBool("isLoaded", false);
                animator.SetBool("isIdle", true);
                isIdle = true;
            }
        }

        if (ResourceTypeToAssign != null) 
        {
            NumberOfResourcePointLeft = GameObject.FindGameObjectsWithTag(ResourceTypeToAssign).Length;
            if (ResourceTypeToAssign == "Food") 
            {

                if (isIdle && !isLoaded) 
                {
                    WorkerAssignerToResource(ResourceTypeToAssign);
                    isIdle = false;
                }
                if (!isIdle && !isLoaded) 
                {
                    CurrentDestination = GetClosestEnemy(GameObject.FindGameObjectsWithTag(ResourceTypeToAssign));
                    transform.position = Vector3.MoveTowards(transform.position, CurrentDestination.transform.position, speed * Time.deltaTime);              
                    WorkerRotater(CurrentDestination);
                }
                if (!isIdle && isLoaded || isIdle && isLoaded)
                {
                    WorkerAssignerToDepot();
                    transform.position = Vector3.MoveTowards(transform.position, CurrentResourceContainer.transform.position, speed * Time.deltaTime);
                    WorkerRotater(CurrentResourceContainer);
                }
            
                if (ResourceTypeToAssign == "Wood")
                {

                }
                if (ResourceTypeToAssign == "Rock")
                {

                }
            }
        }  
    }
   
    void WorkerAssignerToResource(string ResourceTypeToAssign)
    {
        if (ResourceTypeToAssign == "Food") 
        {
            gameObject.tag = "FoodWorker";
        }
        if (ResourceTypeToAssign == "Wood")
        {
            gameObject.tag = "WoodWorker";
        }
        if (ResourceTypeToAssign == "Rock")
        {
            gameObject.tag = "RockWorker";
        }
        ObjectsForSelectedResourceType = GameObject.FindGameObjectsWithTag(ResourceTypeToAssign);
        CurrentDestination = GetClosestEnemy(ObjectsForSelectedResourceType);
    }
    void WorkerAssignerToDepot()
    {
        ResourceContainers = GameObject.FindGameObjectsWithTag("ResourceContainer");
        CurrentResourceContainer = GetClosestEnemy(ResourceContainers);
    }
    void WorkerRotater(GameObject TargetDestination)
    {
        // first part to rotate the worker
        Vector3 relativePos = TargetDestination.transform.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    


    //GameObject for the closest resource point
    GameObject TargetResourcePoint;
    GameObject GetClosestEnemy(GameObject[] ResourcePoints)
    {
        GameObject ClosestResourcePoint = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in ResourcePoints)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                ClosestResourcePoint = potentialTarget;
            }
        }
        return ClosestResourcePoint;
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }
}

