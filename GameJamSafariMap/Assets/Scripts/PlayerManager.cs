using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool UsingMap = false;
    public int FacingDirection = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UsingMap = !UsingMap;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        CheckDirection();
       


        if (!UsingMap)
        {
            

            if (Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Return))
            {
                switch (FacingDirection)
                {
                    case 1: 
                        transform.transform.localPosition += new Vector3(0, 0, 2.5f);
                        break;

                    case 2:
                        transform.transform.localPosition += new Vector3(2.5f, 0, 0);
                        break;

                    case 3:
                        transform.transform.localPosition -= new Vector3(0, 0, 2.5f);
                        break;

                    case 4:
                        transform.transform.localPosition -= new Vector3(2.5f, 0, 0);
                        break;

                    default:
                        break;
                }
            }

        }

    }

    private void CheckDirection()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            FacingDirection = 1;
            transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FacingDirection = 3;
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));


        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A))
        {
            FacingDirection = 4;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));


        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            FacingDirection = 2;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));


        }
    }
}
