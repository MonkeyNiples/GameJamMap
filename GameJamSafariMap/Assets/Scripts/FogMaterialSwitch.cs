using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FogMaterialSwitch : MonoBehaviour
{
    public Material Transparent;
    public Material Soft_Fog;
    public Material Hard_Fog;

    private Vector3 BaseSize = new Vector3(2.5f,0,2.5f);
    // Start is called before the first frame update
    void Start()
    {
        GameObject RealPlayer = GameObject.Find("Player");
        UpdateShader();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            UpdateShader();
        }
    }

    private void UpdateShader()
    {
        
            GameObject RealPlayer = GameObject.Find("Player");

            int RowDiff = (Mathf.CeilToInt((transform.position.x ) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.x * 2 / 5f));

            int ColumnDiff = (Mathf.CeilToInt((transform.position.z) * 2f / 5)) - (Mathf.CeilToInt(RealPlayer.transform.position.z * 2 / 5f));

            if (RowDiff == 0 && ColumnDiff == 0)
                transform.GetComponent<MeshRenderer>().material = Transparent;
            else if (RowDiff > 1 || ColumnDiff > 1 || ColumnDiff < -1 || RowDiff < -1)
        {
            transform.GetComponent<MeshRenderer>().material = Hard_Fog;
            this.GetComponentInChildren<ParticleSystem>().Play();
        }
                
            else
            {
            transform.GetComponent<MeshRenderer>().material = Soft_Fog;
            this.GetComponentInChildren<ParticleSystem>().Stop();
            }
            

        
    }
}
