using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_skill : MonoBehaviour
{
    public GameObject enermy;
    // Start is called before the first frame update
    public int num;
    void Start()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.GetComponent<Enermy>().hp>0)
        {
            other.GetComponent<Enermy>().hp -= characterData.Instance.GunnerAttackCoefficient * characterData.Instance.GunnerAttackPoints[num];
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
