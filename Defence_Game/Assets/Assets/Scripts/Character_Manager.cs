using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character_Manager : MonoBehaviour
{
    public GameObject move_btn;
    public GameObject show_area;   
    public GameObject ui_selected;
    public GameObject click_manager;
    public GameObject reroll_manager;
    public Vector2 mousePos;//마우스로 찍은 좌표
    public bool player_check;//플레이어인지 확인하는 변수
    public int first_random;//처음 몇개의 캐릭터가 나올지 결정하는 랜덤변수
    int random_x;//캐릭터의 x좌표 랜덤변수
    int random_y;//캐릭터의 y좌표 랜덤변수
    int random_character;//캐릭터 유닛 종류 결정 랜덤변수
    public int check_x;
    public int check_y;
    public int [,]character=new int[12,7];//캐릭터의 유무 판단 배열
    
    Camera cam;
    float max_distance=30f;
    int ui_class_key=0;
    GameObject target;
    public int first_target_key=0;
    // Start is called before the first frame update
    void Start()
    {
        cam=GetComponent<Camera>();
        first_random=Random.Range(2,5);
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
                    if(random_x<2||random_x>9)
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
                    if(random_x<1||random_x>10)
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
    public bool btn_exist_key=false;
    public int player_count;
    void Update()
    {
        show_area = GameObject.FindGameObjectWithTag("Map").transform.GetChild(3).gameObject;
        player_count=0;
        if(Input.GetMouseButtonDown(0))
        {
            mousePos=Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
            mousePos.x=Mathf.CeilToInt(mousePos.x);
            mousePos.y=Mathf.CeilToInt(mousePos.y);
            mousePos=new Vector2(mousePos.x,mousePos.y);
            RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance,LayerMask.GetMask("Player"));
            for(int i=0;i<12;i++)
            {
                for(int j=0;j<7;j++)
                {
                    Vector2 player_tmp_pos=new Vector2(i,j);
                    RaycastHit2D playerhit=Physics2D.Raycast(player_tmp_pos,transform.forward,max_distance,LayerMask.GetMask("Player"));
                    if(playerhit.collider!=null){
                        character[i,j]=1;
                    }
                    else{
                        character[i,j]=0;
                    }
                }
            }
            if(click_manager.GetComponent<Click_Manager>().sell_key>0){
                click_manager.GetComponent<Click_Manager>().sell_btn_check=false;
            }
            Debug.Log("mousepos.x : "+mousePos.x+"mouse.y : "+mousePos.y);
            if(hit.collider!=null&&first_target_key==0&&btn_exist_key==false)
            {
                target=hit.collider.gameObject;
                if(target.CompareTag("Player")&&target.transform.position.x==mousePos.x&&target.transform.position.y==mousePos.y&&click_manager.GetComponent<Click_Manager>().move_btn_check==false&&btn_exist_key==false)
                {
                    click_manager.GetComponent<Click_Manager>().tmp=target;
                }
            }
            try{
                if(player_check==true)
                {
                    if(target.transform.position.x==(int)mousePos.x&&target.transform.position.y+1==(int)mousePos.y){
                        click_manager.GetComponent<Click_Manager>().move_btn_check=true;
                    }
                    else if(target.transform.position.x+1==(int)mousePos.x&&target.transform.position.y+1==(int)mousePos.y){
                        click_manager.GetComponent<Click_Manager>().sell_btn_check=true;
                        target=null;
                    }
                }
                else{
                    click_manager.GetComponent<Click_Manager>().sell_btn_check=false;
                }
            }
            catch{

            }
            try{            
                if(character[(int)mousePos.x,(int)mousePos.y]==1&&click_manager.GetComponent<Click_Manager>().character_clicked==false&&btn_exist_key==false)//클릭한곳에 캐릭터가 있을경우
                {
                    player_check=true;
                    click_manager.GetComponent<Click_Manager>().sell_btn_check=false;
                    click_manager.GetComponent<Click_Manager>().sell_key=0;
                    if(click_manager.GetComponent<Click_Manager>().move_btn_first==false&&click_manager.GetComponent<Click_Manager>().move_btn_check==false){
                        check_x=(int)mousePos.x;
                        check_y=(int)mousePos.y;
                        Debug.Log("캐릭터좌표"+check_x+","+check_y);
                    }
                        
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
            try{
                if(click_manager.GetComponent<Click_Manager>().move_btn_first==true&&character[(int)mousePos.x,(int)mousePos.y+1]==1){
                
                    btn_exist_key=true;
                    player_check=true;
                    check_x=(int)mousePos.x;
                    check_y=(int)mousePos.y;
                    Debug.Log("캐릭터좌표"+check_x+","+check_y);
                }
                else if(click_manager.GetComponent<Click_Manager>().move_btn_first==true&&character[(int)mousePos.x+1,(int)mousePos.y+1]==1)
                {
                    click_manager.GetComponent<Click_Manager>().sell_btn_check=true;
                    target=null;
                }
                else{
                    btn_exist_key=false;
                }
            }
            catch{

            }
            
                
        }
        for(int i=0;i<12;i++){
            for(int j=0;j<7;j++){
                if(character[i,j]==1){
                    player_count++;
                }
            }
        }
        Debug.Log("현재 유닛 수 : "+player_count);
        if(player_count>71){
            reroll_manager.GetComponent<Reroll_Manager>().able_reroll=false;
        }
        if(reroll_manager.GetComponent<Reroll_Manager>().able_reroll==true&&player_count<72)
        {
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
                    Debug.Log("리롤 성공");
                    player_count++;
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