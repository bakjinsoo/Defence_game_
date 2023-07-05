using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardEffects : MonoBehaviour
{
    Spawn_Manager spawnManager;

     void OnEnable() {
        level = GetLevel(); 
        lists = GameObject.FindGameObjectsWithTag("Player");
    }
    public void Update(){
        if(GameObject.Find("StartStagePanel(Clone)") != null)
        {
            Destroy(GameObject.Find("StartStagePanel(Clone)"));
        }
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
        if(spawnManager.round + 1 == 31)
        {
            Instantiate(Resources.Load("Prefabs/FadeOut") as GameObject);
        }


        if(spawnManager.round+1 == 31)
        {
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "사이클롭스";
            Destroy(tmp,3f);
        }else if(spawnManager.round+1 == 32)
        {
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "네크로멘서";
            Destroy(tmp,3f);
        }
        else if(spawnManager.round + 1 == 33){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "타락한 기사";
            Destroy(tmp,3f);
        }else if(spawnManager.round + 1 == 34){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "좀비 킹";
            Destroy(tmp,3f);
        }else if(spawnManager.round + 1 == 35){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "오염된 나무";
            Destroy(tmp,3f);
        }else if(spawnManager.round + 1 == 36){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "올드 가디언";
            Destroy(tmp,3f);
        }else if(spawnManager.round + 1 == 37){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "데몬";
            Destroy(tmp,3f);
        }else if(spawnManager.round + 1 == 38){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "얼음";
            Destroy(tmp,3f);
        }

        else if((spawnManager.round + 1) % 10 == 0){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            Debug.Log("STAGE"+spawnManager.round + 1);
            if(spawnManager.round + 1 == 10){
                GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "밝은 숲";
            }
            else if(spawnManager.round + 1 == 20){
                GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "어둠의 숲";
            }
            else if(spawnManager.round + 1 == 30){
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "사원";
            }

            Destroy(tmp,3f);
        }else{ // 일반몹 Stage
            GameObject tmp = Instantiate(Resources.Load("Prefabs/StartStagePanel") as GameObject);
            GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>().round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시

            Destroy(tmp,3f);
        }
    }
    int level;
    GameObject[] lists;
    public void ArcherAttackCoefficientUp(){ // 궁수 공격력 증가
        characterData.Instance.ArcherAttackCoefficient += 1.5f * level;  
        
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 3){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x-0.5f, tmp.transform.position.y-0.5f, tmp.transform.position.z);
            }
        }
    }
    public void GunnerAttackCoefficientUp(){ // 거너 공격력 증가
        characterData.Instance.GunnerAttackCoefficient += 0.8f * level;
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 2){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x-0.5f, tmp.transform.position.y-0.5f, tmp.transform.position.z);
            }
        }
    }
    public void MagicianAttackCoefficientUp(){ // 마법사 공격력 증가
        characterData.Instance.MagicianAttackCoefficient += 0.8f * level;
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 1){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x -0.5f, tmp.transform.position.y -0.5f, tmp.transform.position.z);
            }
        }
    }
    public void ArcherAttackSpeedUp(){ // 궁수 공격속도 증가
        characterData.Instance.Archer_attackSpeed += 0.1f * level;
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 3){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x-0.5f, tmp.transform.position.y-0.5f, tmp.transform.position.z);
            }
        }
    }
    public void GunnerAttackSpeedUp(){ // 거너 공격속도 증가
        characterData.Instance.Gunner_attackSpeed += 0.1f * level;
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 2){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x-0.5f, tmp.transform.position.y-0.5f, tmp.transform.position.z);
            }
        }
    }
    public void MagicianAttackSpeedUp(){ // 마법사 공격속도 증가
        characterData.Instance.Magician_attackSpeed += 0.1f * level;
        foreach(GameObject list in lists){
            if(list.GetComponent<Player_id>().player_id == 1){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/PowerUp") as GameObject, list.transform.position, Quaternion.identity);
                tmp.transform.position = new Vector3(tmp.transform.position.x -0.5f, tmp.transform.position.y -0.5f, tmp.transform.position.z);
            }
        }
    }

    public void GetGold(){
        GameObject.Find("Reroll_Button").GetComponent<Reroll_Manager>().coin += 100 * level; 
        Instantiate(Resources.Load("Prefabs/CoinEffects") as GameObject);
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
    public void berserkerMode(){
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
            GameObject tmp = Instantiate(Resources.Load("Prefabs/Smoke") as GameObject, player.transform.position, Quaternion.identity);
            tmp.transform.position = new Vector3(tmp.transform.position.x-0.5f, tmp.transform.position.y-0.5f, tmp.transform.position.z);
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

    public void sellMoneyUpgrade(){
        characterData.Instance.moneyGet += 2*level;
    }

    public void freeRerollPercent(){
        characterData.Instance.freeReroll += 3*level;
    }

}

