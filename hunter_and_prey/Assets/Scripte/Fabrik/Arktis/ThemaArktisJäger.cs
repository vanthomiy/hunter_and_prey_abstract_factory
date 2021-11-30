using Assets.Scripte.Fabrik.Wald;
using UnityEngine;

namespace Assets.Scripte.Fabrik.Arktis
{
    internal class ThemaArktisJäger : IJägerThema
    {

        private WesenThemaImpl wesenThema = new WesenThemaImpl
            (
                new AudioStrategie(Resources.Load("Audio/ArktisJägerEntdeckt") as AudioClip , Resources.Load("Audio/ArktisJägerAktion") as AudioClip), Resources.Load("Aussehen/ArktisJäger") as GameObject, new JägerBewegungsStrategie(Resources.Load("Bewegung/ArktisJäger") as RuntimeAnimatorController, 3f, 0f, 1f)
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
