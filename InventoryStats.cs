using JetBrains.Annotations;
using Mono.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryStats : MonoBehaviour
{

    public int food = 40000;
    public int wood = 50;
    public int rock = 60;

    [SerializeField] GameObject PanelForFood; //Oyundayken ekrin sol ust tarafinda kac food/wood/rock oldugunu gormek icin
    [SerializeField] GameObject PanelForWood; //Oyundayken ekrin sol ust tarafinda kac food/wood/rock oldugunu gormek icin
    [SerializeField] GameObject PanelForRock; //Oyundayken ekrin sol ust tarafinda kac food/wood/rock oldugunu gormek ici


    private TMP_Text ForFood;
    private TMP_Text ForWood;
    private TMP_Text ForRock;

    private void Awake()
    {
        // Since we are using the base class type <TMP_Text> this component could be either a <TextMeshPro> or <TextMeshProUGUI> component.
        ForFood = PanelForFood.GetComponent<TMP_Text>();
        ForWood = PanelForWood.GetComponent<TMP_Text>();
        ForRock = PanelForRock.GetComponent<TMP_Text>();
    }
    void Start()
    {
        ForFood.text = Convert.ToString(food);
        ForWood.text = Convert.ToString(wood); 
        ForRock.text = Convert.ToString(rock); 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FoodWorker" && collision.gameObject.GetComponent<Gathering>().isLoaded == true) 
        {
            collision.gameObject.GetComponent<Gathering>().isLoaded = false;
            food++;

            ForFood.text = Convert.ToString(food);
        }

        if (collision.gameObject.tag == "WoodWorker" && collision.gameObject.GetComponent<Gathering>().isLoaded == true)
        {

            collision.gameObject.GetComponent<Gathering>().isLoaded = false;
            wood++;

            ForWood.text = Convert.ToString(wood);
        }
        if (collision.gameObject.tag == "RockWorker" && collision.gameObject.GetComponent<Gathering>().isLoaded == true)
        {
            collision.gameObject.GetComponent<Gathering>().isLoaded = false;
            rock++;

            ForRock.text = Convert.ToString(rock);
        }
        
    }
    public void OneWorkerBought() 
    {
        food -= 50;
    }

}

