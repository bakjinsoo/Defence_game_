using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_skill : MonoBehaviour
{
    public GameObject enermy;
    public float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay2D()
    {
        Debug.Log("충돌");
        if(enermy.GetComponent<Enermy>().hp>0)
        {
            enermy.GetComponent<Enermy>().hp-=20;
            Debug.Log("현재 적 hp : "+enermy.GetComponent<Enermy>().hp);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x<6)
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }
        else{
                
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
    }
}
