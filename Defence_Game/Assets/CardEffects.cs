using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardEffects : MonoBehaviour
{
 
    public void TimeResetToOne(){
        Time.timeScale = 1;
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject Card in Cards)
        {
            Destroy(Card);
        }

        GameObject.Find("StageEnd").SetActive(false);
        GameObject tmp = Instantiate(Resources.Load("Prefabs/StartStagePanel") as GameObject);
        GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>().round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시
        Destroy(tmp,3f);
    }

    public void ArcherAttackCoefficientUp(){
        characterData.Instance.ArcherAttackCoefficient += 0.5f;
        Debug.Log("Effects 1");
        
    }
    public void GunnerAttackCoefficientUp(){
        characterData.Instance.GunnerAttackCoefficient += 0.5f;
        Debug.Log("Effects 2");
    }
    public void MagicianAttackCoefficientUp(){
        characterData.Instance.MagicianAttackCoefficient += 0.5f;
        Debug.Log("Effects 3");
    }

}
