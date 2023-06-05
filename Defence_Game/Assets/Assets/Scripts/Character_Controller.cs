using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    Vector2 mousePos;//마우스로 찍은 좌표
    public bool player_check;//플레이어인지 확인하는 변수
    // Start is called before the first frame update
    void Start()
    {
        player_check=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("클릭");
            mousePos=Input.mousePosition;
            mousePos=Camera.main.ScreenToWorldPoint(mousePos);         
            mousePos.x=Mathf.CeilToInt(mousePos.x);
            mousePos.y=Mathf.CeilToInt(mousePos.y);
            mousePos=new Vector2(mousePos.x,mousePos.y);
            if(mousePos.x==this.transform.position.x&&mousePos.y==this.transform.position.y)
            {
                player_check=true;
            }
            else
            {
                player_check=false;
            }
                
        }
        
       
        
    }
}
