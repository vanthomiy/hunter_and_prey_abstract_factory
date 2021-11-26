using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaWaldBeute : IBeuteThema
    {
        private WesenThemaImpl wesenThema = new WesenThemaImpl
        (
            new AudioStrategie(null, null), Resources.Load("Aussehen/WaldBeute") as GameObject, new BeuteBewegungsStrategie(Resources.Load("Bewegung/WaldBeute") as RuntimeAnimatorController, 3.5f, 0f, 1.5f)
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
