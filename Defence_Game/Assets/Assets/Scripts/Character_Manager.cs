using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character_Manager : MonoBehaviour
{   
    public GameObject reroll_manager;
    Vector2 mousePos;//마우스로 찍은 좌표
    public bool player_check;//플레이어인지 확인하는 변수
    int first_random;//처음 몇개의 캐릭터가 나올지 결정하는 랜덤변수
    int random_x;//캐릭터의 x좌표 랜덤변수
    int random_y;//캐릭터의 y좌표 랜덤변수
    int random_character;//캐릭터 유닛 종류 결정 랜덤변수
    public int check_x;
    public int check_y;
    public int [,]character=new int[12,7];//캐릭터의 유무 판단 배열
    // Start is called before the first frame update
    void Start()
    {
        
        first_random=Random.Range(1,5);
        Debug.Log(first_random);
        for(int i=0;i<12;i++)//처음배열에 모두 0을 넣어줌
        {
            for(int j=0;j<7;j++)
            {
                character[i,j]=0;
            }
        }
        for(int i=0;i<first_random;i++)//처음 몇개의 캐릭터가 나올지 결정을 해줬으므로 그만큼 캐릭터를 생성해줌
        {
            random_x=Random.Range(0,12);
            random_y=Random.Range(0,7);
            character_rerandom();//범위 재지정함수
            character[random_x,random_y]=1;
            while(true)
            {
                if(character[random_x,random_y]==1)
                {
                    random_x=Random.Range(0,12);
                    random_y=Random.Range(0,7);
                    character_rerandom();
                }
                else
                {
                    character[random_x,random_y]=1;
                    random_character=Random.Range(0,3);
                    if(random_character==0)
                    {
                        
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_archer_1"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    else if(random_character==1)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_gunner_1"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    else if(random_character==2)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_magician"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    
                    break;
                }
            }
        }
        
    }
    void character_rerandom()//캐릭터의 이동할수있는칸이 직사각형이 아니므로 이동할수 있는범위를 벗어났을경우 범위 재지정함수
    {
        if(random_y==0||random_y==6)
            {
                while(true)
                {
                    if(random_x<3||random_x>9)
                    {
                        random_x=Random.Range(0,12);
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            if(random_y==1||random_y==5)
            {
                while(true)
                {
                    if(random_x<2||random_x>10)
                    {
                        random_x=Random.Range(0,12);
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            
            mousePos=Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
            mousePos.x=Mathf.CeilToInt(mousePos.x);
            mousePos.y=Mathf.CeilToInt(mousePos.y);
            mousePos=new Vector2(mousePos.x,mousePos.y);
            if(character[(int)mousePos.x,(int)mousePos.y]==1)//클릭한곳에 캐릭터가 있을경우
            {
                check_x=(int)mousePos.x;
                check_y=(int)mousePos.y;
                Debug.Log("캐릭터좌표"+check_x+","+check_y);
                player_check=true;
            }
            else
            {
                player_check=false;
            }
                
        }
        if(reroll_manager.GetComponent<Reroll_Manager>().able_reroll==true)
        {
            Debug.Log("몬스터 생성");
            reroll();
            reroll_manager.GetComponent<Reroll_Manager>().able_reroll=false;
        }
    }
    void reroll()
    {
        for(int i=0;i<1;i++)
        {
            random_x=Random.Range(0,12);
            random_y=Random.Range(0,7);
            character_rerandom();//범위 재지정함수
            character[random_x,random_y]=1;
            while(true)
            {
                if(character[random_x,random_y]==1)
                {
                    random_x=Random.Range(0,12);
                    random_y=Random.Range(0,7);
                    character_rerandom();
                }
                else
                {
                    character[random_x,random_y]=1;
                    random_character=Random.Range(0,3);
                    if(random_character==0)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_archer_1"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    else if(random_character==1)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_gunner_1"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    else if(random_character==2)
                    {
                        GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/hamster_magician"));
                        tmp.transform.position=new Vector3(random_x,random_y,0);
                    }
                    
                    break;
                }
            }
        }
    }
}