using UnityEngine;

namespace Assets.Scripte
{
    public interface IBewegungsStrategie
    {
        float LiefereAbstand();
        RuntimeAnimatorController LiefereAnimation();
        void BewegungStandard(GameObject self, Animator animator);
        void BewegungVerfolgung(GameObject self, Animator animator, Vector3 targetPosition, bool themaGewechselt);
        void BewegungZurMitte(GameObject self, Animator animator);
        void AktionAusführen(GameObject self, Animator animator);

    }
}