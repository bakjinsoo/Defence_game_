using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardEffects : MonoBehaviour
{
    Spawn_Manager spawnManager;

    public void TimeResetToOne(){
        Time.timeScale = 1;
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>();
        foreach(GameObject Card in Cards)
        {
            Destroy(Card);
        }
        
        GameObject.Find("StageEnd").SetActive(false);
        if(spawnManager.round % 5 != 0){ // 일반몹 Stage
            GameObject tmp = Instantiate(Resources.Load("Prefabs/StartStagePanel") as GameObject);
            GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>().round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시
            Destroy(tmp,3f);
        }else{
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            Destroy(tmp,3f);
        }
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
