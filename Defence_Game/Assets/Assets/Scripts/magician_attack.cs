using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magician_attack : MonoBehaviour
{
    public int ui_class_key=0;
    public int magician_grade;
    int count=0;
    int trigger_key=0;
    public GameObject enermy;
    public GameObject fireball;
    Coroutine coroutine;
    GameObject characterAura;
    public bool is_selected;
    public GameObject Legendary_Spell;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // coroutine=StartCoroutine(magicattack());
         int unit_class=Random.Range(0,10000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
            magician_grade=1;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed * 1.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlackAura"), transform.position, Quaternion.identity) as GameObject;
            
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
            magician_grade=2;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed * 1.25f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/RedAura"), transform.position, Quaternion.identity) as GameObject;
           
        }
        else if(unit_class>=13&&unit_class<64)
        {
            this.GetComponent<CircleCollider2D>().radius=2.5f;
            magician_grade=3;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlueAura"), transform.position, Quaternion.identity) as GameObject;
            
        }
        else if(unit_class>=64&&unit_class<565)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
            magician_grade=4;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed * 0.75f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/GreenAura"), transform.position, Quaternion.identity) as GameObject;
            
        }
        else if(unit_class>=565&&unit_class<3566)
        {
            this.GetComponent<CircleCollider2D>().radius=1.5f;
            magician_grade=5;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed * 0.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/PurpleAura"), transform.position, Quaternion.identity) as GameObject;
           
        }
        else{
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Magician_attackSpeed * 0.25f);
            this.GetComponent<CircleCollider2D>().radius=1.2f;
            magician_grade=6;
             
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<Monster_List.Count;i++)
        {
            if(Monster_List[i]==null)
            {
                Monster_List.RemoveAt(i);
            }
        }
        try
        {
            characterAura.transform.position = new Vector2(transform.position.x -0.5f, transform.position.y);
        }
        catch{
            
        }
        if(GameObject.Find("Character_area")==null)
        {
            is_selected=false;
            ui_class_key=0;
        }
        if(is_selected==true&&ui_class_key==0)
        {
             
            Debug.Log("ui 선택됨");
            if(magician_grade==1)
            {
                GameObject ui_class_one=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_0"), transform.position, Quaternion.identity) as GameObject;
                ui_class_one.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(magician_grade==2)
            {
                GameObject ui_class_two=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_1"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_two.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(magician_grade==3)
            {
                GameObject ui_class_three=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_0"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_three.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(magician_grade==4)
            {
                GameObject ui_class_four=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_2"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_four.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                Debug.Log("4등급 클래스 ui 생성");
                ui_class_key++;
            }
            else if(magician_grade==5)
            {
                GameObject ui_class_five=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_1"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_five.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                Debug.Log("5등급 클래스 ui 생성");
                Debug.Log(ui_class_five.name);
                ui_class_key++;
            }
            else if(magician_grade==6)
            {
                GameObject ui_class_six=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_3"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_six.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                Debug.Log("6등급 클래스 ui 생성");
                Debug.Log(ui_class_six.name);
                ui_class_key++;
            }
        }
        else if(is_selected==false&&GameObject.Find("Character_area")==null){
            try{
                if(magician_grade==1)
                {
                    GameObject.Find("ui_class_2_0(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(magician_grade==2)
                {
                    GameObject.Find("ui_class_2_1(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(magician_grade==3)
                {
                    GameObject.Find("ui_class_1_0(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(magician_grade==4)
                {
                    GameObject.Find("ui_class_1_2(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(magician_grade==5)
                {
                    GameObject.Find("ui_class_1_1(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(magician_grade==6)
                {
                    GameObject.Find("ui_class_1_3(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
            }
            catch{

            }
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
            Debug.Log("EXIT" + other.gameObject.GetInstanceID());
        }        
    }
    // IEnumerator magicattack()
    // {
    //     yield return new WaitForSeconds(0.1f);
        
    //     while(count==0)
    //     {
    //         try
    //         {
    //             if(magician_grade==1){
    //                 for(int i=0;i<Monster_List.Count;i++)
    //                 {
    //                     Instantiate(Legendary_Spell,Monster_List[i].transform.position,Quaternion.identity);
    //                 }
    //             }
    //             else if(magician_grade!=1){
    //                 int num=Random.Range(0,Monster_List.Count);
    //                 Instantiate(fireball,Monster_List[num].transform.position,Quaternion.identity);
    //             }
    //         }
    //         catch{

    //         }
            
    //         yield return new WaitForSeconds(2.5f);
            
    //     }
        
    // }
}
