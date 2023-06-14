using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void gunAttack(){
        try
        {
            int num=Random.Range(0,gameObject.GetComponentInChildren<gunner_attack>().Monster_List.Count);
            Instantiate(bullet,gameObject.GetComponentInChildren<gunner_attack>().Monster_List[num].transform.position,Quaternion.identity);
        }
        catch{

        }
    }

}
