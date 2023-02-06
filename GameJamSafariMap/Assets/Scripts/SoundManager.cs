using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource mapOpenSound;
    [SerializeField]
    AudioSource mapCloseSound;
    [SerializeField]
    AudioSource playerJump;
    [SerializeField]
    AudioSource victoryJingle;
    [SerializeField]
    AudioSource gameOverJingle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound_MapOpen()
    {
        mapOpenSound.Play();
    }
    public void playSound_MapClose()
    {
        mapCloseSound.Play();
    }
    public void playSound_PlayerJump()
    {
        playerJump.Play();
    }
    public void playSound_VictoryJingle()
    {
        victoryJingle.Play();
    }
    public void playSound_GameOverJingle()
    {
        gameOverJingle.Play();
    }
}
