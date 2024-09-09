using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startButtonSound;
    public AudioClip creditButtonSound;
    
    public  void PlayStartButtonSound()
    {
        audioSource.PlayOneShot(startButtonSound);
    }
    public  void PlayCreditButtonSound()
    {
        audioSource.PlayOneShot(creditButtonSound);
    }
}
