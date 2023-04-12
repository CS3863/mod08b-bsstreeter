using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Buffers.Text;
using Unity.VisualScripting;

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
//https://daac.ornl.gov/cgi-bin/dsviewer.pl?ds_id=1831


//Ground - based Observations of XCO2, XCH4, and XCO, Fairbanks, AK, 2016-2019

//Description
//This dataset provides ground-based column-averaged dry mole fractions (DMFs) of CO2(xco2), CO(xco), CH4(xch4), and N2O(xn2o) to supplement satellite-based observations of carbon dynamics of northern boreal ecosystems. Measurements were conducted with Bruker EM27/SUN Fourier transform spectrometers (FTS) at the University of Alaska Fairbanks (UAF) and two sites on the edges of the Tanana Flats wetlands to the south from 2016-08-04 to 2019-10-31. Single detectors were used during the first campaign at UAF in 2017, then two instruments were updated to dual detectors in early 2018 to allow retrieval of xco and xn2o. Data from additional FTS instruments, operated by Los Alamos National Laboratories (LANL), Karlsruhe Institute of Technology (KIT), and Jet Propulsion Laboratory (JPL), employed in these campaigns are included.


//Data Use and Citation
//Download citation from Datacite
//RISBibTexOther
//Crosscite Citation Formatter
//Jacobs, N., W.R. Simpson, F. Hase, T. Blumenstock, Q. Tu, M. Frey, M.K. Dubey, and H.A. Parker. 2021. Ground-based Observations of XCO2, XCH4, and XCO, Fairbanks, AK, 2016-2019. ORNL DAAC, Oak Ridge, Tennessee, USA. https://doi.org/10.3334/ORNLDAAC/1831
//This dataset is openly shared, without restriction, in accordance with the EOSDIS Data Use Policy. 
