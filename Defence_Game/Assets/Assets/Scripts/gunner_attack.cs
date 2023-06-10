using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunner_attack : MonoBehaviour
{
    
    int count=0;
    int trigger_key=0;
    public GameObject enermy;
    public GameObject bullet;
    public GameObject character_manger;
    Coroutine coroutine;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        coroutine=StartCoroutine(gunnerattack());
       int unit_class=Random.Range(0,10000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
        }
        else if(unit_class>=13&&unit_class<64)
        {
            this.GetComponent<CircleCollider2D>().radius=2.5f;
        }
        else if(unit_class>=64&&unit_class<565)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
        }
        else if(unit_class>=565&&unit_class<3566)
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
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enermy")
        {
            Monster_List.RemoveAt(0);
        }        
    }
    IEnumerator gunnerattack()
    {
        yield return new WaitForSeconds(0.1f);
        
        while(count==0)
        {
            try
            {
                int num=Random.Range(0,Monster_List.Count);
               Instantiate(bullet,Monster_List[num].transform.position,Quaternion.identity);
            }
            catch{

            }
            
            yield return new WaitForSeconds(0.5f);
            
        }
        
    }
}
