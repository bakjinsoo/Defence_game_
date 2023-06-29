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
    public bool move_btn_check;
    public bool move_btn_first;
    public bool sell_btn_check;
    int move_btn_key=0;
    int ui_key=0;
    // Start is called before the first frame update
    void Start()
    {
        sell_btn_check=false;
        move_btn_check=false;
        cam=GetComponent<Camera>();
        coroutine=StartCoroutine(first_click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector2 savepos;
    public int sell_key;
    IEnumerator first_click()
    {
        sell_btn_check=false;
        move_btn_first=false;
        move_btn_check=false;
        character_clicked=false;
        sell_key=0;
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            try{
                if(character.GetComponent<Character_Manager>().player_check==true)
                {
                    Move_Button.transform.position=new Vector2(tmp.transform.position.x-0.5f,tmp.transform.position.y+0.5f);
                    Sell_Button.transform.position=new Vector2(tmp.transform.position.x+0.5f,tmp.transform.position.y+0.5f);
                    move_btn_first=true;
                    
                    Debug.Log("버튼 이동");
                }
                else{
                    Move_Button.transform.position=new Vector2(100,100);
                    Sell_Button.transform.position=new Vector2(101,100);
                }
            }
            catch{

            }
            if(move_btn_check==true)
            {
                try{
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
                }
                catch{

                }
            }
            else if(sell_btn_check==true)
            {
                Destroy(tmp);
                tmp=null;
                if(sell_key==0){
                    Reroll_Manager.GetComponent<Reroll_Manager>().coin+=characterData.Instance.moneyGet;
                    sell_key++;                    
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
                        character.GetComponent<Character_Manager>().first_target_key=0;
                        character.GetComponent<Character_Manager>().btn_exist_key=false;
                        character.GetComponent<Character_Manager>().player_check=false;
                }
            } 
            Debug.Log("플레이어 이동");
            yield return null;
        }
    }
}
