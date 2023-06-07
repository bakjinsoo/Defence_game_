using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunner_attack : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gunnerattack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator gunnerattack()
    {
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            if(this.transform.position.x<6)
            {
                GameObject tmp=Instantiate(bullet,this.transform.position,Quaternion.identity);
                tmp.transform.position=new Vector2(tmp.transform.position.x-4f,tmp.transform.position.y);
            }
            else{
                GameObject tmp=Instantiate(bullet,this.transform.position,Quaternion.identity);
                tmp.transform.position=new Vector2(tmp.transform.position.x+4f,tmp.transform.position.y);
            }
            
            yield return new WaitForSeconds(2f);
        }
    }
}
