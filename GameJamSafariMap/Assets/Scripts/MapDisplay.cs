using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Transparant;
    public Material Map;

    public bool UsingMap;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UsingMap = !UsingMap;
            if (UsingMap)
            {
                transform.GetComponent<MeshRenderer>().material = Map;

            }
            else
            {
                transform.GetComponent<MeshRenderer>().material = Transparant;

            }
        }

    }
}
