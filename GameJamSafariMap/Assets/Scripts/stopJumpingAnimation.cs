using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopJumpingAnimation : MonoBehaviour
{
    
    Animator jumpAnimatorPlayer;
    Animator jumpAnimatorSheep;
    Animator jumpAnimatorGoblin;

    // Start is called before the first frame update
    void Start()
    {
        jumpAnimatorPlayer = GameObject.FindGameObjectWithTag("T_Player").GetComponentInChildren<Animator>();
        jumpAnimatorSheep = GameObject.FindGameObjectWithTag("T_Goal").GetComponentInChildren<Animator>();
        jumpAnimatorGoblin = GameObject.FindGameObjectWithTag("T_Enemy").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationEndedPlayer()
    {
       // FindObjectOfType<PlayerManager>().MovementStopped();
        //jumpAnimatorPlayer.SetBool("isJumping", false);
    }
    public void AnimationEndedSheep()
    {
        jumpAnimatorSheep.SetBool("isJumping", false);
    }
    public void AnimationEndedGoblin()
    {
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject o in obj)
        {
            if (o.tag == "T_Enemy")
            {
                o.GetComponentInChildren<Animator>().SetBool("isJumping", false);
                //jumpAnimatorGoblin.SetBool("isJumping", false);

            }
        }
    }
}
