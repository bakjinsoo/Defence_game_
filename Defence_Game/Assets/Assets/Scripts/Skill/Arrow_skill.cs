using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_skill : MonoBehaviour
{
    
    public GameObject archer;
    public GameObject enermy;
    public float speed=1f;


    public int num;
    public float offset = 0.3f;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = enermy.GetComponent<Enermy>().returnPos();
        pos.x += offset * enermy.GetComponent<Enermy>().speed;
    }
   void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag=="Enermy")
        {   
            Debug.Log(num);
            other.GetComponent<Enermy>().hp -= characterData.Instance.ArcherAttackCoefficient * characterData.Instance.ArcherAttackPoints[num];
            other.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(this.gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {   
        // Vector2  pos = enermy.GetComponent<Enermy>().returnPos();
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if(transform.position.x==pos.x && transform.position.y==pos.y)
        {
            Destroy(this.gameObject);
        }
        
    }

}
