using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStart : MonoBehaviour
{
    public GameObject quizbackground;
    public GameObject response;
    public GameObject timerpannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            response.SetActive(false);
            quizbackground.SetActive(true);
            timerpannel.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            response.SetActive(true);
            quizbackground.SetActive(false);
            timerpannel.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            response.SetActive(false);
            quizbackground.SetActive(false);
            timerpannel.SetActive(true);
        }
    }
}
