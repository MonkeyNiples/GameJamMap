using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealTileMap : MonoBehaviour
{
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RevealPickup RevealScript = transform.parent.GetComponent<RevealPickup>();
        if (RevealScript.IsTriggered)
        {
            Destroy(gameObject);
        }
        else
        {
            timer++;
            gameObject.transform.RotateAround(transform.position, transform.up, 160 * Time.deltaTime);
            gameObject.transform.position += new Vector3(0, (Mathf.Sin(timer / 180f)) / 800, 0);

        }
    }
}
