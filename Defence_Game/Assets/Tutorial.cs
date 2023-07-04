using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    Tutorial_Manager tutorial_Manager;
    public GameObject click_manager;
    void Start()
    {
        tutorial_Manager = GameObject.Find("Tutorial Manager").GetComponent<Tutorial_Manager>();
    }
    public void TutorialClickReroll()
    {
        if(tutorial_Manager.tutorial_key == 19) 
        {
            tutorial_Manager.tutorial_key++;
            tutorial_Manager.text.text="캐릭터를 한번 눌러보세요!";
            click_manager.SetActive(true);
        }
    }
}
