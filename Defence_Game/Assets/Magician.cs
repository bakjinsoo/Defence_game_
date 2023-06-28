using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public GameObject fireball;
    public GameObject Legendary_Spell;
    public void fireballAttack(){
        try
        {
            if(gameObject.GetComponentInChildren<magician_attack>().magician_grade!=1)
            {
                int tmp=gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count;
                if(tmp == 1){
                    Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[0].transform.position,Quaternion.identity);
                }
                else{
                    int num=Random.Range(1,gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count);
                    if(tmp>0)
                    {
                        Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[num].transform.position,Quaternion.identity);
                    }
                }
            }
            else{
                for(int i=0;i<gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count;i++)
                    {
                        Instantiate(Legendary_Spell,gameObject.GetComponentInChildren<magician_attack>().Monster_List[i].transform.position,Quaternion.identity);
                    }
            }
        }
        catch{

        }
    }
}

