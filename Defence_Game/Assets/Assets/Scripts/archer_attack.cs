using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_attack : MonoBehaviour
{
    public int unit;
    public GameObject arrow;
    public int attack_trigger=0;
    public float speed=10f;
    public GameObject character_manger;
    public List<GameObject> Monster_List=new List<GameObject>();
    // Start is called before the first frame update
    GameObject characterAura;
    void Start()
    {
        // StartCoroutine(arrow_skill());
         int unit_class=Random.Range(0,10000);
        if(unit_class<3)
        {
            this.GetComponent<CircleCollider2D>().radius=5f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 3f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlackAura"), transform.position, Quaternion.identity) as GameObject;
            unit=5;
        }
        else if(unit_class>=3&&unit_class<13)
        {
            this.GetComponent<CircleCollider2D>().radius=3.2f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 2.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/RedAura"), transform.position, Quaternion.identity) as GameObject;
            unit=4;
        }
        else if(unit_class>=13&&unit_class<64)
        {

            this.GetComponent<CircleCollider2D>().radius=2.5f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 2f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlueAura"), transform.position, Quaternion.identity) as GameObject;
            unit=3;
        }
        else if(unit_class>=64&&unit_class<565)
        {
            this.GetComponent<CircleCollider2D>().radius=2f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 1.5f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/GreenAura"), transform.position, Quaternion.identity) as GameObject;
            unit=2;
        }
        else if(unit_class>=565&&unit_class<3566)
        {
            this.GetComponent<CircleCollider2D>().radius=1.5f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 1f);
            characterAura = Instantiate(Resources.Load("Prefabs/Aura/PurpleAura"), transform.position, Quaternion.identity) as GameObject;
            unit=1;
        }
        else{
            this.GetComponent<CircleCollider2D>().radius=1.2f;
            this.GetComponentInParent<Animator>().SetFloat("AttackSpeed", 0.5f);
            unit=0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        characterAura.transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
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
}
