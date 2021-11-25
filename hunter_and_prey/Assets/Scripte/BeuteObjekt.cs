using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeuteObjekt : WesenObjekt
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jäger"))
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


}
