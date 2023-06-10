using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_attack : MonoBehaviour
{
    public GameObject arrow;
    public int attack_trigger=0;
    public float speed=10f;
    public GameObject character_manger;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(arrow_skill());
        int unit_class=Random.Range(0,1000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
        }
        else if(unit_class>=13&&unit_class<51)
        {
            this.GetComponent<CircleCollider2D>().radius=2.5f;
        }
        else if(unit_class>=51&&unit_class<102)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
        }
        else if(unit_class>=102&&unit_class<331)
        {
            this.GetComponent<CircleCollider2D>().radius=1.5f;
        }
        else{
            this.GetComponent<CircleCollider2D>().radius=1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enermy")
        {
            Monster_List.Add(other.gameObject);
            attack_trigger++;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enermy")
        {
            Monster_List.RemoveAt(0);
        }        
    }
    IEnumerator arrow_skill()
    {

        while(true)
        {
            if(attack_trigger>0)
            {
                try
                {
                
                    int num=Random.Range(0,Monster_List.Count);
                    //    Vector3 pos=Monster_List[num].transform.position-this.transform.position;
                    //    float angle=Mathf.Atan2(pos.y,pos.x)*Mathf.Rad2Deg;
                    //    Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
                    //    GameObject tmp=Instantiate(arrow,this.transform.position,new Quaternion(0,0,angle,0));
                    GameObject tmp=Instantiate(arrow,this.transform.position,Quaternion.identity);
                    if(Monster_List[num]==null)
                    {
                            num=Random.Range(0,Monster_List.Count);
                    }
                    else{
                            tmp.GetComponent<Arrow_skill>().enermy=Monster_List[num];
                    }
                
                }
                catch
                {

                }
            }
            
            attack_trigger=0;
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
