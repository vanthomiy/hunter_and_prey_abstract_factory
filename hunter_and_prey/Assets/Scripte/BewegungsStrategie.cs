using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


public interface IBewegungsStrategie
{

    void Bewege();
    void Bewege(GameObject target);
    void InitiereBewegungsStrategie(Animator animator, GameObject beute);
    void AktionAusf�hren();

}

public class J�gerBewegungsStrategie : IBewegungsStrategie
{
    private Animator animator;
    public AnimatorController animationController;
    private GameObject j�ger;

    public J�gerBewegungsStrategie(float geschwindigkeit, AnimatorController animationController)
    {
        this.geschwindigkeit = geschwindigkeit;
        this.animationController = animationController;
        this.aktuelleGeschwindigkeit = geschwindigkeit / 4;
    }

    private float geschwindigkeit;
    private float aktuelleGeschwindigkeit;

    private int letzterRichtungswechsel = 0;
    private Vector3 moveRotation;
    public void Bewege()
    {
        this.animator.SetBool("rennen", false);
        this.animator.SetBool("fressen", false);
        this.animator.SetBool("laufen", true);
        Debug.Log("Laufen");


        if (letzterRichtungswechsel++ > 200)
        {
            letzterRichtungswechsel = 0;
            moveRotation = j�ger.transform.localEulerAngles + new Vector3(0, (Random.value - 0.5f) * 180 , 0);
        }

        aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit / 4, aktuelleGeschwindigkeit * Time.deltaTime);

        var desiredRotQ = Quaternion.Euler(moveRotation.x, moveRotation.y, moveRotation.z);
        j�ger.transform.rotation = Quaternion.Lerp(j�ger.transform.rotation, desiredRotQ, Time.deltaTime * this.geschwindigkeit);
        j�ger.transform.position += j�ger.transform.forward * aktuelleGeschwindigkeit * Time.deltaTime;

    }

    public void Bewege(GameObject target)
    {
        this.animator.SetBool("rennen", true);
        this.animator.SetBool("fressen", false);
        this.animator.SetBool("laufen", false);

        aktuelleGeschwindigkeit = Mathf.Lerp(aktuelleGeschwindigkeit, geschwindigkeit, aktuelleGeschwindigkeit * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(target.transform.position - j�ger.transform.position);
        // Smoothly rotate towards the target point.
        j�ger.transform.rotation = Quaternion.Slerp(j�ger.transform.rotation, targetRotation, geschwindigkeit * Time.deltaTime);
        j�ger.transform.position += j�ger.transform.forward * aktuelleGeschwindigkeit * Time.deltaTime;

        Debug.Log("Bewege zu " + target.transform.position);
    }

    public void AktionAusf�hren()
    {
        this.animator.SetBool("rennen", false);
        this.animator.SetBool("fressen", true);
        this.animator.SetBool("laufen", false);
    }

    public void InitiereBewegungsStrategie(Animator animator, GameObject j�ger)
    {
        this.j�ger = j�ger;
        this.animator = animator;
        this.animator.runtimeAnimatorController = animationController;
    }
}

public class BeuteBewegungsStrategie : IBewegungsStrategie
{
    private GameObject beute;
    private Animator animator;
    public AnimatorController animationController;

    public BeuteBewegungsStrategie(float geschwindigkeit, AnimatorController animationController)
    {
        this.geschwindigkeit = geschwindigkeit;
        this.animationController = animationController;
    }

    private float geschwindigkeit;

    public void Bewege()
    {
        this.animator.SetBool("rennen", false);
        this.animator.SetBool("sterben", false);
    }

    public void Bewege(GameObject j�ger)
    {
        this.animator.SetBool("rennen", true);
        this.animator.SetBool("sterben", false);

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
        {
            var fluchtPosition = beute.transform.position + Vector3.Normalize(beute.transform.position - j�ger.transform.position) * 5;

            beute.transform.LookAt(fluchtPosition);
            beute.transform.position = Vector3.MoveTowards(beute.transform.position, fluchtPosition, geschwindigkeit * Time.deltaTime);
        }
    }

    public void AktionAusf�hren()
    {
        this.animator.SetBool("rennen", false);
        this.animator.SetBool("sterben", true);
    }

    public void InitiereBewegungsStrategie(Animator animator, GameObject beute)
    {
        this.beute = beute;
        this.animator = animator;
        this.animator.runtimeAnimatorController = animationController;
    }
}
