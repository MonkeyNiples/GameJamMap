using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player!=null)
           transform.position = Player.transform.position+new Vector3(0,4.3f,-5.4f);
        else
        {
            Player = GameObject.Find("Player(Clone)");
            transform.position = Player.transform.position + new Vector3(0, 5.3f, -3.6f);

        }
    }
}
