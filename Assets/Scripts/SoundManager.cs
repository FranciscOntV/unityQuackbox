using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Transform disposableAudio;
    public AudioClip[] soundCollection;
    [Range(.8f, 2f)]
    private float pitch = 1f;
    private int currentSound = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSound(int index){
        currentSound = index;
    }

    public void setPitch(float value){
        pitch = value;
    }

    public void PlaySound(){
        Transform sfx = Instantiate(disposableAudio, transform);
        DisposableAudio sound = sfx.GetComponent<DisposableAudio>();
        sound.prepareSound(soundCollection[currentSound], currentSound == 0 ? pitch : 1f);
        sound.Play();
    }
}
