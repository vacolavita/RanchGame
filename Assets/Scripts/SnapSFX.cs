using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSFX : MonoBehaviour
{
    public AudioSource snapSound;
    
    public void playSnapSound()
    {
        snapSound.Play();
    }
}
