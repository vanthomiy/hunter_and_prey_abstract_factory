using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


public interface IBewegungsStrategie
{
    AnimatorController LiefereAnimation();
    void Bewege(Animator animator, GameObject self, float geschwindigkeit);
    void Bewege(Animator animator, GameObject target, GameObject self, float geschwindigkeit);
    void AktionAusf�hren(Animator animator);

}

public class J�gerBewegungsStrategie : IBewegungsStrategie
{
    public J�gerBewegungsStrategie(AnimatorController animatorController)
    {
        this.animatorController = animatorController;
    }

    private AnimatorController animatorController;

    public void Bewege(Animator animator, GameObject j�ger, float geschwindigkeit)
    {
        geschwindigkeit = geschwindigkeit / 4;

        animator.SetBool("rennen", false);
        animator.SetBool("fressen", false);
        animator.SetBool("laufen", true);

        var moveRotation = j�ger.GetComponent<J�gerObjekt>().rotation;

        if (Random.Range(0,200) < 5)
        {
            moveRotation = j�ger.GetComponent<J�gerObjekt>().rotation = j�ger.transform.localEulerAngles + new Vector3(0, (Random.value - 0.5f) * 180 , 0);
        }

        //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit / 6, aktuelleGeschwindigkeit * Time.deltaTime);

        var desiredRotQ = Quaternion.Euler(moveRotation);
        j�ger.transform.rotation = Quaternion.Lerp(j�ger.transform.rotation, desiredRotQ, Time.deltaTime * geschwindigkeit);
        j�ger.transform.position += j�ger.transform.forward * geschwindigkeit * Time.deltaTime;

    }

    public void Bewege(Animator animator, GameObject target, GameObject j�ger, float geschwindigkeit)
    {
        animator.SetBool("rennen", true);
        animator.SetBool("fressen", false);
        animator.SetBool("laufen", false);

        //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit, aktuelleGeschwindigkeit * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(target.transform.position - j�ger.transform.position);
        // Smoothly rotate towards the target point.
        j�ger.transform.rotation = Quaternion.Slerp(j�ger.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
        j�ger.transform.position += j�ger.transform.forward * geschwindigkeit * Time.deltaTime;

        //Debug.Log("Bewege zu " + target.transform.position);
    }

    public void AktionAusf�hren(Animator animator)
    {
        animator.SetBool("rennen", false);
        animator.SetBool("fressen", true);
        animator.SetBool("laufen", false);
    }

    public AnimatorController LiefereAnimation()
    {
        return animatorController;
    }
}

public class BeuteBewegungsStrategie : IBewegungsStrategie
{
    public BeuteBewegungsStrategie(AnimatorController animatorController)
    {
        this.animatorController = animatorController;
    }

    private AnimatorController animatorController;

    public void Bewege(Animator animator, GameObject beute, float geschwindigkeit)
    {
        animator.SetBool("rennen", false);
        animator.SetBool("sterben", false);
    }

    public void Bewege(Animator animator, GameObject target, GameObject beute, float geschwindigkeit)
    {
        geschwindigkeit = geschwindigkeit / 1.5f;

        animator.SetBool("rennen", true);
        animator.SetBool("sterben", false);

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
        {
            var fluchtPosition = beute.transform.position + Vector3.Normalize(beute.transform.position - target.transform.position) * 5;

            beute.transform.LookAt(fluchtPosition);
            beute.transform.position = Vector3.MoveTowards(beute.transform.position, fluchtPosition, geschwindigkeit * Time.deltaTime);
        }
    }

    public void AktionAusf�hren(Animator animator)
    {
        animator.SetBool("sterben", true);
        animator.SetBool("rennen", false);
    }

    public AnimatorController LiefereAnimation()
    {
        return animatorController;
    }
}
