using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_attack : MonoBehaviour
{
    public GameObject arrow;
    public float speed=10f;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(arrow_skill());
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
    IEnumerator arrow_skill()
    {
        while(true)
        {
            try
            {
               
               int num=Random.Range(0,Monster_List.Count);
            //    Vector3 pos=Monster_List[num].transform.position-this.transform.position;
            //    float angle=Mathf.Atan2(pos.y,pos.x)*Mathf.Rad2Deg;
            //    Quaternion rotation=Quaternion.AngleAxis(angle,Vector3.forward);
            //    GameObject tmp=Instantiate(arrow,this.transform.position,new Quaternion(0,0,angle,0));
               GameObject tmp=Instantiate(arrow,this.transform.position,Quaternion.identity);
               tmp.GetComponent<Arrow_skill>().enermy=Monster_List[num];
            }
            catch
            {

            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
