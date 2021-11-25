using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class ThemaWaldFuchs : IJägerThema
    {

        private WesenThemaImpl wesenThema = new WesenThemaImpl
            (
                new AudioStrategie(null, null), Resources.Load("Aussehen/WaldFox") as GameObject, new JägerBewegungsStrategie(Resources.Load("Bewegung/WaldFox") as AnimatorController)
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
