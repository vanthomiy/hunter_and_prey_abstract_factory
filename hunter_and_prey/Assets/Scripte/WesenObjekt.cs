using Assets.Scripte.Fabrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripte
{
    public class WesenObjekt : MonoBehaviour
    {
        public GameObject target;

        private GameObject aussehen;
        protected AudioStrategie audioStrategie;
        protected IBewegungsStrategie bewegungsStrategie;

        protected Animator animator;

        public Vector3 rotation;

        public int geschwindigkeit;
        public int warteZeit;

        protected bool aktion;

        protected float time;

        void Update()
        {
            if (bewegungsStrategie != null && !aktion)
            {
                Debug.Log(this.gameObject.name);
                if (target != null)
                {
                    Debug.Log("Bewege zu Ziel");
                    bewegungsStrategie.Bewege(animator, target, this.gameObject, geschwindigkeit);
                }
                else
                {
                    bewegungsStrategie.Bewege(animator, this.gameObject, geschwindigkeit);
                }
            }

            if (aktion && time < Time.time)
            {
                aktion = false;
                var collider = GetComponent<SphereCollider>();
                collider.enabled = true;
            }
        }



        public void SetzeThema(IWesenThema wesen)
        {
            if (aussehen != null)
            {
                Destroy(aussehen);
            }
            aussehen = Instantiate(wesen.HoleAussehen(), this.transform);
            aussehen.transform.localPosition = Vector3.zero;

            audioStrategie = wesen.HoleAudioStrategie();
            bewegungsStrategie = wesen.HoleBewegungsStrategie();

            animator = aussehen.GetComponent<Animator>();
            aussehen.GetComponent<Animator>().runtimeAnimatorController = bewegungsStrategie.LiefereAnimation();
        }

        public virtual void AktionAusführen() { }
    }
}
