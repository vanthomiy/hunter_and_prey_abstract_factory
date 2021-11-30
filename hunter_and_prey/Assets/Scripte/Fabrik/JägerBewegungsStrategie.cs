using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class JägerBewegungsStrategie : IBewegungsStrategie
    {
        public JägerBewegungsStrategie(RuntimeAnimatorController animatorController, float geschwindigkeit, float höhe, float abstand)
        {
            this.animatorController = animatorController;
            this.geschwindigkeit = geschwindigkeit;
            this.höhe = höhe;
            this.abstand = abstand;
        }

        private RuntimeAnimatorController animatorController;
        private float geschwindigkeit;
        private float höhe;
        private float abstand;

        public float LiefereAbstand()
        {
            return this.abstand;
        }

        public void AktionAusführen(GameObject self, Animator animator)
        {
            animator.SetBool("rennen", false);
            animator.SetBool("fressen", true);
            animator.SetBool("laufen", false);

        }

        public RuntimeAnimatorController LiefereAnimation()
        {
            return animatorController;
        }

        public void BewegungStandard(GameObject self, Animator animator)
        {
            var laufGeschwinndigkeit = geschwindigkeit / 4;

            animator.SetBool("rennen", false);
            animator.SetBool("fressen", false);
            animator.SetBool("laufen", true);

            var moveRotation = self.GetComponent<JägerObjekt>().rotation;

            if (Random.Range(0, 200) < 5)
            {
                moveRotation = self.GetComponent<JägerObjekt>().rotation = self.transform.localEulerAngles + new Vector3(0, (Random.value - 0.5f) * 180, 0);
            }

            var desiredRotQ = Quaternion.Euler(moveRotation);
            self.transform.rotation = Quaternion.Lerp(self.transform.rotation, desiredRotQ, Time.deltaTime * laufGeschwinndigkeit);
            
            self.transform.position = new Vector3(self.transform.position.x, höhe, self.transform.position.z);

            self.transform.localEulerAngles = new Vector3(0, self.transform.localEulerAngles.y, 0);
            self.transform.position += self.transform.forward * laufGeschwinndigkeit * Time.deltaTime;
        }

        public void BewegungVerfolgung(GameObject self, Animator animator, Vector3 targetPosition, bool themaGewechselt)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("fressen", false);
            animator.SetBool("laufen", false);

            var targetRotation = Quaternion.LookRotation(targetPosition - self.transform.position);
            self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);

            //var aktuelleHöhe = Mathf.Lerp(self.transform.position.y, höhe, Time.deltaTime * geschwindigkeit);
            self.transform.position = new Vector3(self.transform.position.x, höhe, self.transform.position.z);

            self.transform.localEulerAngles = new Vector3(0, self.transform.localEulerAngles.y, 0);
            self.transform.position += self.transform.forward * geschwindigkeit * Time.deltaTime;
        }

        public void BewegungZurMitte(GameObject self, Animator animator)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("fressen", false);
            animator.SetBool("laufen", false);

            self.transform.position = new Vector3(self.transform.position.x, höhe, self.transform.position.z);


            var targetRotation = Quaternion.LookRotation(-self.transform.position);
            self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
            
            self.transform.localEulerAngles = new Vector3(0, self.transform.localEulerAngles.y, 0);
            self.transform.position += self.transform.forward * geschwindigkeit * Time.deltaTime;
        }
    }
}
