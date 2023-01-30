using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTreeMesh : MonoBehaviour
{
    // Start is called before the first frame update
    public Mesh[] TreeMeshes;

    void Start()
    {
        GetComponent<MeshFilter>().mesh= TreeMeshes[Random.Range(0, TreeMeshes.Length)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
