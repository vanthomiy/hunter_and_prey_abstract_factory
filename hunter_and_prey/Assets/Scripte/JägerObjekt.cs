using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JägerObjekt : WesenObjekt
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beute") && !aktion)
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
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (target != null)
        {
            var distanz = Vector3.Distance(this.transform.position, target.transform.position);

            if (distanz < 1f)
            {

                target.GetComponent<BeuteObjekt>().AktionAusführen();
                AktionAusführen();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("beute") && !aktion)
        {
            Debug.Log("Beute entkommen");

            if (target != null && other.gameObject == target)
            {
                target = null;
            }
        }
    }

    public override void AktionAusführen()
    {
        aktion = true;
        target = null;
        time = Time.time + warteZeit;

        bewegungsStrategie.AktionAusführen(animator);
        audioStrategie.AktionAusführen(GetComponent<AudioSource>());
    }

}
