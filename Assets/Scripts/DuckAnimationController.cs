using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckAnimationController : MonoBehaviour
{
    public Animator animator;
    private bool quack, squat, insolence = false;


    private void Awake() {
        insolence = true;
    }
    public void setQuack(bool value){
        quack = value;
        if (insolence) squat = quack;
        UpdateAnimator();
    }

    public void setSquat(bool value){
        squat = value;
        UpdateAnimator();
    }

    public void setInsolence(bool value){
        insolence = value;
        UpdateAnimator();
    }

    private void UpdateAnimator(){
        animator.SetBool("quack", quack);
        animator.SetBool("squat", squat);
    }
}
