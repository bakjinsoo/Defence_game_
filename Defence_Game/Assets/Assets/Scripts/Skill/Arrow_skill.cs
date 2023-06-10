using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_skill : MonoBehaviour
{
    
    public GameObject archer;
    public GameObject enermy;
    public float speed=1f;
    public int num;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
   void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Enermy")
        {
            other.GetComponent<Enermy>().hp -= characterData.Instance.Archer_AttackPoint;
            Debug.Log("현재 적 hp : "+other.GetComponent<Enermy>().hp);
            Destroy(this.gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(enermy.transform.position*speed*Time.deltaTime);
    }

}
