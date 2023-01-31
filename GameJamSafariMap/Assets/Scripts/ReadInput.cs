using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{
    static private string input;
    void Awake()
    {
        GameObject Base = GameObject.Find("Base");
        if(Base!= null)
        {
            GenerateMap mapgen = Base.GetComponent<GenerateMap>();
            mapgen.mapSeed = input;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        input = s; 
        Debug.Log(input);
        SceneManager.LoadScene("LevelBuildingTesting");

    }
}
