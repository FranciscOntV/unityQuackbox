using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTimer
{
    public event System.Action OnTick = delegate { };

    private float currentTime = 0f;
    private float timeLimit;
    private bool active = false;


    public CustomTimer(float time = 1f, bool initialStatus = false)
    {
        timeLimit = time;
    }

    public void Update(float timestep)
    {
        if (active)
        {
            currentTime -= timestep;
            if (currentTime <= 0f)
            {
                currentTime = timeLimit;
                if (OnTick != null) OnTick.Invoke();
            }

        }
    }

    public void Start()
    {
        active = true;
    }

    public float Time()
    {
        return currentTime;
    }

    public void Stop()
    {
        active = false;
    }
}
