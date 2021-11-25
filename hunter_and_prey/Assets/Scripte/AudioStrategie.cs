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

    private AudioSource audioSource;

    public void InitiereAudioStrategie(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }
    public void AktionAusf�hren()
    {
        audioSource.clip = aktionAudio;
        audioSource.Play();
    }
    public void Aktion1Ausf�hren()
    {
        audioSource.clip = entdecktAudio;
        audioSource.Play();
    }
}
