using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_skill : MonoBehaviour
{
    public GameObject enermy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnTriggerStay2D()
    {
        
        if(enermy.GetComponent<Enermy>().hp>0)
        {
            enermy.GetComponent<Enermy>().hp-=20;
            Debug.Log("현재 적 hp : "+enermy.GetComponent<Enermy>().hp);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
