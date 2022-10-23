using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkerAssignment : MonoBehaviour
{
    //public Gathering _gathering;

    public BuyWorkerSpawn _buyWorkerSpawn;
    public BuySoldierSpawn _buySoldierSpawn;
    public int AmountOfFoodWorker;
    public int AmountOfWoodWorker;
    public int AmountOfRockWorker;
    public int TotalAmountOfWorkers;
    public int FreeWorkerAmount;

    public GameObject PanelFoodWorkerPencentage;
    public GameObject PanelWoodWorkerPencentage;
    public GameObject PanelRockWorkerPencentage;
    public GameObject PanelTotalAmountOfWorkers;
    public GameObject PanelTotalFreeWorkers;

    int WorkerAmount;
    int CurrentAssignedForFood;
    int CurrentAssignedForWood;
    int CurrentAssignedForRock;

    TMP_Text PanelFoodWorkerAmount;
    TMP_Text PanelWoodWorkerAmount;
    TMP_Text PanelRockWorkerAmount;
    TMP_Text PanelTotalWorkerAmounT;
    TMP_Text PanelTotalFreeWorkerAmounT;

    GameObject[] AllIdleWorkersInTheMap;
    GameObject[] AllFoodWorkersInTheMap;
    GameObject[] AllWoodWorkersInTheMap;
    GameObject[] AllRockWorkersInTheMap;

    void Start()
    {
        WorkerAmount = _buyWorkerSpawn.WorkerCount;
        

        CurrentAssignedForFood = 0;
        CurrentAssignedForWood = 0;
        CurrentAssignedForRock = 0;
        FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);
        PanelFoodWorkerPencentage = GameObject.FindWithTag("PercentageOfFoodWorker");
        PanelWoodWorkerPencentage = GameObject.FindWithTag("PercentageOfWoodWorker");
        PanelRockWorkerPencentage = GameObject.FindWithTag("PercentageOfRockWorker");
        PanelTotalAmountOfWorkers = GameObject.FindWithTag("PanelTotalWorkerAmount");
        PanelTotalFreeWorkers = GameObject.FindWithTag("PanelTotalFreeWorkerAmount");

        PanelFoodWorkerAmount = PanelFoodWorkerPencentage.GetComponent<TMP_Text>();
        PanelWoodWorkerAmount = PanelWoodWorkerPencentage.GetComponent<TMP_Text>();
        PanelRockWorkerAmount = PanelRockWorkerPencentage.GetComponent<TMP_Text>();
        PanelTotalWorkerAmounT = PanelTotalAmountOfWorkers.GetComponent<TMP_Text>();
        PanelTotalFreeWorkerAmounT = PanelTotalFreeWorkers.GetComponent<TMP_Text>();

        AllIdleWorkersInTheMap = GameObject.FindGameObjectsWithTag("IdleWorker");
    }


    // Update is called once per frame
    void Update()
    {
        WorkerAmount = _buyWorkerSpawn.WorkerCount;
        PanelFoodWorkerAmount.text = Convert.ToString(CurrentAssignedForFood);
        PanelWoodWorkerAmount.text = Convert.ToString(CurrentAssignedForWood);
        PanelRockWorkerAmount.text = Convert.ToString(CurrentAssignedForRock);


        WorkerAmount = _buyWorkerSpawn.WorkerCount;
        PanelTotalWorkerAmounT.text = Convert.ToString(WorkerAmount);
        PanelTotalFreeWorkerAmounT.text = Convert.ToString(FreeWorkerAmount);
        
    }

    //Changing Food Worker Amount
    public void ChangeFoodWorkerPercentageIncreaser()
    {
        if (WorkerAmount > (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock)) 
        {
            try
            {
                AllIdleWorkersInTheMap = GameObject.FindGameObjectsWithTag("IdleWorker");
                if (AllIdleWorkersInTheMap.Length != 0)
                {
                    CurrentAssignedForFood += 1;
                    AllIdleWorkersInTheMap[0].tag = "FoodWorker";
                    FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);
                }
            }
            catch 
            {

            }
            
        }
    }
    public void ChangeFoodWorkerPercentageDecreaser()
    {
        if (CurrentAssignedForFood != 0)
        {
            AllFoodWorkersInTheMap = GameObject.FindGameObjectsWithTag("FoodWorker");
            CurrentAssignedForFood -= 1;
            AllFoodWorkersInTheMap[0].tag = "IdleWorker";
            AllFoodWorkersInTheMap[0].GetComponent<Gathering>().isLoaded = false;
            FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);

        }
    }
    //Changing Wood Worker Amount
    public void ChangeWoodWorkerPercentageIncreaser()
    {
        if (WorkerAmount > (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock))
        {
            try
            {
                AllIdleWorkersInTheMap = GameObject.FindGameObjectsWithTag("IdleWorker");
            }
            catch
            {
                AllIdleWorkersInTheMap = null;
            }
            if (AllIdleWorkersInTheMap != null)
            {
                CurrentAssignedForWood += 1;
                try
                {
                    AllIdleWorkersInTheMap[0].tag = "WoodWorker";
                    FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);
                }
                catch
                {

                }
            }
        }
    }
    public void ChangeWoodWorkerPercentageDecreaser()
    {
        if (CurrentAssignedForWood != 0)
        {
            AllWoodWorkersInTheMap = GameObject.FindGameObjectsWithTag("WoodWorker");
            CurrentAssignedForWood -= 1;
            AllWoodWorkersInTheMap[0].tag = "IdleWorker";
            AllWoodWorkersInTheMap[0].GetComponent<Gathering>().isLoaded = false;
            FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);

        }
    }
    //Changing Rock Worker Amount
    public void ChangeRockWorkerPercentageIncreaser()
    {
        if (WorkerAmount > (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock))
        {

            try
            {
                AllIdleWorkersInTheMap = GameObject.FindGameObjectsWithTag("IdleWorker");
            }
            catch
            {
                AllIdleWorkersInTheMap = null;
            }
            if (AllIdleWorkersInTheMap != null)
            {
                CurrentAssignedForRock += 1;
                try
                {
                    AllIdleWorkersInTheMap[0].tag = "RockWorker";
                    FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);
                }
                catch
                {

                }
            }
        }
    }
    public void ChangeRockWorkerPercentageDecreaser()
    {
        if (CurrentAssignedForRock != 0)
        {
            AllRockWorkersInTheMap = GameObject.FindGameObjectsWithTag("RockWorker");
            CurrentAssignedForRock -= 1;
            AllRockWorkersInTheMap[0].tag = "IdleWorker";
            AllRockWorkersInTheMap[0].GetComponent<Gathering>().isLoaded = false;
            FreeWorkerAmount = WorkerAmount - (CurrentAssignedForFood + CurrentAssignedForWood + CurrentAssignedForRock);
        }
    }

    public void NewUnitSpawn() //Bu unit spawn etmek icin degil, sadece haberi geliyor ekrana yansitiyor.
    {
        FreeWorkerAmount++;
    }
}
