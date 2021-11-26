using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaSchneeHase : IBeuteThema
    {
        private WesenThemaImpl wesenThema = new WesenThemaImpl
        (
            new AudioStrategie(null, null), Resources.Load("Aussehen/ArcticRabbit") as GameObject, new BeuteBewegungsStrategie(Resources.Load("Bewegung/ArcticRabbit") as RuntimeAnimatorController, 1.5f, 0f, 1f)
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
