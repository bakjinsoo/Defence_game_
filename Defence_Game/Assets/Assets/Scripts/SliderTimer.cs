using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTimer : MonoBehaviour
{
    Slider slider;
    float sliderTime=60f;
    // Start is called before the first frame update
    TimeManager timeManager;
    void Start()
    {
        slider=GetComponent<Slider>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value>0)
        {
            slider.value=timeManager.GameTime - Time.deltaTime;
        }
        else
        {
            
        }
    }
}
