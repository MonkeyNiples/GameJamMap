using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 _newPosition;
    bool _shouldMove;
    Animator jumpAnimator;
    // Start is called before the first frame update
    void Start()
    {
        jumpAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != _newPosition)
        {
            if (_shouldMove)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
            }
            
        }
        else { _shouldMove = false; }
    }
    public void movePlayer(Vector3 lastPosition, Vector3 newPosition)
    {
        _newPosition = newPosition;
        _shouldMove = true;
        jumpAnimator.SetBool("isJumping", true);

        transform.position = lastPosition;
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }
    
}
