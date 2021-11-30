
using UnityEngine;

namespace Assets.Scripte.Fabrik
{
    internal class BeuteBewegungsStrategie : IBewegungsStrategie
    {
        public BeuteBewegungsStrategie(RuntimeAnimatorController animatorController, float geschwindigkeit, float höhe, float abstand)
        {
            this.animatorController = animatorController;
            this.geschwindigkeit = geschwindigkeit;
            this.abstand = abstand;
        }

        private RuntimeAnimatorController animatorController;
        private float geschwindigkeit;
        private float abstand;

        public float LiefereAbstand()
        {
            return this.abstand;
        }


        public void AktionAusführen(GameObject self, Animator animator)
        {
            animator.SetBool("sterben", true);
            animator.SetBool("rennen", false);
        }

        public RuntimeAnimatorController LiefereAnimation()
        {
            return animatorController;
        }

        public void BewegungStandard(GameObject self, Animator animator)
        {
            animator.SetBool("rennen", false);
            animator.SetBool("sterben", false);
        }

        public void BewegungVerfolgung(GameObject self, Animator animator, Vector3 targetPosition, bool themaGewechselt)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("sterben", false);
            animator.SetBool("umgeschaltet", themaGewechselt);

            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            {
                targetPosition = new Vector3(targetPosition.x, self.transform.position.y, targetPosition.z);

                var fluchtPosition = self.transform.position + Vector3.Normalize(self.transform.position - targetPosition) * 5;

                var targetRotation = Quaternion.LookRotation(fluchtPosition);
                self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
                self.transform.localEulerAngles = new Vector3(0, self.transform.localEulerAngles.y, 0);
                self.transform.position += self.transform.forward * geschwindigkeit * Time.deltaTime;
            }
        }

        public void BewegungZurMitte(GameObject self, Animator animator)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("sterben", false);

            var targetRotation = Quaternion.LookRotation(-self.transform.position);
            self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);

            self.transform.localEulerAngles = new Vector3(0, self.transform.localEulerAngles.y, 0);
            self.transform.position += self.transform.forward * geschwindigkeit * Time.deltaTime;
        }
    }
}
