using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public GameObject fireball;
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

                    Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[0].transform.position,Quaternion.identity);
                    audio.Play();
                }   
                else{
                    int num=Random.Range(1,gameObject.GetComponentInChildren<magician_attack>().Monster_List.Count);
                    if(tmp>0)
                    {
                        Instantiate(fireball,gameObject.GetComponentInChildren<magician_attack>().Monster_List[num].transform.position,Quaternion.identity);
                        audio.Play();

                    }
                }
            }
        }
        catch{

        }
    }
}

