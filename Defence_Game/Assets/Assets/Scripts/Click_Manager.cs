using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Manager : MonoBehaviour
{
    public GameObject Reroll_Manager;
    public GameObject Sell_Button;
    public GameObject Move_Button;
    public bool character_clicked=false;
    Coroutine coroutine;
    Coroutine coroutine2;
    GameObject target=null;
    float max_distance=10f;
    Camera cam;
    public GameObject character;
    public GameObject move_btn;
    public GameObject tmp;
    public GameObject show_area;   
    public GameObject ui_selected;
    Vector2 mousePos;
    bool move_btn_check;
    bool sell_btn_check;
    int move_btn_key=0;
    int ui_key=0;
    // Start is called before the first frame update
    void Start()
    {
        
        move_btn_check=false;
        cam=GetComponent<Camera>();
        coroutine=StartCoroutine(first_click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator first_click()
    {
        move_btn_check=false;
        character_clicked=false;
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            if(character.GetComponent<Character_Manager>().player_check==true)
            {
                Move_Button.transform.position=new Vector2(tmp.transform.position.x,tmp.transform.position.y+1);
            }
            else{
                Move_Button.transform.position=new Vector2(100,100);
            }
            if(character.GetComponent<Character_Manager>().player_check==true&&Move_Button.GetComponent<Move_Button_Manager>().is_move==true)
            {
                move_btn_check=true;
            }
            else if(character.GetComponent<Character_Manager>().player_check==true&&Sell_Button.GetComponent<Sell_Button_Manager>().is_sell==true)
            {
                sell_btn_check=true;
            }
            // else if(Input.GetMouseButtonDown(0))
            // {
            //     mousePos=Input.mousePosition;
            //     mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
            //     mousePos.x=Mathf.CeilToInt(mousePos.x);
            //     mousePos.y=Mathf.CeilToInt(mousePos.y);
            //     mousePos=new Vector2(mousePos.x,mousePos.y);
            //     ui_selected.SetActive(false);
            //     show_area.SetActive(false);
            // }
            if(move_btn_check==true)
            {
                Debug.Log("버튼 클릭");
                if(tmp.GetComponent<Player_id>().player_id==1)
                    {
                        Debug.Log("클래스 bool 변수 반환");
                        tmp.GetComponentInChildren<magician_attack>().ui_class_key=0;
                        tmp.GetComponentInChildren<magician_attack>().is_selected=true;
                    }
                    else if(tmp.GetComponent<Player_id>().player_id==2)
                    {
                        tmp.GetComponentInChildren<gunner_attack>().ui_class_key=0;
                        tmp.GetComponentInChildren<gunner_attack>().is_selected=true;
                    }
                    else if(tmp.GetComponent<Player_id>().player_id==3)
                    {
                        tmp.GetComponentInChildren<archer_attack>().ui_class_key=0;
                        tmp.GetComponentInChildren<archer_attack>().is_selected=true;
                    }
                    ui_selected.transform.position=new Vector2(tmp.transform.position.x,tmp.transform.position.y);
                    ui_selected.SetActive(true);
                    show_area.SetActive(true);
                    for(int i=0;i<13;i++)
                    {
                        
                        for(int j=0;j<7;j++)
                        {
                            if(character.GetComponent<Character_Manager>().character[i,j]==1)
                            {
                                GameObject tmp2=Instantiate(Resources.Load<GameObject>("Prefabs/character_area_ui"));
                                tmp2.transform.position=new Vector3(i,j,0);
                            }
                        }
                    }
                    coroutine2=StartCoroutine(second_click());
                    StopCoroutine(coroutine);
                // RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance,LayerMask.GetMask("Player"));
                // if(hit.collider!=null)
                // {
                //     character_clicked=true;
                //     target=hit.collider.gameObject;
                //     Debug.Log(target);
                //     if(target.CompareTag("Player")&&target.transform.position.x==character.GetComponent<Character_Manager>().check_x&&target.transform.position.y==character.GetComponent<Character_Manager>().check_y)
                //     {
                        
                //         Debug.Log("레이 히트");
                //         coroutine2=StartCoroutine(second_click());
                //         StopCoroutine(coroutine);
                //     }
                // }
                // else if(Input.GetMouseButtonDown(0))
                // {
                //     character_clicked=false;
                //     mousePos=Input.mousePosition;
                //     mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                //     mousePos.x=Mathf.CeilToInt(mousePos.x);
                //     mousePos.y=Mathf.CeilToInt(mousePos.y);
                //     mousePos=new Vector2(mousePos.x,mousePos.y);
                // }
            }
            else if(sell_btn_check==true)
            {
                RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance,LayerMask.GetMask("Player"));
                if(hit.collider!=null)
                {
                    character_clicked=true;
                    target=hit.collider.gameObject;
                    if(target.CompareTag("Player")&&target.transform.position.x==character.GetComponent<Character_Manager>().check_x&&target.transform.position.y==character.GetComponent<Character_Manager>().check_y)
                    {
                        Debug.Log("레이 히트");
                        Reroll_Manager.GetComponent<Reroll_Manager>().coin+= characterData.Instance.moneyGet;
                        character.GetComponent<Character_Manager>().character[(int)character.GetComponent<Character_Manager>().check_x,(int)character.GetComponent<Character_Manager>().check_y]=0;
                        Destroy(target);
                    }
                }
                else if(Input.GetMouseButtonDown(0))
                {
                    character_clicked=false;
                    mousePos=Input.mousePosition;
                    mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                    mousePos.x=Mathf.CeilToInt(mousePos.x);
                    mousePos.y=Mathf.CeilToInt(mousePos.y);
                    mousePos=new Vector2(mousePos.x,mousePos.y);
                }
                
            }
            yield return null;
        }
    }
    IEnumerator second_click()
    {
        character_clicked=false;
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            // move_btn.SetActive(false);    
            if(Input.GetMouseButtonDown(0))
            {
                mousePos=Input.mousePosition;
                mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                mousePos.x=Mathf.CeilToInt(mousePos.x);
                mousePos.y=Mathf.CeilToInt(mousePos.y);
                mousePos=new Vector2(mousePos.x,mousePos.y);
                if(character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]==0)
                {
                    
                        character.GetComponent<Character_Manager>().character[(int)character.GetComponent<Character_Manager>().check_x,(int)character.GetComponent<Character_Manager>().check_y]=0;
                        character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]=1;
                        tmp.transform.position=new Vector2(mousePos.x,mousePos.y);
                        move_btn_key=0;
                        coroutine=StartCoroutine(first_click());
                        StopCoroutine(coroutine2);
                        Move_Button.GetComponent<Move_Button_Manager>().is_move=false;
                        
                }
            }
                
                Debug.Log("플레이어 이동");
            
            yield return null;
        }
    }
}
