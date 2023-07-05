using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartMenuButton : MonoBehaviour
{

    public GameObject CreditPanel;
    void Start(){
        Time.timeScale=1;
    }
    public void startGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Jinsu-Tutorial");
    }
    public void exitGame(){
        Application.Quit();
    }
    public void gotoStart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
    public void showCredit()
    {
        CreditPanel.SetActive(true);
    }
    public void hideCredit()
    {
        CreditPanel.SetActive(false);
    }
}
