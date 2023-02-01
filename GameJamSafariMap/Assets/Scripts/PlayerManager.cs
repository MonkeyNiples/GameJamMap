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
    public bool isMoving;
    bool _hasWon;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("T_Goal") && _hasWon == false)
        {
            FindObjectOfType<SoundManager>().playSound_VictoryJingle();
            GameObject.Find("VictoryPanel").GetComponent<Animator>().SetBool("goUp",true);
            _hasWon = true; //implemented so that victory jingle doesnt play multiple times (every time player collides with sheep)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UsingMap = !UsingMap;
            if (!UsingMap)
                FindObjectOfType<SoundManager>().playSound_MapClose();
            else
                FindObjectOfType<SoundManager>().playSound_MapOpen();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        if(!isMoving)
             CheckDirection();
       


        if (!UsingMap)
        {
            

            if (Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Return))
            {
                GameObject[] RealTreeArray = GameObject.FindGameObjectsWithTag("T_ObstacleLand2");
                bool isOccupied = false;
                switch (FacingDirection)
                {
                   
                    case 1:
                        foreach (GameObject RealTree in RealTreeArray)
                        {
                            isOccupied = IsTileOccupied(RealTree, 1, 0);
                            if (isOccupied)
                            {
                                break;
                            }
                        }
                        if (!isOccupied)
                        {
                            transform.transform.localPosition += new Vector3(0, 0, 2.5f);
                            GetComponentInChildren<SmoothMovement>().movePlayer(new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z -2.5f), new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z ), this.gameObject);
                            FindObjectOfType<SoundManager>().playSound_PlayerJump();
                            isMoving = true;
                        }
                        break;

                    case 2:
                        foreach (GameObject RealTree in RealTreeArray)
                        {
                            isOccupied = IsTileOccupied(RealTree, 0, 1);
                            if (isOccupied)
                            {
                                break;
                            }
                        }
                        if (!isOccupied)
                        {
                            transform.transform.localPosition += new Vector3(2.5f, 0, 0);
                            GetComponentInChildren<SmoothMovement>().movePlayer(new Vector3(transform.transform.localPosition.x - 2.5f, transform.transform.localPosition.y, transform.transform.localPosition.z ), new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z), this.gameObject);
                            FindObjectOfType<SoundManager>().playSound_PlayerJump();
                            isMoving = true;
                        }

                        break;

                    case 3:
                        foreach (GameObject RealTree in RealTreeArray)
                        {
                            isOccupied = IsTileOccupied(RealTree,-1 , 0);
                            if (isOccupied)
                            {
                                break;
                            }
                        }
                        if (!isOccupied)
                        {
                            transform.transform.localPosition -= new Vector3(0, 0, 2.5f);
                            GetComponentInChildren<SmoothMovement>().movePlayer(new Vector3(transform.transform.localPosition.x , transform.transform.localPosition.y, transform.transform.localPosition.z + 2.5f), new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z), this.gameObject);
                            FindObjectOfType<SoundManager>().playSound_PlayerJump();
                            isMoving = true;
                        }
                        break;

                    case 4:
                        foreach (GameObject RealTree in RealTreeArray)
                        {
                            isOccupied = IsTileOccupied(RealTree, 0, -1);
                            if (isOccupied)
                            {
                                break;
                            }
                        }
                        if (!isOccupied)
                        {
                            transform.transform.localPosition -= new Vector3(2.5f, 0, 0);
                            GetComponentInChildren<SmoothMovement>().movePlayer(new Vector3(transform.transform.localPosition.x + 2.5f, transform.transform.localPosition.y, transform.transform.localPosition.z ), new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z), this.gameObject);
                            FindObjectOfType<SoundManager>().playSound_PlayerJump();
                            isMoving = true;
                        }
                        break;

                    default:
                        break;
                }
            }

        }

    }

    private bool IsTileOccupied(GameObject realTree, int v1, int v2)
    {
        int RowDiff = (Mathf.CeilToInt((realTree.transform.position.z-1.5f) * 2f / 5)) - (Mathf.CeilToInt(transform.position.z * 2 / 5f));
        int ColumnDiff = (Mathf.CeilToInt((realTree.transform.position.x + 1.5f) * 2f / 5)) - (Mathf.CeilToInt(transform.position.x * 2 / 5f));
        if (ColumnDiff == v2 && RowDiff == v1)
        {
            Debug.Log($" not allowed, column {ColumnDiff}, row {RowDiff}");
            return true;
        }
        return false;
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
    public void MovementStopped() //called when the player has reached the next tile (the smooth movement has ended)
    {
        isMoving = false;
    }
}
