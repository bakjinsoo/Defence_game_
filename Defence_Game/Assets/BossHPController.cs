using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       GetComponent<Slider>().value = GameObject.FindWithTag("Enermy").GetComponent<Enermy>().hp;
       if(GetComponent<Slider>().value <= 0)
       {
           gameObject.SetActive(false);
       }
    }
}
