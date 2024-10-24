using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // Ses kaynaðýný buraya ekleyin

    void Start()
    {
        // Oyunun baþladýðýnda sesi çal
        audioSource.Play();
    }

    public void PlaySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
