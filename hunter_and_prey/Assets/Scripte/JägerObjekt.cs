using Assets.Scripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JägerObjekt : WesenObjekt
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beute"))
        {
            Debug.Log("Beute gefunden");
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("beute"))
        {
            Debug.Log("Beute entkommen");
            target = null;
        }
    }

}
