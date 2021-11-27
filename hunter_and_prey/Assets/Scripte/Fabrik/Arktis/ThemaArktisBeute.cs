using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaArktisBeute : IBeuteThema
    {
        private WesenThemaImpl wesenThema = new WesenThemaImpl
        (
            new AudioStrategie(Resources.Load("Audio/ArktisBeuteEntdeckt") as AudioClip, Resources.Load("Audio/ArktisBeuteAktion") as AudioClip), Resources.Load("Aussehen/ArktisBeute") as GameObject, new BeuteBewegungsStrategie(Resources.Load("Bewegung/ArktisBeute") as RuntimeAnimatorController, 1.5f, 0f, 1f)
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
