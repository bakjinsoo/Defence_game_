using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_attack : MonoBehaviour
{
    public GameObject arrow;
    public float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(arrowattack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator arrowattack()
    {
        yield return new WaitForSeconds(0.1f);
        while(true)
        {
            if(this.transform.position.x<6)
            {
                GameObject tmp=Instantiate(arrow,this.transform.position,this.transform.rotation);
                
            }
            else{
                GameObject tmp=Instantiate(arrow,this.transform.position,this.transform.rotation);
            }
            
            yield return new WaitForSeconds(2f);
        }
    }
}
