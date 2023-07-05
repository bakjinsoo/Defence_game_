using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public GameObject fireball;
    public GameObject Legendary_spell;
    AudioSource audio;
    void Start(){
        audio = GetComponent<AudioSource>();
    }

    public void fireballAttack(){
        try
        {
            if(gameObject.GetComponentInChildren<magician_attack>().magician_grade!=1)
            {
                int tmp=gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count;
                if(tmp == 1){

                    GameObject temp = Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[0].transform.position,Quaternion.identity);
                    temp.GetComponent<Fireball_skill>().num=gameObject.GetComponentInChildren<magician_attack>().unit;
                    audio.Play();
                }   
                else{
                    int num=Random.Range(1,gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count);
                    if(tmp>0)
                    {
                        GameObject temp = Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[num].transform.position,Quaternion.identity);
                        temp.GetComponent<Fireball_skill>().num=gameObject.GetComponentInChildren<magician_attack>().unit;
                        audio.Play();

                    }
                }
            }
            else{
                for(int i=0;i<GetComponentInChildren<gunner_attack>().Monster_List.Count;i++)
                {
                    Instantiate(Legendary_spell,GetComponentInChildren<magician_attack>().Monster_List[i].transform.position,Quaternion.identity);
                }
            }
        }
        catch{

        }
    }
}

