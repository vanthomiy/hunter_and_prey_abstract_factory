using Assets.Scripte.Fabrik;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Welt : MonoBehaviour
{
    public int BeuteAnzahl;
    public int JägerAnzahl;

    public int länge;
    public int breite;

    public List<JägerObjekt> jägerObekte = new List<JägerObjekt>();
    public List<BeuteObjekt> beuteObjekte = new List<BeuteObjekt>();

    public GameObject spielfeld;
    
    public GameObject jägerPrefab;
    public GameObject beutePrefab;

    private List<IThema> themen = new List<IThema>();


    private int aktuellesThema = 0;

    // Start is called before the first frame update
    void Start()
    {

        themen = new List<IThema> { new ThemaArktis(), new ThemaWald() };

        ErstelleJägerUndGejagte();
        SetzeThema();
    }

    private void ErstelleJägerUndGejagte()
    {
        for (int i = 0; i < JägerAnzahl; i++)
        {
            var jäger = Instantiate(jägerPrefab, this.transform);
            jäger.name = "Jäger " + i;
            jäger.transform.position = new Vector3(Random.Range(-breite / 2, breite / 2), 0, Random.Range(-länge / 2, länge / 2));

            jägerObekte.Add(jäger.GetComponent<JägerObjekt>());

        }

        for (int i = 0; i < BeuteAnzahl; i++)
        {
            var beute = Instantiate(beutePrefab, this.transform);
            beute.name = "Beute " + i;

            beute.transform.position = new Vector3(Random.Range(-breite / 2, breite / 2), 0, Random.Range(-länge / 2, länge / 2));

            beuteObjekte.Add(beute.GetComponent<BeuteObjekt>());

        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Setze neues thema");
            SetzeThema();
        }
    }

    private void SetzeThema()
    {
        var neuesThema = themen[aktuellesThema++];

        var jägerThema = neuesThema.LiefereJägerThema();
        var beuteThema = neuesThema.LiefereBeuteThema();
        var umweltThema = neuesThema.LiefereUmweltThema();


        foreach (Transform child in spielfeld.transform)
            Destroy(child.gameObject);

        Instantiate(umweltThema, spielfeld.transform);
        umweltThema.transform.localPosition = Vector3.zero;


        foreach (var jäger in jägerObekte)
        {
            jäger.SetzeThema(jägerThema);
        }

        foreach (var beute in beuteObjekte)
        {
            beute.SetzeThema(beuteThema);
        }

        if (aktuellesThema >= themen.Count)
        {
            aktuellesThema = 0;
        }

    }
}
