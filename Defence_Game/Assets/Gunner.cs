using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject Legendary_bullet;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void gunAttack(){
        try
        {
            if(gameObject.GetComponentInChildren<gunner_attack>().gunner_grade!=1)
            {
                int tmp=gameObject.GetComponentInChildren<gunner_attack>().Monster_List.Count;
                if(tmp == 1){
                    Instantiate(bullet,gameObject.GetComponentInChildren<gunner_attack>().Monster_List[0].transform.position,Quaternion.identity);
                    GetComponent<AudioSource>().Play();
                }
                else{
                    int num=Random.Range(1,gameObject.GetComponentInChildren<gunner_attack>().Monster_List.Count);
                    if(tmp>0)
                    {
                        Instantiate(bullet,gameObject.GetComponentInChildren<gunner_attack>().Monster_List[num].transform.position,Quaternion.identity);
                        GetComponent<AudioSource>().Play();
                    }
                }
            }
            else{
                for(int i=0;i<GetComponentInChildren<gunner_attack>().Monster_List.Count;i++)
                {
                    Instantiate(Legendary_bullet,GetComponentInChildren<gunner_attack>().Monster_List[i].transform.position,Quaternion.identity);
                }
            }
        }
        catch{

        }
    }

}
