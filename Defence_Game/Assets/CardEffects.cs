using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardEffects : MonoBehaviour
{
    Spawn_Manager spawnManager;

     void OnEnable() {
        level = GetLevel();    
    }

    public void TimeResetToOne(){
        Time.timeScale = 1;
        GameObject[] Cards = GameObject.FindGameObjectsWithTag("Card");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>();
        foreach(GameObject Card in Cards)
        {
            Destroy(Card);
        }
        
        GameObject.Find("StageEnd").SetActive(false);
        if((spawnManager.round+1) % 10 != 0){ // 일반몹 Stage
            GameObject tmp = Instantiate(Resources.Load("Prefabs/StartStagePanel") as GameObject);
            GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>().round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시
            Destroy(tmp,3f);
        }else{
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            Destroy(tmp,3f);
        }
    }
    int level;
    public void ArcherAttackCoefficientUp(){ // 궁수 공격력 증가
        characterData.Instance.ArcherAttackCoefficient += 0.5f * level;  
    }
    public void GunnerAttackCoefficientUp(){ // 거너 공격력 증가
        characterData.Instance.GunnerAttackCoefficient += 0.5f * level;
    }
    public void MagicianAttackCoefficientUp(){ // 마법사 공격력 증가
        characterData.Instance.MagicianAttackCoefficient += 0.5f * level;
    }
    public void ArcherAttackSpeedUp(){ // 궁수 공격속도 증가
        characterData.Instance.Archer_attackSpeed += 0.1f * level;
    }
    public void GunnerAttackSpeedUp(){ // 거너 공격속도 증가
        characterData.Instance.Gunner_attackSpeed += 0.1f * level;
    }
    public void MagicianAttackSpeedUp(){ // 마법사 공격속도 증가
        characterData.Instance.Magician_attackSpeed += 0.1f * level;
    }

    public void GetGold(){
        GameObject.Find("Reroll_Button").GetComponent<Reroll_Manager>().coin += 100 * level; 
    }
    
    public void CoinPercentageUp(){
        characterData.Instance.goldGetPercentage += 2 * level;
    }
    
    int GetLevel(){ // 카드 레벨을 가져와줌 1,2,3등급 
        int random = Random.Range(0,100);
        int grade = 1;
        if(random < 50){
            grade = 1;
        }else if(grade < 80){
            grade = 2;
        }else{
            grade = 3;
        }
        showStar(grade);
        return grade;
    }

    void showStar(int level){ // 카드에 등급별 별을 찍어준다.
        Debug.Log(level);
        for(int i = 0; i < level; i++){
            // Debug.Log(transform.childCount);
            transform.GetChild(i + 2).gameObject.SetActive(true);
        }
    }
    void berserkerMode(){
        characterData.Instance.BerserkerMode = true;
    }
    public void rerollAll(){ // 생성되어있는 모든애들을 reroll 해줌
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Aura = GameObject.FindGameObjectsWithTag("Aura");
        foreach(GameObject player in Players){
            rerollPlayers((int)player.transform.position.x, (int)player.transform.position.y);
        }
        foreach(GameObject aura in Aura){
            Destroy(aura);
        }
        foreach(GameObject player in Players){
            Destroy(player);
        }
    }


    private void rerollPlayers(int transform_x, int transform_y){
        int random_character = Random.Range(0,3);
        if(random_character==0)
        {
            
            GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_archer_1"));
            tmp.transform.position=new Vector3(transform_x,transform_y,0);
        }
        else if(random_character==1)
        {
            
            GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_gunner_1"));
            tmp.transform.position=new Vector3(transform_x,transform_y,0);
        }
        else if(random_character==2)
        {
            
            GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_magician"));
            tmp.transform.position=new Vector3(transform_x,transform_y,0);
        }
    }

}

