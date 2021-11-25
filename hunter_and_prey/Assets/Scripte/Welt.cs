using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Welt : MonoBehaviour
{


    public GameObject j�gerPrefab;
    public GameObject beutePrefab;

    public AudioClip clipPrefab;

    public List<GameObject> aussehenJ�gerPrefab = new List<GameObject>();
    public List<GameObject> aussehenBeutePrefab = new List<GameObject>();
    public List<J�gerObjekt> j�gerObekte = new List<J�gerObjekt>();
    public List<BeuteObjekt> beuteObjekte = new List<BeuteObjekt>();
    public List<J�gerBewegungsStrategie> j�gerBewegung = new List<J�gerBewegungsStrategie>();
    public List<BeuteBewegungsStrategie> beuteBewegung = new List<BeuteBewegungsStrategie>();
    public List<AnimatorController> animationBeuteController = new List<AnimatorController>();
    public List<AnimatorController> animationJ�gerController = new List<AnimatorController>();

    // Start is called before the first frame update
    void Start()
    {
        j�gerBewegung.Add(new J�gerBewegungsStrategie(5, animationJ�gerController[0]));
        j�gerBewegung.Add(new J�gerBewegungsStrategie(5, animationJ�gerController[1]));

        beuteBewegung.Add(new BeuteBewegungsStrategie(0.5f, animationBeuteController[0]));
        beuteBewegung.Add(new BeuteBewegungsStrategie(2, animationBeuteController[1]));

        WesenImpl w�stenThemaJ�ger = new WesenImpl();
        w�stenThemaJ�ger.aussehen = aussehenJ�gerPrefab[aussehen];
        w�stenThemaJ�ger.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
        w�stenThemaJ�ger.bewegungsStrategie = j�gerBewegung[aussehen];

        WesenImpl w�stenThemaBeute = new WesenImpl();
        w�stenThemaBeute.aussehen = aussehenBeutePrefab[aussehen];
        w�stenThemaBeute.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
        w�stenThemaBeute.bewegungsStrategie = beuteBewegung[aussehen];

        foreach (var j�ger in j�gerObekte)
        {
            j�ger.SetzeThema(w�stenThemaJ�ger);
        }

        foreach (var neute in beuteObjekte)
        {
            neute.SetzeThema(w�stenThemaBeute);
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

            WesenImpl w�stenThema = new WesenImpl();
            w�stenThema.aussehen = aussehenPrefab[aussehen];
            w�stenThema.audioStrategie = new AudioStrategie(clipPrefab, clipPrefab);
            w�stenThema.bewegungsStrategie = j�gerBewegung[aussehen++];

            foreach (var j�ger in j�gerObekte)
            {
                j�ger.SetzeThema(w�stenThema);
            }

            if (aussehen >= aussehenPrefab.Count)
            {
                aussehen = 0;
            }
        }*/

    }
}
