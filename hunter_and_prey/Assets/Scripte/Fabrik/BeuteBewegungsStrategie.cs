using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripte.Fabrik.Wald
{
    internal class BeuteBewegungsStrategie : IBewegungsStrategie
    {
        public BeuteBewegungsStrategie(AnimatorController animatorController, float geschwindigkeit)
        {
            this.animatorController = animatorController;
            this.geschwindigkeit = geschwindigkeit;
        }

        private AnimatorController animatorController;
        private float geschwindigkeit;

        public void Bewege(Animator animator, GameObject self)
        {
            animator.SetBool("rennen", false);
            animator.SetBool("sterben", false);
        }

        public void Bewege(Animator animator, Vector3 targetPosition, GameObject beute)
        {
            animator.SetBool("rennen", true);
            animator.SetBool("sterben", false);

            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            {

                var fluchtPosition = beute.transform.position + Vector3.Normalize(beute.transform.position - targetPosition) * 5;

                var targetRotation = Quaternion.LookRotation(fluchtPosition);
                beute.transform.rotation = Quaternion.Slerp(beute.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
                beute.transform.position += beute.transform.forward * geschwindigkeit * Time.deltaTime;

                /*var fluchtPosition = beute.transform.position + Vector3.Normalize(beute.transform.position - targetPosition) * 5;

                beute.transform.LookAt(fluchtPosition);
                beute.transform.position = Vector3.MoveTowards(beute.transform.position, fluchtPosition, geschwindigkeit * Time.deltaTime);*/
            }
        }

        public void Bewege(GameObject self)
        {
            var targetRotation = Quaternion.LookRotation(-self.transform.position);
            self.transform.rotation = Quaternion.Slerp(self.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
            self.transform.position += self.transform.forward * geschwindigkeit * Time.deltaTime;
        }

        public void AktionAusführen(Animator animator)
        {
            animator.SetBool("sterben", true);
            animator.SetBool("rennen", false);
        }

        public AnimatorController LiefereAnimation()
        {
            return animatorController;
        }


    }
}
