using Assets.Scripte.Fabrik;
using Assets.Scripte.Fabrik.Arktis;
using Assets.Scripte.Fabrik.Got;
using Assets.Scripte.Fabrik.Wald;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripte
{
    public class Welt : MonoBehaviour
    {
        public int BeuteAnzahl;
        public int J?gerAnzahl;

        public int l?nge;
        public int breite;

        public List<J?gerObjekt> j?gerObekte = new List<J?gerObjekt>();
        public List<BeuteObjekt> beuteObjekte = new List<BeuteObjekt>();

        public GameObject spielfeld;

        public GameObject j?gerPrefab;
        public GameObject beutePrefab;



        private int aktuellesThema = 0;


        private void ErstelleJ?gerUndGejagte()
        {
            for (int i = 0; i < J?gerAnzahl; i++)
            {
                var j?ger = Instantiate(j?gerPrefab, this.transform);
                j?ger.name = "J?ger " + i;
                j?ger.transform.position = new Vector3(Random.Range(-breite / 2, breite / 2), 0, Random.Range(-l?nge / 2, l?nge / 2));

                j?gerObekte.Add(j?ger.GetComponent<J?gerObjekt>());

            }

            for (int i = 0; i < BeuteAnzahl; i++)
            {
                var beute = Instantiate(beutePrefab, this.transform);
                beute.name = "Beute " + i;

                beute.transform.position = new Vector3(Random.Range(-breite / 2, breite / 2), 0, Random.Range(-l?nge / 2, l?nge / 2));

                beuteObjekte.Add(beute.GetComponent<BeuteObjekt>());

            }
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Setze neues thema");
                SetzeThema();
            }
        }

		private List<IThema> themen = new List<IThema>();
		
		// Start is called before the first frame update
        void Start()
        {

            themen = new List<IThema> { new ThemaArktis(), new ThemaWald(), new ThemaGot() };

            ErstelleJ?gerUndGejagte();
            SetzeThema();
        }

        private void SetzeThema()
        {
            var neuesThema = themen[aktuellesThema++];

            var j?gerThema = neuesThema.LiefereJ?gerThema();
            var beuteThema = neuesThema.LiefereBeuteThema();
            var umweltThema = neuesThema.LiefereUmweltThema();

            foreach (Transform child in spielfeld.transform)
                Destroy(child.gameObject);

            Instantiate(umweltThema, spielfeld.transform);
            umweltThema.transform.localPosition = Vector3.zero;


            foreach (var j?ger in j?gerObekte)
            {
                j?ger.SetzeThema(j?gerThema);
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
}