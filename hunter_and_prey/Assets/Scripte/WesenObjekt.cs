using Assets.Scripte.Fabrik;
using UnityEngine;

namespace Assets.Scripte
{
    public enum Status
    {
        Standard,
        Verfolgung,
        ZurMitte,
        Aktion
    }

    public class WesenObjekt : MonoBehaviour
    {
        public GameObject target;

        protected Status status;

        private GameObject aussehen;
        protected AudioStrategie audioStrategie;
        protected IBewegungsStrategie bewegungsStrategie;

        protected Animator animator;

        public Vector3 rotation;

        public int warteZeit;
        protected float time;
        protected bool themaGewechselt;

        public void SetzeThema(IWesenThema wesen)
        {
            if (aussehen != null)
            {
                Destroy(aussehen);
            }
            aussehen = Instantiate(wesen.HoleAussehen(), this.transform);
            aussehen.transform.localPosition = Vector3.zero;

            audioStrategie = wesen.HoleAudioStrategie();
            bewegungsStrategie = wesen.HoleBewegungsStrategie();

            animator = aussehen.GetComponent<Animator>();
            aussehen.GetComponent<Animator>().runtimeAnimatorController = bewegungsStrategie.LiefereAnimation();
            


            themaGewechselt = true;

            if (status == Status.Aktion)
            {
                bewegungsStrategie.AktionAusführen(this.gameObject, animator);
            }

        }

        public virtual void AktionAusführen() { }
    }
}
