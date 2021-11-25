using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


public interface IBewegungsStrategie
{

    AnimatorController LiefereAnimation();
    void Bewege(GameObject self);
    void Bewege(Animator animator, GameObject self);
    void Bewege(Animator animator, Vector3 targetPosition, GameObject self);
    void AktionAusführen(Animator animator);

}
