using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public PlayerMovement playerReference;
    public AudioSource themeMusic;

    void FixedUpdate()
    {
        themeMusic.pitch = playerReference.pitchValue;
        if (playerReference.isDead == true) 
        {
            themeMusic.Stop();
        }
    }
}
