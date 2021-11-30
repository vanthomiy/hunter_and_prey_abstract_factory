using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripte
{
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
            if (audioSource.isPlaying)
            {
                return;
            }

            audioSource.clip = aktionAudio;
            audioSource.Play();
        }
        public void EntdecktAusführen(AudioSource audioSource)
        {
            if (audioSource.isPlaying)
            {
                return;
            }

            audioSource.clip = entdecktAudio;
            audioSource.Play();
        }
    }
}