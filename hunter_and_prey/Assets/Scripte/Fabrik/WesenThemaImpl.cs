using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    public class WesenThemaImpl : IWesenThema
    {
        private AudioStrategie audioStrategie;
        private GameObject aussehen;
        private IBewegungsStrategie bewegungsStrategie;
        
        public WesenThemaImpl(AudioStrategie audioStrategie, GameObject aussehen, IBewegungsStrategie bewegungsStrategie)
        {
            this.audioStrategie = audioStrategie;
            this.aussehen = aussehen;
            this.bewegungsStrategie = bewegungsStrategie;
        }

        public AudioStrategie HoleAudioStrategie()
        {
            return audioStrategie;
        }

        public GameObject HoleAussehen()
        {
            return aussehen;
        }

        public IBewegungsStrategie HoleBewegungsStrategie()
        {
            return bewegungsStrategie;
        }
    }
}
