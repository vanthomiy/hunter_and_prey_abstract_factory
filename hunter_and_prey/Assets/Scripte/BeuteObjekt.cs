using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeuteObjekt : WesenObjekt
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jäger") && !aktion)
        {
            Debug.Log("Jäger gefunden");
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("jäger"))
        {
            Debug.Log("Jäger entkommen");
            target = null;
        }
    }

    public override void AktionAusführen()
    {
        aktion = true;
        target = null;
        time = Time.time + warteZeit;

        var collider = GetComponent<SphereCollider>();
        collider.enabled = false;

        bewegungsStrategie.AktionAusführen(animator);
        audioStrategie.AktionAusführen(GetComponent<AudioSource>());
    }
}
