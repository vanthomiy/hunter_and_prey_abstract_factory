using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripte.Fabrik.Wald
{
    internal class JägerBewegungsStrategie : IBewegungsStrategie
    {
        public JägerBewegungsStrategie(AnimatorController animatorController, float geschwindigkeit)
        {
            this.animatorController = animatorController;
            this.geschwindigkeit = geschwindigkeit;
        }

        private AnimatorController animatorController;
        private float geschwindigkeit;

        public void Bewege(Animator animator, GameObject jäger)
        {
            var laufGeschwinndigkeit = geschwindigkeit / 4;

            animator.SetBool("rennen", false);
            animator.SetBool("fressen", false);
            animator.SetBool("laufen", true);

            var moveRotation = jäger.GetComponent<JägerObjekt>().rotation;

            if (Random.Range(0, 200) < 5)
            {
                moveRotation = jäger.GetComponent<JägerObjekt>().rotation = jäger.transform.localEulerAngles + new Vector3(0, (Random.value - 0.5f) * 180, 0);
            }

            //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit / 6, aktuelleGeschwindigkeit * Time.deltaTime);

            var desiredRotQ = Quaternion.Euler(moveRotation);
            jäger.transform.rotation = Quaternion.Lerp(jäger.transform.rotation, desiredRotQ, Time.deltaTime * laufGeschwinndigkeit);
            jäger.transform.position += jäger.transform.forward * laufGeschwinndigkeit * Time.deltaTime;

        }

        public void Bewege(Animator animator, Vector3 targetPosition, GameObject jäger)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("fressen", false);
            animator.SetBool("laufen", false);

            //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit, aktuelleGeschwindigkeit * Time.deltaTime);

            var targetRotation = Quaternion.LookRotation(targetPosition - jäger.transform.position);
            jäger.transform.rotation = Quaternion.Slerp(jäger.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
            jäger.transform.position += jäger.transform.forward * geschwindigkeit * Time.deltaTime;

            //Debug.Log("Bewege zu " + target.transform.position);
        }

        public void AktionAusführen(Animator animator)
        {
            animator.SetBool("rennen", false);
            animator.SetBool("fressen", true);
            animator.SetBool("laufen", false);
        }

        public void Bewege(GameObject self)
        {
            var fluchtPosition = self.transform.position + Vector3.Normalize(self.transform.position - Vector3.zero) * 5;

            self.transform.LookAt(fluchtPosition);
            self.transform.position = Vector3.MoveTowards(self.transform.position, fluchtPosition, geschwindigkeit * Time.deltaTime);
        }

        public AnimatorController LiefereAnimation()
        {
            return animatorController;
        }
    }
}
