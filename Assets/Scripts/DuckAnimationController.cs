using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckAnimationController : MonoBehaviour
{
    public Animator animator;
    private bool quack, squat, turboMode, insolence, active = false;
    private CustomTimer timerA = new CustomTimer(.1f, false);
    private CustomTimer timerB = new CustomTimer(.15f, false);


    private void Awake()
    {
        insolence = true;
        timerA.OnTick += forceQuack;
        timerB.OnTick += forceUnQuack;
        timerA.Start();
        timerB.Start();
    }

    private void Update()
    {
        if (turboMode && active){
            timerA.Update(Time.deltaTime);
            timerB.Update(Time.deltaTime);
        }
    }

    public void setTurbo(Toggle toggle)
    {
        turboMode = toggle.isOn;
    }

    public void setActive(bool state){
        active = state;
        if (!state)
            setSquat(false);
    }

    public void resetQuack(){
        timerB.Stop();
        timerB.Start();
    }

    private void forceQuack()
    {
        setQuack(true);
    }

    private void forceUnQuack()
    {
        setQuack(false);
    }

    public void setQuack(bool value)
    {
        quack = value;
        if (insolence && !turboMode) squat = quack;
        if (turboMode && active) squat = true;
        UpdateAnimator();
    }

    public void setSquat(bool value)
    {
        squat = value;
        UpdateAnimator();
    }

    public void setInsolence(bool value)
    {
        insolence = value;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetBool("quack", quack);
        animator.SetBool("squat", squat);
    }
}
