using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripte
{
    public class BeuteObjekt : WesenObjekt
    {

        void Update()
        {
            if (bewegungsStrategie != null && status != Status.Aktion)
            {
                switch (status)
                {
                    case Status.Standard:
                        bewegungsStrategie.BewegungStandard(this.gameObject, animator);
                        break;
                    case Status.Verfolgung:
                        bewegungsStrategie.BewegungVerfolgung(this.gameObject, animator, target.transform.position, themaGewechselt);
                        break;
                    case Status.ZurMitte:
                        bewegungsStrategie.BewegungZurMitte(this.gameObject, animator);
                        break;
                    default:
                        break;
                }
            }

            themaGewechselt = false;

            if (status == Status.Aktion && time < Time.time)
            {
                status = Status.Standard;

                var collider = GetComponent<SphereCollider>();
                collider.enabled = true;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("j�ger") && status != Status.Aktion)
            {
                Debug.Log("J�ger gefunden");
                target = other.gameObject;
                status = Status.Verfolgung;
                audioStrategie.EntdecktAusf�hren(GetComponent<AudioSource>());
            }

            if (other.CompareTag("grenze"))
            {
                target = null;
                status = Status.ZurMitte;
            }

            if (other.CompareTag("zentrum") && status == Status.ZurMitte)
            {
                status = Status.Standard;
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("grenze"))
            {
                status = Status.ZurMitte;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("j�ger") && other.gameObject == target)
            {
                Debug.Log("J�ger entkommen");
                target = null;
                status = Status.Standard;
            }
        }

        public override void AktionAusf�hren()
        {
            target = null;
            time = Time.time + warteZeit;
            status = Status.Aktion;

            var collider = GetComponent<SphereCollider>();
            collider.enabled = false;

            bewegungsStrategie.AktionAusf�hren(this.gameObject, animator);
            audioStrategie.AktionAusf�hren(GetComponent<AudioSource>());
        }
    }
}
