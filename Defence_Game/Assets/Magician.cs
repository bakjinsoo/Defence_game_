using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public GameObject fireball;

    public void fireballAttack(){
        try
        {
            if(gameObject.GetComponentInChildren<magician_attack>().magician_grade!=1)
            {
                int num=Random.Range(0,gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count);
                Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[num].transform.position,Quaternion.identity);
            }
        }
        catch{

        }
    }
}
