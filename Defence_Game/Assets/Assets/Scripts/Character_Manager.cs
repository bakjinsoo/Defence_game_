using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character_Manager : MonoBehaviour
{
    public GameObject show_area;   
    public GameObject ui_selected;
    public GameObject click_manager;
    public GameObject reroll_manager;
    Vector2 mousePos;//마우스로 찍은 좌표
    public bool player_check;//플레이어인지 확인하는 변수
    int first_random;//처음 몇개의 캐릭터가 나올지 결정하는 랜덤변수
    int random_x;//캐릭터의 x좌표 랜덤변수
    int random_y;//캐릭터의 y좌표 랜덤변수
    int random_character;//캐릭터 유닛 종류 결정 랜덤변수
    public int check_x;
    public int check_y;
    public int [,]character=new int[13,7];//캐릭터의 유무 판단 배열
    Camera cam;
    float max_distance=30f;
    int ui_class_key=0;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        cam=GetComponent<Camera>();
        first_random=Random.Range(2,5);
        Debug.Log(first_random);
        for(int i=0;i<13;i++)//처음배열에 모두 0을 넣어줌
        {
            for(int j=0;j<7;j++)
            {
                character[i,j]=0;
            }
        }
        for(int i=0;i<first_random;i++)//처음 몇개의 캐릭터가 나올지 결정을 해줬으므로 그만큼 캐릭터를 생성해줌
        {
            random_x=Random.Range(0,13);
            random_y=Random.Range(0,7);
            character_rerandom();//범위 재지정함수
            while(true)
            {
                if(character[random_x,random_y]==1)
                {
                    random_x=Random.Range(0,13);
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
                        random_x=Random.Range(0,13);
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
                        random_x=Random.Range(0,13);
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
            Debug.Log("mousepos.x : "+mousePos.x+"mouse.y : "+mousePos.y);
            RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance,LayerMask.GetMask("Player"));
            if(hit.collider!=null)
            {
                target=hit.collider.gameObject;
                if(target.CompareTag("Player")&&target.transform.position.x==mousePos.x&&target.transform.position.y==mousePos.y)
                {
                    if(target.GetComponent<Player_id>().player_id==1)
                    {
                        Debug.Log("클래스 bool 변수 반환");
                        target.GetComponentInChildren<magician_attack>().ui_class_key=0;
                        target.GetComponentInChildren<magician_attack>().is_selected=true;
                    }
                    else if(target.GetComponent<Player_id>().player_id==2)
                    {
                        target.GetComponentInChildren<gunner_attack>().ui_class_key=0;
                        target.GetComponentInChildren<gunner_attack>().is_selected=true;
                    }
                    else if(target.GetComponent<Player_id>().player_id==3)
                    {
                        target.GetComponentInChildren<archer_attack>().ui_class_key=0;
                        target.GetComponentInChildren<archer_attack>().is_selected=true;
                    }
                }
            }
            try{
                if(character[(int)mousePos.x,(int)mousePos.y]==1&&click_manager.GetComponent<Click_Manager>().character_clicked==false)//클릭한곳에 캐릭터가 있을경우
                {
                    player_check=true;
                    ui_selected.transform.position=new Vector2(mousePos.x,mousePos.y);
                    ui_selected.SetActive(true);
                    show_area.SetActive(true);
                    for(int i=0;i<13;i++)
                    {
                        
                        for(int j=0;j<7;j++)
                        {
                            if(character[i,j]==1)
                            {
                                GameObject tmp=Instantiate(Resources.Load<GameObject>("Prefabs/character_area_ui"));
                                tmp.transform.position=new Vector3(i,j,0);
                            }
                        }
                    }
                    check_x=(int)mousePos.x;
                    check_y=(int)mousePos.y;
                    Debug.Log("캐릭터좌표"+check_x+","+check_y);
                    
                }
                else
                {
                    ui_selected.SetActive(false);
                    show_area.SetActive(false);
                    player_check=false;
                }
            }
            catch{

            }
            
                
        }
        if(reroll_manager.GetComponent<Reroll_Manager>().able_reroll==true)
        {
            
            reroll();
            reroll_manager.GetComponent<Reroll_Manager>().able_reroll=false;
        }
    }
    void reroll()
    {
        for(int i=0;i<1;i++)
        {
            random_x=Random.Range(0,13);
            random_y=Random.Range(0,7);
            character_rerandom();//범위 재지정함수
            while(true)
            {
                if(character[random_x,random_y]==1)
                {
                    random_x=Random.Range(0,13);
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