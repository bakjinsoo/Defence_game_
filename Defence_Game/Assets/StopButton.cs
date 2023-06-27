using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public GameObject StopPanel;
    public void StopButtonClick(){
        StopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayButtonClick(){
        StopPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public GameObject SoundController;
    public GameObject SoundSlider;
    void Update(){
        if(SoundSlider.activeSelf)
        SoundController.GetComponent<AudioSource>().volume = SoundSlider.GetComponent<Slider>().value;
    }
}

