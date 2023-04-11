using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data; 
    public GameObject mySphere;//prefab
    int rowCount; //variable 

    private float startDelay = 1.0f;
    private float timeInterval = 1.0f;
    public object tempObj;
    public float tempFloat;


    void Awake()
    {

        data = CSVReader.Read("testCO2");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("xco2 " + data[i]["xco2"] + " ");

        }
        rowCount = 0;


    }//end Awake()

    // Use this for initialization
    void Start()
    {
        if (rowCount <= 25990) { 
        InvokeRepeating("SpawnObject", startDelay, timeInterval);
    }
    }//end Start()

    // Update is called once per frame
    void SpawnObject()
    {
        //As long as cube count is not zero, instantiate prefab
        tempObj = (data[rowCount]["xco2"]);
        tempFloat = System.Convert.ToSingle(tempObj);
        tempFloat = (tempFloat - 400.0f);
        rowCount++;

        transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);

        Debug.Log("The tempfloat is " + tempFloat);
        Debug.Log("Count " + rowCount);
        

    }//end Update()
}