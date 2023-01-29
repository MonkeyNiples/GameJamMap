using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerOnMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private Vector3 GetPlayerLocation()
    {
        GameObject Base = GameObject.Find("Base");
        Vector3 BasePosition = Base.transform.position;
        GameObject RealPlayer = GameObject.Find("Player");
        Vector3 returnVector = RealPlayer.transform.position - BasePosition;
        returnVector = new Vector3(returnVector.x * 20, returnVector.z * 20);
        return returnVector;
    }
}
