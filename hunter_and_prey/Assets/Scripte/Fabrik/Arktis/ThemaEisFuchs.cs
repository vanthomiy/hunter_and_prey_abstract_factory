using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaEisFuchs : IJägerThema
    {

        private WesenThemaImpl wesenThema = new WesenThemaImpl
            (
                new AudioStrategie(null, null), Resources.Load("Aussehen/ArcticFox") as GameObject, new JägerBewegungsStrategie(Resources.Load("Bewegung/ArcticFox") as RuntimeAnimatorController, 3f, 0f, 1f)
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
