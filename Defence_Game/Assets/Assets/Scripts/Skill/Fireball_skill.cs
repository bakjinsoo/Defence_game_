using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_skill : MonoBehaviour
{
    public GameObject enermy;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.GetComponent<Enermy>().hp>0)
        {
            other.GetComponent<Enermy>().hp -= characterData.Instance.MagicianAttackCoefficient * characterData.Instance.MagicianAttackPoints[num];
            other.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(gameObject,1f);
        }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
