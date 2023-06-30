using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float GameTime=60f;
    public Text GameTimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject GameOverPanel;
    // Update is called once per frame
    void Update()
    {
        GameTime-=Time.deltaTime;
        GameTimeText.text="Time : "+(int)GameTime;
        if(GameTime <= 0){
            Time.timeScale=0;
            GameOverPanel.SetActive(true);
        }
    }
}//push test
