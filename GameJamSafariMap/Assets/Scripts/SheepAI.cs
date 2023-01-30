using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            GameObject RealPlayer = GameObject.Find("Player");
            if (RealPlayer == null)
            {
                RealPlayer = GameObject.Find("Player(Clone)");
             }
            int RowDiff = (Mathf.CeilToInt((transform.position.x) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.x * 2 / 5f));

            int ColumnDiff = (Mathf.CeilToInt((transform.position.z) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.z * 2 / 5f));

            if (RowDiff == 0 && (ColumnDiff == 1 || ColumnDiff == -1))
            {
                if (AttemptMove(RowDiff, ColumnDiff)) { }
                else
                {
                    if (AttemptMove(1,0)) { }
                    else 
                    { 
                     AttemptMove(-1, 0);
                    }
                }
            }

            if ((RowDiff == 1 || RowDiff == -1) && ColumnDiff == 0)
            {
                if (AttemptMove(RowDiff, ColumnDiff)) { }
                else
                {
                    if (AttemptMove(0, 1)) { }
                    else
                    {
                        AttemptMove(0, -1);
                    }

                }
            }
        }
    }

    private bool AttemptMove(int v1, int v2)
    {
        bool isOccupied = false;
        GameObject[] RealTreeArray = GameObject.FindGameObjectsWithTag("T_ObstacleLand2");
        foreach (GameObject RealTree in RealTreeArray)
        {
            isOccupied = IsTileOccupied(RealTree, v2, v1);
            if (isOccupied)
            {
                Debug.Log($" sheep failed to move to {v2} {v1}");

                break;
            }
        }
        if (!isOccupied)
        {
            transform.position += new Vector3(v1 * 2.5f, 0, v2 * 2.5f);
            transform.rotation = Quaternion.Euler(new Vector3(0, v1 * 90 + (-v2 * 90 + 90 * Math.Abs(v2)), 0));
            Debug.Log($" sheep succesfully moved to {v2} {v1}");

        }
        return !isOccupied;
    }

    private bool IsTileOccupied(GameObject realTree, int v1, int v2)
    {
        int RowDiff = (Mathf.CeilToInt((realTree.transform.position.z - 1.5f) * 2f / 5)) - (Mathf.CeilToInt(transform.position.z * 2 / 5f));
        int ColumnDiff = (Mathf.CeilToInt((realTree.transform.position.x + 1.5f) * 2f / 5)) - (Mathf.CeilToInt(transform.position.x * 2 / 5f));
        if (ColumnDiff == v2 && RowDiff == v1)
        {
            Debug.Log($" not allowed sheep, column {ColumnDiff}, row {RowDiff}");
            return true;
        }
        return false;
    }
}
