using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Sound;
    
    public void PlaySound()
    {
        Sound.Play();
    }
}
