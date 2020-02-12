using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Transform disposableAudio;
    public AudioClip[] soundCollection;
    public DuckAnimationController duck;
    [Range(.8f, 2f)]
    private float pitch = 1f;
    private int currentSound = 0;
    private bool useAccelerometer = true;
    private CustomTimer timer = new CustomTimer(.07f, false);
    private bool turboMode = false;
    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTick += PlaySound;
    }

    // Update is called once per frame
    void Update()
    {
        if (useAccelerometer)
            SetPitch(.8f + (Mathf.Abs(Input.acceleration.z) * 1.2f));

        if (isActive && turboMode)
            timer.Update(Time.deltaTime);

    }

    public void setActive(bool state)
    {
        isActive = state;
        if (turboMode)
        {
            if (state)
                timer.Start();
            else
                timer.Stop();
        }
        if (state && !turboMode)
        {
            PlaySound();
        }
    }

    public void SetAccelerometer(Toggle toggle)
    {
        if (!toggle.isOn)
            SetPitch(1f);
        useAccelerometer = toggle.isOn;
    }

    public void SetTurbo(Toggle toggle)
    {
        turboMode = toggle.isOn;
    }

    public void SetSound(int index)
    {
        currentSound = index;
    }

    public void SetPitch(float value)
    {
        pitch = value;
    }

    public void getSliderValue(Slider slider)
    {
        if (!useAccelerometer)
            SetPitch(slider.value);
    }

    public void PlaySound()
    {
        Transform sfx = Instantiate(disposableAudio, transform);
        DisposableAudio sound = sfx.GetComponent<DisposableAudio>();
        sound.prepareSound(soundCollection[currentSound], currentSound == 0 ? pitch : currentSound == 1 ? pitch > 1.3f ? 1.3f : pitch : 1f);
        sound.Play();
    }
}
