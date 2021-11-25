using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


public interface IBewegungsStrategie
{
    AnimatorController LiefereAnimation();
    void Bewege(Animator animator, GameObject self, float geschwindigkeit);
    void Bewege(Animator animator, GameObject target, GameObject self, float geschwindigkeit);
    void AktionAusführen(Animator animator);

}

public class JägerBewegungsStrategie : IBewegungsStrategie
{
    public JägerBewegungsStrategie(AnimatorController animatorController)
    {
        this.animatorController = animatorController;
    }

    private AnimatorController animatorController;

    public void Bewege(Animator animator, GameObject jäger, float geschwindigkeit)
    {
        geschwindigkeit = geschwindigkeit / 4;

        animator.SetBool("rennen", false);
        animator.SetBool("fressen", false);
        animator.SetBool("laufen", true);

        var moveRotation = jäger.GetComponent<JägerObjekt>().rotation;

        if (Random.Range(0,200) < 5)
        {
            moveRotation = jäger.GetComponent<JägerObjekt>().rotation = jäger.transform.localEulerAngles + new Vector3(0, (Random.value - 0.5f) * 180 , 0);
        }

        //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit / 6, aktuelleGeschwindigkeit * Time.deltaTime);

        var desiredRotQ = Quaternion.Euler(moveRotation);
        jäger.transform.rotation = Quaternion.Lerp(jäger.transform.rotation, desiredRotQ, Time.deltaTime * geschwindigkeit);
        jäger.transform.position += jäger.transform.forward * geschwindigkeit * Time.deltaTime;

    }

    public void Bewege(Animator animator, GameObject target, GameObject jäger, float geschwindigkeit)
    {
        animator.SetBool("rennen", true);
        animator.SetBool("fressen", false);
        animator.SetBool("laufen", false);

        //aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit, aktuelleGeschwindigkeit * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(target.transform.position - jäger.transform.position);
        // Smoothly rotate towards the target point.
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
