using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int _rows;
    public int _columns;
    public Vector3 _baseSize;

    public GameObject _fog;
    public GameObject _tree;


    void Start()
    {
        //Vector3 AwayFromMiddle = new Vector3((int)(_rows / 2) * _baseSize.x,0, (int)(_columns / 2) * _baseSize.z);
        Vector3 TILEEXTRA = new Vector3(-5, 0, 5);

        GameObject fogDad = new GameObject();
        gameObject.transform.parent = transform;

        for (int i = 0; i < _rows; i++)
        {
            for( int j = 0; j < _columns; j++)
            {
                


                GameObject gameObject = Instantiate(_fog, transform.position, transform.rotation);
                gameObject.transform.position = new Vector3(i*_baseSize.x,2,-j*_baseSize.z)+TILEEXTRA +new Vector3(1.25f,0,1.25f);
                gameObject.transform.parent = fogDad.transform;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
