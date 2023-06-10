using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_skill : MonoBehaviour
{
    public GameObject enermy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.GetComponent<Enermy>().hp>0)
        {
            other.GetComponent<Enermy>().hp-=1.5f;
            Debug.Log("현재 적 hp : "+other.GetComponent<Enermy>().hp);
            Destroy(gameObject,1f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
