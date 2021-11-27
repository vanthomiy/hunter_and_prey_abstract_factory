using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaGotBeute : IBeuteThema
    {
        private WesenThemaImpl wesenThema = new WesenThemaImpl
        (
            new AudioStrategie(Resources.Load("Audio/GotBeuteEntdeckt") as AudioClip, Resources.Load("Audio/GotBeuteAktion") as AudioClip), Resources.Load("Aussehen/GotBeute") as GameObject, new BeuteBewegungsStrategie(Resources.Load("Bewegung/GotBeute") as RuntimeAnimatorController, 3.5f, 0f, 4f)
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
