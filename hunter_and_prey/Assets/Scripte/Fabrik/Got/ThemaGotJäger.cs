using Assets.Scripte.Fabrik.Wald;

using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaGotJäger : IJägerThema
    {

        private WesenThemaImpl wesenThema = new WesenThemaImpl
            (
                new AudioStrategie(Resources.Load("Audio/GotJägerEntdeckt") as AudioClip, Resources.Load("Audio/GotJägerAktion") as AudioClip), Resources.Load("Aussehen/GotJäger") as GameObject, new JägerBewegungsStrategie(Resources.Load("Bewegung/GotJäger") as RuntimeAnimatorController, 6f, 3f, 4f)
            );

        public AudioStrategie HoleAudioStrategie()
        {
            return wesenThema.HoleAudioStrategie();
        }

        public GameObject HoleAussehen()
        {
            return wesenThema.HoleAussehen();
        }

        public IBewegungsStrategie HoleBewegungsStrategie()
        {
            return wesenThema.HoleBewegungsStrategie();
        }
    }
}
