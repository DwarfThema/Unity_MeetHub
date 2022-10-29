using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string GameSeed = "Default";
    public int CurrentSeed = 0;

    public string temperature = "19.9°C";
    public string weather = "Clouds";
    public string location = "Seongnam-si";

    public string date = "10/29/2022";
    string year;
    string month;
    string day;

    public string username = "username";
    public string commit;

    public MeshRenderer groundMtl;

    public int zoneSize;

    GameObject[] LawnOBJ;
    int LawnCount;
    GameObject LawnSelected;

    GameObject[] FlowerOBJ;
    int FlowerCount;
    GameObject FlowerSelected;

    GameObject[] TreeOBJ;
    int TreeCount;
    GameObject TreeSelected;


    public GameObject ui;



    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        LawnOBJ = new GameObject[2];
        FlowerOBJ = new GameObject[1];
        TreeOBJ = new GameObject[2];
    }



    public void GetTemperature(string getTemperature)
    {
        temperature = getTemperature;
    }

    public void GetWeather(string getWeather)
    {
        weather = getWeather;
    }

    public void GetLocation(string getLocation)
    {
        location = getLocation;
    }

    public void GetDate(string getDate)
    {
        Refreash();

        string[] dateData = getDate.Split("/");
        month = dateData[0];
        day = dateData[1];
        year = dateData[2];

        Debug.Log(month);
        Debug.Log(day);
        Debug.Log(year);


        //string[] dateDotData = dateData[2].Split(".");

        Weatehr();
        //Spawn();
    }

    public void GetUsername(string getUsername)
    {
        username = getUsername;
    }

    public void GetCommit(string getStringCommit)
    {
        commit = getStringCommit;
        Spawn();
    }

    public void Refreash()
    {
        Transform[] childList = this.GetComponentsInChildren<Transform>();

        if(childList != null)
        {
            for(int i = 1; i<childList.Length; i++)
            {
                if (childList[i] != this.transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
    }




    void Start()
    {
        //GetDate(date);
        //GetCommit(commit);
        //GetUsername(username);
        // GetTemperature(temperature);
        // GetWeather(weather);
        // GetLocation(location);

    }

    private void Update()
    {

    }

    public void Weatehr()
    {

        if (month == "03" || month == "04" || month == "05")
        {
            Debug.Log(LawnOBJ.Length);
            Debug.Log("봄");
            groundMtl.material = Resources.Load("1Spring/Ground_SP") as Material;
            LawnOBJ[0] = Resources.Load("1Spring/Lawn/LawnA") as GameObject;
            LawnOBJ[1] = Resources.Load("1Spring/Lawn/LawnB") as GameObject;

            FlowerOBJ[0] = Resources.Load("1Spring/Flower/Flower") as GameObject;

            TreeOBJ[0] = Resources.Load("1Spring/Tree/TreeA") as GameObject;
            TreeOBJ[1] = Resources.Load("1Spring/Tree/TreeB") as GameObject;

        }
        else if (month == "06" || month == "07" || month == "08")
        {
            Debug.Log("여름");
            groundMtl.material = Resources.Load("2Summer/Ground_SM") as Material;

            LawnOBJ[0] = Resources.Load("2Summer/Lawn/LawnA") as GameObject;
            LawnOBJ[1] = Resources.Load("2Summer/Lawn/LawnB") as GameObject;

            FlowerOBJ[0] = Resources.Load("2Summer/Flower/Flower") as GameObject;

            TreeOBJ[0] = Resources.Load("2Summer/Tree/TreeA") as GameObject;
            TreeOBJ[1] = Resources.Load("2Summer/Tree/TreeB") as GameObject;
        }
        else if (month == "09" || month == "10" || month == "11")
        {
            Debug.Log("가을");
            groundMtl.material = Resources.Load("3Fall/Ground_FL") as Material;

            LawnOBJ[0] = Resources.Load("3Fall/Lawn/LawnA") as GameObject;
            LawnOBJ[1] = Resources.Load("3Fall/Lawn/LawnB") as GameObject;

            FlowerOBJ[0] = Resources.Load("3Fall/Flower/Flower") as GameObject;

            TreeOBJ[0] = Resources.Load("3Fall/Tree/TreeA") as GameObject;
            TreeOBJ[1] = Resources.Load("3Fall/Tree/TreeB") as GameObject;
        }
        else if (month == "12" || month == "01" || month == "02")
        {
            Debug.Log("겨울");
            groundMtl.material = Resources.Load("4Winter/Ground_WT") as Material;

            LawnOBJ[0] = Resources.Load("4Winter/Lawn/LawnA") as GameObject;
            LawnOBJ[1] = Resources.Load("4Winter/Lawn/LawnB") as GameObject;

            FlowerOBJ[0] = Resources.Load("4Winter/Flower/Flower") as GameObject;

            TreeOBJ[0] = Resources.Load("4Winter/Tree/TreeA") as GameObject;
            TreeOBJ[1] = Resources.Load("4Winter/Tree/TreeB") as GameObject;
        }
    }


    public void Spawn()
    {
        LawnCount = int.Parse(commit);
        for (int i = 0; i < LawnCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * zoneSize;
            pos.y = 0;
            GameObject LawnSelected = LawnOBJ[Random.Range(0, LawnOBJ.Length)];

            GameObject lawn = Instantiate(LawnSelected, pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
            lawn.transform.parent = gameObject.transform;

        }

        FlowerCount = LawnCount / 10;
        for (int i = 0; i < FlowerCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * zoneSize;
            pos.y = 0;
            GameObject FlowerSelected = FlowerOBJ[Random.Range(0, FlowerOBJ.Length)];

            GameObject flower = Instantiate(FlowerSelected, pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
            flower.transform.parent = gameObject.transform;

        }

        TreeCount = LawnCount / 100;
        for (int i = 0; i < TreeCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * zoneSize;
            pos.y = 0;
            GameObject TreeSelected = TreeOBJ[Random.Range(0, TreeOBJ.Length)];

            GameObject tree = Instantiate(TreeSelected, pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
            tree.transform.parent = gameObject.transform;

        }
    }


}
