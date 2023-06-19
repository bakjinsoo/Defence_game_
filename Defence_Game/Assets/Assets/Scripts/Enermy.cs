using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public float hp=100;
    public Transform center;//enermy collider프리펩의 위치 조정을 통한 적의 타원형운동 반복
    public float speed = 2f; 
    public float radius=4.8f;
    private float angle=0;
    Spawn_Manager spawnManager;
    Reroll_Manager CoinGetter;
    bool isFlip=false;
    
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>();
        isFlip = GetComponent<SpriteRenderer>().flipX;
    }
    bool OneTime = true;
    void Update()
    {
        angle += Time.deltaTime * speed; 
        transform.position = center.position + new Vector3(Mathf.Cos(angle)*1.6f , Mathf.Sin(angle)*0.9f,0)*radius;
        if(hp<=0)
        {
            GetComponent<Animator>().SetTrigger("Death"); // 죽음 애니메이션
            speed = 0;
            int random = Random.Range(0,100); // 10%확률로 코인 획득
            if(random<10 && OneTime)
            {
                CoinGetter = GameObject.Find("Reroll_Button").GetComponent<Reroll_Manager>();
                CoinGetter.coin+=10;
                OneTime = false;
            }
            
        }
        if(transform.position.y<3)
        {

            GetComponent<SpriteRenderer>().flipX=!isFlip;
        }else{
            GetComponent<SpriteRenderer>().flipX=isFlip;
        }
    }
    
    void speedDown(){
        speed /= 3;
    }
    void speedUp(){
        speed *= 3;
    }

    private void OnDestroy() {
        
        spawnManager.leftCount--; // 현재 몹 수를 하나 줄여준다.
    }
}
