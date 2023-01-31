using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundTreeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(0,-0.0001f,0);
    }
    private void OnCollisionEnter(Collision collission)
    {

            Destroy(gameObject);
    }

}
