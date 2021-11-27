using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaWaldJäger : IJägerThema
    {

        private WesenThemaImpl wesenThema = new WesenThemaImpl
            (
                new AudioStrategie(Resources.Load("Audio/WaldJägerEntdeckt") as AudioClip, Resources.Load("Audio/WaldJägerAktion") as AudioClip), Resources.Load("Aussehen/WaldJäger") as GameObject, new JägerBewegungsStrategie(Resources.Load("Bewegung/WaldJäger") as RuntimeAnimatorController, 4.5f, 0f, 1.5f)
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
