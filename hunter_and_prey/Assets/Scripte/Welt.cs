using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Welt : MonoBehaviour
{


    public GameObject jägerPrefab;
    public GameObject beutePrefab;

    public AudioClip clipPrefab;

    public List<GameObject> aussehenJägerPrefab = new List<GameObject>();
    public List<GameObject> aussehenBeutePrefab = new List<GameObject>();
    public List<JägerObjekt> jägerObekte = new List<JägerObjekt>();
    public List<BeuteObjekt> beuteObjekte = new List<BeuteObjekt>();
    public List<JägerBewegungsStrategie> jägerBewegung = new List<JägerBewegungsStrategie>();
    public List<BeuteBewegungsStrategie> beuteBewegung = new List<BeuteBewegungsStrategie>();
    public List<AnimatorController> animationBeuteController = new List<AnimatorController>();
    public List<AnimatorController> animationJägerController = new List<AnimatorController>();

    // Start is called before the first frame update
    void Start()
    {
        jägerBewegung.Add(new JägerBewegungsStrategie(5, animationJägerController[0]));
        jägerBewegung.Add(new JägerBewegungsStrategie(5, animationJägerController[1]));

        beuteBewegung.Add(new BeuteBewegungsStrategie(0.5f, animationBeuteController[0]));
        beuteBewegung.Add(new BeuteBewegungsStrategie(2, animationBeuteController[1]));

        WesenImpl wüstenThemaJäger = new WesenImpl();
        wüstenThemaJäger.aussehen = aussehenJägerPrefab[aussehen];
        wüstenThemaJäger.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
        wüstenThemaJäger.bewegungsStrategie = jägerBewegung[aussehen];

        WesenImpl wüstenThemaBeute = new WesenImpl();
        wüstenThemaBeute.aussehen = aussehenBeutePrefab[aussehen];
        wüstenThemaBeute.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
        wüstenThemaBeute.bewegungsStrategie = beuteBewegung[aussehen];

        foreach (var jäger in jägerObekte)
        {
            jäger.SetzeThema(wüstenThemaJäger);
        }

        foreach (var neute in beuteObjekte)
        {
            neute.SetzeThema(wüstenThemaBeute);
        }

    }

    float time = 0;
    float time1 = 0;

    int aussehen = 0;


    // Update is called once per frame
    void Update()
    {
        /*
        if (time < Time.time)
        {
            time = Time.time + 3;

            WesenImpl wüstenThema = new WesenImpl();
            wüstenThema.aussehen = aussehenPrefab[aussehen];
            wüstenThema.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
            wüstenThema.bewegungsStrategie = jägerBewegung[aussehen++];

            foreach (var jäger in jägerObekte)
            {
                jäger.SetzeThema(wüstenThema);
            }

            if (aussehen >= aussehenPrefab.Count)
            {
                aussehen = 0;
            }
        }*/

    }
}
