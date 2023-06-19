using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_disable_ui : MonoBehaviour
{
    public GameObject Character_Manager;
    public GameObject show;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.Find("Character_area")==null)
       {
            Destroy(this.gameObject);
       }
    }
}
