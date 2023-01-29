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
    void Update()
    {
        GameObject RealPlayer = GameObject.Find("Player");

        int RowDiff = (Mathf.CeilToInt((transform.position.x) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.x * 2 / 5f));

        int ColumnDiff = (Mathf.CeilToInt((transform.position.z) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.z * 2 / 5f));

        if (RowDiff == 0 && (ColumnDiff == 1||ColumnDiff==-1))
        {
            transform.position+=new Vector3(0,0,ColumnDiff*2.5f);
            transform.rotation = Quaternion.Euler(new Vector3(0, -ColumnDiff*90+90, 0));

        }

        if ((RowDiff == 1 || RowDiff==-1 )&& ColumnDiff == 0)
        {
            transform.position += new Vector3( RowDiff * 2.5f,0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, RowDiff*90, 0));


        }
    }
}
