using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_move : MonoBehaviour
{
    public float speed=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x<6)
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }
        else{
                
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
    }
}
