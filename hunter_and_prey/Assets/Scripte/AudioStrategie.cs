using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStrategie
{
    public AudioStrategie(AudioClip entdecktAudio, AudioClip aktionAudio)
    {
        this.entdecktAudio = entdecktAudio;
        this.aktionAudio = aktionAudio;
    }

    private AudioClip entdecktAudio;

    private AudioClip aktionAudio;

    public void AktionAusführen(AudioSource audioSource)
    {
        audioSource.clip = aktionAudio;
        audioSource.Play();
    }
    public void Aktion1Ausführen(AudioSource audioSource)
    {
        audioSource.clip = entdecktAudio;
        audioSource.Play();
    }
}
