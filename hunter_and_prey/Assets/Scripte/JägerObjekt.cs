using Assets.Scripte;
using Assets.Scripte.Fabrik;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JägerObjekt : WesenObjekt
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

        if (status == Status.Aktion && time < Time.time)
        {
            status = Status.Standard;

            var collider = GetComponent<SphereCollider>();
            collider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beute") && status != Status.Aktion)
        {
            Debug.Log("Beute gefunden");

            if (target == null)
            {
                target = other.gameObject;
                return;
            }
            
            var aktuelleDistanz = Vector3.Distance(this.transform.position, target.transform.position);
            var neueDistanz = Vector3.Distance(this.transform.position, other.transform.position);

            if (aktuelleDistanz > neueDistanz)
            {
                target = other.gameObject;
            }

            status = Status.Verfolgung;
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
        if (target != null)
        {
            var distanz = Vector3.Distance(this.transform.position, target.transform.position);

            if (distanz < bewegungsStrategie.LiefereAbstand())
            {
                target.GetComponent<BeuteObjekt>().AktionAusführen();
                AktionAusführen();
            }
        }

        if (other.CompareTag("grenze"))
        {
            status = Status.ZurMitte;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("beute") && status != Status.Aktion)
        {
            Debug.Log("Beute entkommen");

            if (target != null && other.gameObject == target)
            {
                target = null;
                status = Status.Standard;
            }
        }
    }

    public override void AktionAusführen()
    {
        target = null;
        time = Time.time + warteZeit;
        status = Status.Aktion;

        bewegungsStrategie.AktionAusführen(this.gameObject, animator);
        audioStrategie.AktionAusführen(GetComponent<AudioSource>());
    }

}
