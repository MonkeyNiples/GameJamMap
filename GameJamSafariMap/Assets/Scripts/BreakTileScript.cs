using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Stage2Mat;

    public Mesh Stage1;
    public Mesh Stage2;
    private int stage = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collission)
    {
        if(stage == 0)
        {
            stage = 1;
            transform.GetComponent<MeshRenderer>().material = Stage2Mat;
            GetComponent<MeshFilter>().mesh = Stage1;
        }
        else 
        {
            stage = 2;
            GetComponent<MeshFilter>().mesh = Stage2;
            GetComponent<AudioSource>().Play();

            Destroy(collission.gameObject);
            if (collission.gameObject.tag == ("T_Goal")|| collission.gameObject.tag == ("T_Player"))
            {
                FindObjectOfType<SoundManager>().playSound_GameOverJingle();
                GameObject.Find("GameOverPanel").GetComponent<Animator>().SetBool("goUp", true);
            }
        }

    }
}
