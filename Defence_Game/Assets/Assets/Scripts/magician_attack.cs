using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magician_attack : MonoBehaviour
{
    public int magician_grade;
    public GameObject ui_class;
    int count=0;
    int trigger_key=0;
    public GameObject enermy;
    public GameObject fireball;
    Coroutine coroutine;
    GameObject characterAura;
    public GameObject target_ui;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        coroutine=StartCoroutine(magicattack());
         int unit_class=Random.Range(0,10000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
            magician_grade=1;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 3f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlackAura"), transform.position, Quaternion.identity) as GameObject;
            ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_0"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
            magician_grade=2;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 2.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/RedAura"), transform.position, Quaternion.identity) as GameObject;
            ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_1"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        else if(unit_class>=13&&unit_class<64)
        {
            this.GetComponent<CircleCollider2D>().radius=2.5f;
            magician_grade=3;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 2f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlueAura"), transform.position, Quaternion.identity) as GameObject;
            ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_0"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        else if(unit_class>=64&&unit_class<565)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
            magician_grade=4;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 1.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/GreenAura"), transform.position, Quaternion.identity) as GameObject;
            ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_2"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        else if(unit_class>=565&&unit_class<3566)
        {
            this.GetComponent<CircleCollider2D>().radius=1.5f;
            magician_grade=5;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 1.0f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/PurpleAura"), transform.position, Quaternion.identity) as GameObject;
            ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_1"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        else{
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 0.5f);
            this.GetComponent<CircleCollider2D>().radius=1.2f;
            magician_grade=6;
             ui_class=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_3"), transform.position, Quaternion.identity) as GameObject;
            ui_class.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            characterAura.transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
        }
        catch{

        }
         
        
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
    IEnumerator magicattack()
    {
        yield return new WaitForSeconds(0.1f);
        
        while(count==0)
        {
            try
            {
                int num=Random.Range(0,Monster_List.Count);
               Instantiate(fireball,Monster_List[num].transform.position,Quaternion.identity);
            }
            catch{

            }
            
            yield return new WaitForSeconds(2.5f);
            
        }
        
    }
}
