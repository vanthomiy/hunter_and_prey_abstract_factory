using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeuteObjekt : WesenObjekt
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("j�ger") && !aktion)
        {
            Debug.Log("J�ger gefunden");
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("j�ger"))
        {
            Debug.Log("J�ger entkommen");
            target = null;
        }
    }

    public override void AktionAusf�hren()
    {
        aktion = true;
        target = null;
        time = Time.time + warteZeit;

        var collider = GetComponent<SphereCollider>();
        collider.enabled = false;

        bewegungsStrategie.AktionAusf�hren(animator);
        audioStrategie.AktionAusf�hren(GetComponent<AudioSource>());
    }
}
