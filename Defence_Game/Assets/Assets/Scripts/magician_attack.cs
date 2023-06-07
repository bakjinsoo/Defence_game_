using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magician_attack : MonoBehaviour
{
    public GameObject fireball;
    public float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(magicianattack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator magicianattack()
    {
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            if(this.transform.position.x<6)
            {
                GameObject tmp=Instantiate(fireball,this.transform.position,this.transform.rotation);
                
            }
            else{
                GameObject tmp=Instantiate(fireball,this.transform.position,this.transform.rotation);
                
            }
            
            yield return new WaitForSeconds(2f);
        }
    }
}
