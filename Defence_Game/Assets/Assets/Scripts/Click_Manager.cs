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
        // int tmp_x=character.GetComponent<Character_Manager>().check_x;
        // int tmp_y=character.GetComponent<Character_Manager>().check_y;
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            
            // if(character.GetComponent<Character_Manager>().player_check==true&&move_btn.activeSelf==false)
            // {
            //     move_btn.SetActive(true);
            //     // if(tmp_y==6)
            //     // {
            //     //     tmp_y=5;
            //     // }
            //     // if(tmp_x==11)
            //     // {
            //     //     tmp_x=10;
            //     // }
            //     // if(tmp_x==0)
            //     // {
            //     //     tmp_x=1;
            //     // }
            //     // if(tmp_y==0)
            //     // {
            //     //     tmp_y=1;
            //     // }
            //     // if(character.GetComponent<Character_Manager>().character[tmp_x,tmp_y+1]==0)
            //     // {
            //     //     btn.transform.position=new Vector2(character.GetComponent<Character_Manager>().check_x,character.GetComponent<Character_Manager>().check_y+1); 
            //     // }
            //     // else if(character.GetComponent<Character_Manager>().character[tmp_x,tmp_y-1]==0)
            //     // {
            //     //     btn.transform.position=new Vector2(character.GetComponent<Character_Manager>().check_x,character.GetComponent<Character_Manager>().check_y-1);
            //     // }   
            //     // else if(character.GetComponent<Character_Manager>().character[tmp_x+1,tmp_y]==0)
            //     // {
            //     //     btn.transform.position=new Vector2(character.GetComponent<Character_Manager>().check_x+1,character.GetComponent<Character_Manager>().check_y);
            //     // }
            //     // else if(character.GetComponent<Character_Manager>().character[tmp_x-1,tmp_y]==0)
            //     // {
            //     //     btn.transform.position=new Vector2(character.GetComponent<Character_Manager>().check_x-1,character.GetComponent<Character_Manager>().check_y);
            //     // }
            //     // else
            //     // {
            //     //     btn.SetActive(false);
            //     // }
            // }
            
            // if(mousePos.x==move_btn.transform.position.x&&mousePos.y==move_btn.transform.position.y&&move_btn.activeSelf==true){
            //     move_btn_check=true;
            // }
            // if(GameObject.Find("Sell_Button").GetComponent<Move_Button_Manager>().is_move==true)
            if(character.GetComponent<Character_Manager>().player_check==true&&Move_Button.GetComponent<Move_Button_Manager>().is_move==true)
            {
                
                move_btn_check=true;
            }
            else if(character.GetComponent<Character_Manager>().player_check==true&&Sell_Button.GetComponent<Sell_Button_Manager>().is_sell==true)
            {
                sell_btn_check=true;
            }
            else if(Input.GetMouseButtonDown(0))
            {
                mousePos=Input.mousePosition;
                mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                mousePos.x=Mathf.CeilToInt(mousePos.x);
                mousePos.y=Mathf.CeilToInt(mousePos.y);
                mousePos=new Vector2(mousePos.x,mousePos.y);
            }
            if(move_btn_check==true)
            {
                Debug.Log("버튼 클릭");
                RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance,LayerMask.GetMask("Player"));
                if(hit.collider!=null)
                {
                    character_clicked=true;
                    target=hit.collider.gameObject;
                    Debug.Log(target);
                    if(target.CompareTag("Player")&&target.transform.position.x==character.GetComponent<Character_Manager>().check_x&&target.transform.position.y==character.GetComponent<Character_Manager>().check_y)
                    {
                        
                        Debug.Log("레이 히트");
                        coroutine2=StartCoroutine(second_click());
                        StopCoroutine(coroutine);
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
                        Reroll_Manager.GetComponent<Reroll_Manager>().coin+=30;
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
            
                if(character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]==0)
                {
                    
                        character.GetComponent<Character_Manager>().character[(int)character.GetComponent<Character_Manager>().check_x,(int)character.GetComponent<Character_Manager>().check_y]=0;
                        character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]=1;
                        target.transform.position=new Vector2(mousePos.x,mousePos.y);
                        move_btn_key=0;
                        
                        coroutine=StartCoroutine(first_click());
                        StopCoroutine(coroutine2);
                        Move_Button.GetComponent<Move_Button_Manager>().is_move=false;
                        
                }
                else if(Input.GetMouseButtonDown(0))
                {
                    mousePos=Input.mousePosition;
                    mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                    mousePos.x=Mathf.CeilToInt(mousePos.x);
                    mousePos.y=Mathf.CeilToInt(mousePos.y);
                    mousePos=new Vector2(mousePos.x,mousePos.y);
                }
                
                Debug.Log("플레이어 이동");
            
            yield return null;
        }
    }
}
