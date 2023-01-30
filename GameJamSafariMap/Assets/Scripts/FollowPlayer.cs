using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        if(Player!=null)
           transform.position = Player.transform.position+new Vector3(0,4.3f,-5.4f);
        else
        {
            Player = GameObject.Find("Player(Clone)");
            transform.position = Player.transform.position + new Vector3(0, 5.3f, -3.6f);

        }
    }
}
