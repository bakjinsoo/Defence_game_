using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterData : Singleton<characterData>
{

    /*공격 속도*/
    public float Gunner_attackSpeed = 1.5f;
    public float Archer_attackSpeed = 1.5f;
    public float Magician_attackSpeed = 1.5f;

    /* 공격력 */
    public float[] GunnerAttackPoints = {2, 4, 8, 10, 18, 26};
    public float[] MagicianAttackPoints = {2, 4, 8, 10, 18, 26};
    public float[] ArcherAttackPoints = {4, 8, 16, 32, 50, 100};

    /* 공격계수 */
    public float GunnerAttackCoefficient = 1.0f; 
    public float MagicianAttackCoefficient = 1.0f;
    public float ArcherAttackCoefficient = 1.0f;

    /* 골드획득확률 */
    public int goldGetPercentage = 10;

    /* 버서커 모드 */
    public bool BerserkerMode = false;
    public float burserkerAmount = 1.5f;
    
    private TimeManager timeManager;
    void Start(){
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        _tmpArcherAttackSpeed = Archer_attackSpeed;
        _tmpGunnerAttackSpeed = Gunner_attackSpeed;
        _tmpMagicianAttackSpeed = Magician_attackSpeed;
    }
    bool oneTime = true;
    bool oneTime2 = true;

    /* 버서커 모드를 위한 임시 공격속도 저장 변수 */
    private float _tmpGunnerAttackSpeed;
    private float _tmpArcherAttackSpeed;
    private float _tmpMagicianAttackSpeed;

    /*유닛 판매 시 획득 골드 */
    public int moneyGet = 20;

    /*15%확률로 무료 리롤*/
    public int freeReroll = 0;

    void Update(){
        if(BerserkerMode){
            if(oneTime2)  // 버서커 넘어가기전 쌓인 공속이 초기화 되지않게 함
            { 
                _tmpGunnerAttackSpeed = Gunner_attackSpeed;
                _tmpArcherAttackSpeed = Archer_attackSpeed;
                _tmpMagicianAttackSpeed = Magician_attackSpeed;
                oneTime2 = false;
            }
        }
        if(BerserkerMode && timeManager.GameTime <= 10){
            if(oneTime){ // 버서커 모드

                Gunner_attackSpeed *= burserkerAmount; // 곱해줌
                Archer_attackSpeed *= burserkerAmount;
                Magician_attackSpeed *= burserkerAmount;
                GameObject[] lists = GameObject.FindGameObjectsWithTag("Player");
                foreach(GameObject list in lists){   
                    GameObject tmp = Instantiate(Resources.Load("Prefabs/BerserkerMode") as GameObject, list.transform.position, Quaternion.identity);
                    tmp.transform.position = new Vector3(tmp.transform.position.x -0.5f, tmp.transform.position.y -0.5f, tmp.transform.position.z);
                }
                oneTime = false; // update 문이지만 한번만 돌게
            }

        }
        if(timeManager.GameTime > 10 && BerserkerMode && !oneTime2){
            Gunner_attackSpeed = _tmpGunnerAttackSpeed;
            Archer_attackSpeed = _tmpArcherAttackSpeed;
            Magician_attackSpeed = _tmpMagicianAttackSpeed;
            GameObject[] lists = GameObject.FindGameObjectsWithTag("Berserker");
            foreach(GameObject list in lists){   
                Destroy(list);
            }
            oneTime = true;
        }
    }
}
