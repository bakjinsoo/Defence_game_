using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunner_attack : MonoBehaviour
{
    
    int count=0;
    int trigger_key=0;
    public GameObject enermy;
    public GameObject bullet;
    Coroutine coroutine;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        coroutine=StartCoroutine(gunnerattack());
        
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
        
        // if(trigger_key==0)
        // {
        //     trigger_key++;
        //     Debug.Log("범위감지");
        //     coroutine=StartCoroutine(gunnerattack());
            
        // }
        // else if(coroutine==null)
        // {
        //     Debug.Log("트리거키 초기화");
        //     trigger_key=0;
        //     count=0;
        // }
        // trigger_key++;
        
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enermy")
        {
            Monster_List.RemoveAt(0);
        }
        
        // if(trigger_key>16)
        // {
        //     Debug.Log("트리거키 초기화");
        //     trigger_key=0;
        //     count=0;
        // }
        
        
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
            
            // count++;
            
            // StopCoroutine(coroutine);
            yield return new WaitForSeconds(0.5f);
            
        }
        
    }
}
