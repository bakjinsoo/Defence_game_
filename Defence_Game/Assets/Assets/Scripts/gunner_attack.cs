using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gunner_attack : MonoBehaviour
{
    public int ui_class_key=0;
    public int gunner_grade;
    int count=0;
    int trigger_key=0;
    public GameObject enermy;
    public GameObject bullet;
    public GameObject character_manger;
    Coroutine coroutine;
    public bool is_selected;
    public List<GameObject> Monster_List=new List<GameObject>();
    GameObject characterAura;
    public GameObject Legendary_bullet;
    public int unit;
    // Start is called before the first frame update
    void Start()
    {
       int unit_class=Random.Range(0,10000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
            gunner_grade=1;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Gunner_attackSpeed * 1.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlackAura"), transform.position, Quaternion.identity) as GameObject;
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit = 5;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "갓 유닛이 필드에 등장했습니다!";
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
            gunner_grade=2;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Gunner_attackSpeed * 1.25f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/RedAura"), transform.position, Quaternion.identity) as GameObject;
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit= 4;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "히어로 유닛이 필드에 등장했습니다!";
        }
        else if(unit_class>=13&&unit_class<64)
        {
            this.GetComponent<CircleCollider2D>().radius=2.5f;
            gunner_grade=3;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Gunner_attackSpeed);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlueAura"), transform.position, Quaternion.identity) as GameObject;
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit = 3;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "레전더리 유닛이 필드에 등장했습니다!";
        }
        else if(unit_class>=64&&unit_class<565)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
            gunner_grade=4;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed",  characterData.Instance.Gunner_attackSpeed * 0.75f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/GreenAura"), transform.position, Quaternion.identity) as GameObject;
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit = 2;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "유니크 유닛이 필드에 등장했습니다!";
        }
        else if(unit_class>=565&&unit_class<3566)
        {
            this.GetComponent<CircleCollider2D>().radius=1.5f;
            gunner_grade=5;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", characterData.Instance.Gunner_attackSpeed * 0.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/PurpleAura"), transform.position, Quaternion.identity) as GameObject;
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit = 1;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "에픽 유닛이 필드에 등장했습니다!";
        }
        else{
            this.GetComponent<CircleCollider2D>().radius=1.2f;
            gunner_grade=6;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed",  characterData.Instance.Gunner_attackSpeed * 0.25f);
            GameObject tmp = Instantiate(Resources.Load("Prefabs/GradeAlarm") as GameObject);
            unit = 0;
            tmp.transform.GetChild(0).gameObject.GetComponent<Text>().text = "레어 유닛이 필드에 등장했습니다!";
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
        try{
            characterAura.transform.position = new Vector2(transform.position.x -0.5f, transform.position.y);
        }catch{

        }
        if(GameObject.Find("Character_area")==null)
        {
            is_selected=false;
            ui_class_key=0;
        }
        if(is_selected==true&&ui_class_key==0)
        {
             
            Debug.Log("ui 선택됨");
            if(gunner_grade==1)
            {
                GameObject ui_class_one=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_0"), transform.position, Quaternion.identity) as GameObject;
                ui_class_one.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(gunner_grade==2)
            {
                GameObject ui_class_two=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_1"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_two.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(gunner_grade==3)
            {
                GameObject ui_class_three=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_0"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_three.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                ui_class_key++;
            }
            else if(gunner_grade==4)
            {
                GameObject ui_class_four=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_2"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_four.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                Debug.Log("4등급 클래스 ui 생성");
                ui_class_key++;
            }
            else if(gunner_grade==5)
            {
                GameObject ui_class_five=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_1"), this.transform.position, Quaternion.identity) as GameObject;
                ui_class_five.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+1,0);
                Debug.Log("5등급 클래스 ui 생성");
                Debug.Log(ui_class_five.name);
                ui_class_key++;
            }
            else if(gunner_grade==6)
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
                if(gunner_grade==1)
                {
                    GameObject.Find("ui_class_2_0(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(gunner_grade==2)
                {
                    GameObject.Find("ui_class_2_1(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(gunner_grade==3)
                {
                    GameObject.Find("ui_class_1_0(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(gunner_grade==4)
                {
                    GameObject.Find("ui_class_1_2(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(gunner_grade==5)
                {
                    GameObject.Find("ui_class_1_1(Clone)").GetComponent<Destroy_ui_class>().is_deleted=true;
                }
                else if(gunner_grade==6)
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
        }        
    }


    void OnDestroy()
    {
        Destroy(characterAura);
    }

}

