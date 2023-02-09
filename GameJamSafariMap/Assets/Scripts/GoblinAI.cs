using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
            GameObject RealPlayer = GameObject.Find("Player");
            if (RealPlayer == null)
            {
                RealPlayer = GameObject.Find("Player(Clone)");
            }
            PlayerManager TheScript = RealPlayer.GetComponent<PlayerManager>();
            if (!TheScript.UsingMap)
            {
                int RowDiff = (Mathf.CeilToInt((transform.position.x) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.x * 2 / 5f));

                int ColumnDiff = (Mathf.CeilToInt((transform.position.z) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.z * 2 / 5f));

                if (RowDiff == 0 && ColumnDiff != 0)
                {
                    transform.position -= new Vector3(0, 0, ColumnDiff * 2.5f / Mathf.Abs(ColumnDiff));
                    transform.rotation = Quaternion.Euler(new Vector3(0, ColumnDiff / Mathf.Abs(ColumnDiff) * 90 + 90, 0));

                }

                if (ColumnDiff == 0 && RowDiff != 0)
                {
                    transform.position -= new Vector3(RowDiff * 2.5f / Mathf.Abs(RowDiff), 0, 0);
                    transform.rotation = Quaternion.Euler(new Vector3(0, -RowDiff / Mathf.Abs(RowDiff) * 90, 0));


                }
            }
        }
    }
 
    
       
    }

