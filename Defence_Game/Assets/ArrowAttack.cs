using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject arrow;
    public void arrow_skill()
    {
        // gameObject.GetComponentInChildren<archer_attack>().Monster_List;


            int num=Random.Range(0,gameObject.GetComponentInChildren<archer_attack>().Monster_List.Count);
            //    Vector3 pos=Monster_List[num].transform.position-this.transform.position;
            //    float angle=Mathf.Atan2(pos.y,pos.x)*Mathf.Rad2Deg;
            //    Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
            //    GameObject tmp=Instantiate(arrow,this.transform.position,new Quaternion(0,0,angle,0));
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            if(gameObject.GetComponentInChildren<archer_attack>().Monster_List.Count>0){
                GameObject tmp=Instantiate(arrow,this.transform.position,Quaternion.identity);
                tmp.GetComponent<Arrow_skill>().num=gameObject.GetComponentInChildren<archer_attack>().unit;
                
                if(gameObject.GetComponentInChildren<archer_attack>().Monster_List[num]==null)
                {
                    num=Random.Range(0,gameObject.GetComponentInChildren<archer_attack>().Monster_List.Count);
                }
                else{
                    tmp.GetComponent<Arrow_skill>().enermy=gameObject.GetComponentInChildren<archer_attack>().Monster_List[num];
                }
            }

    }

    

        
    
    
}