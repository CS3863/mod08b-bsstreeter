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
    int cubeCount; //variable 

    void Awake()
    {

        data = CSVReader.Read("udata");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("xco2 " + data[i]["xco2"] + " ");

        }


    }//end Awake()

    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < data.Count; i++)
        {
            object emis = data[i]["xco2"];//get age data
            cubeCount += (int)emis;//convert age data to int and add to cubeCount
            Debug.Log("cubeCount" +cubeCount);
        }
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        //As long as cube count is not zero, instantiate prefab
        while (cubeCount > 0)
        {
            Instantiate(mySphere);
            cubeCount--;
        }
        

    }//end Update()
}