using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopJumpingAnimation : MonoBehaviour
{
    
    Animator jumpAnimatorPlayer;
    Animator jumpAnimatorSheep;

    // Start is called before the first frame update
    void Start()
    {
        jumpAnimatorPlayer = GameObject.FindGameObjectWithTag("T_Player").GetComponentInChildren<Animator>();
        jumpAnimatorSheep = GameObject.FindGameObjectWithTag("T_Goal").GetComponentInChildren<Animator>();
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
}
