using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    GameObject sound;
    // Start is called before the first frame update
    void OnEnable()
    {
        sound = GameObject.Find("StopGame"); 
        AudioSource audio = GetComponent<AudioSource>();   
        audio.volume = sound.GetComponent<StopButton>().saveEffectsSlider;
    }

}
