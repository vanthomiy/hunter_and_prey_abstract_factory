using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripte
{
    public class WesenObjekt : MonoBehaviour
    {
        public GameObject target;

        private GameObject aussehen;
        private AudioStrategie audioStrategie;
        private IBewegungsStrategie bewegungsStrategie;

        public bool aktion;

        void Update()
        {
            if (bewegungsStrategie != null && !aktion)
            {
                if (target != null)
                {
                    Debug.Log("Bewege zu Ziel");
                    bewegungsStrategie.Bewege(target);
                }
                else
                {
                    bewegungsStrategie.Bewege();
                }
            }

            if (aktion)
            {
                AktionAusführen();
            }
        }

        public void SetzeThema(WesenImpl wesen)
        {
            if (aussehen != null)
            {
                Destroy(aussehen);
            }
            aussehen = Instantiate(wesen.aussehen, this.transform);
            
            audioStrategie = wesen.audioStrategie;
            bewegungsStrategie = wesen.bewegungsStrategie;
            
            bewegungsStrategie.InitiereBewegungsStrategie(aussehen.GetComponent<Animator>(), this.gameObject);
            audioStrategie.InitiereAudioStrategie(GetComponent<AudioSource>());

        }

        public void AktionAusführen()
        {
            bewegungsStrategie.AktionAusführen();
            audioStrategie.AktionAusführen();
        }

    }
}
