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
    public GameObject SoundController; // BGM 컨트롤러
    public GameObject SoundSlider; // BGM 슬라이더
    public GameObject EffectSlider; // 효과음 슬라이더
    public float saveEffectsSlider = 1;
    void Update(){
        if(SoundSlider.activeSelf)
        SoundController.GetComponent<AudioSource>().volume = SoundSlider.GetComponent<Slider>().value;

        if(EffectSlider.activeSelf){
            saveEffectsSlider = EffectSlider.GetComponent<Slider>().value;
        }
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players){
            player.GetComponent<AudioSource>().volume = saveEffectsSlider;
        }
    }

    
}

