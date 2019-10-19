using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableAudio : MonoBehaviour
{
    private AudioSource player;
    private bool played;

    private void Awake() {
        player = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!player.isPlaying && played){
            Destroy(gameObject);
        }
    }

    public void prepareSound(AudioClip sound, float pitch = 1f){
        player.clip = sound;
        player.pitch = pitch;
    }

    public void Play() {
        player.Play();
        played = true;
    }
}
