using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Manager : MonoBehaviour
{
    Coroutine coroutine;
    Coroutine coroutine2;
    GameObject target=null;
    float max_distance=15f;
    Camera cam;
    public GameObject character;
    public GameObject btn;
    Vector2 mousePos;
    bool btn_check;
    int btn_key=0;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        btn_check=false;
        cam=GetComponent<Camera>();
        coroutine=StartCoroutine(first_click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator first_click()
    {
        
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            if(character.GetComponent<Character_Manager>().player_check==true)
            {
                btn.SetActive(true);
                btn.transform.position=new Vector2(character.GetComponent<Character_Manager>().check_x,character.GetComponent<Character_Manager>().check_y+1);           
            }
            
            if(mousePos.x==btn.transform.position.x&&mousePos.y==btn.transform.position.y){
                    btn_check=true;
            }
            else if(Input.GetMouseButtonDown(0))
            {
                mousePos=Input.mousePosition;
                mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
                mousePos.x=Mathf.CeilToInt(mousePos.x);
                mousePos.y=Mathf.CeilToInt(mousePos.y);
                mousePos=new Vector2(mousePos.x,mousePos.y);
            }
            if(btn_check==true)
            {
                Debug.Log("버튼 클릭");
                RaycastHit2D hit=Physics2D.Raycast(mousePos,transform.forward,max_distance);
                if(hit.collider!=null&&btn_key==0)
                {
                    Debug.Log("레이 히트");
                    target=hit.collider.gameObject;
                    btn_key=1;
                    StopCoroutine(coroutine);
                    coroutine=StartCoroutine(second_click());
                }
                else if(Input.GetMouseButtonDown(0))
                {
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
        yield return new WaitForSeconds(0.1f);
        while(true)
        {    
            if(btn_key==1)
            {
                if(character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]==0)
                {
                        character.GetComponent<Character_Manager>().character[(int)character.GetComponent<Character_Manager>().check_x,(int)character.GetComponent<Character_Manager>().check_y]=0;
                        character.GetComponent<Character_Manager>().character[(int)mousePos.x,(int)mousePos.y]=1;
                        target.transform.position=new Vector2(mousePos.x,mousePos.y);
                        btn_key=0;
                        StopCoroutine(coroutine2);
                        coroutine=StartCoroutine(first_click());
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
            }
            yield return null;
        }
    }
}
