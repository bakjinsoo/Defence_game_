using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_ui_class : MonoBehaviour
{
    public bool is_deleted;
    public int ui_class;
    public GameObject target_ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(is_deleted==true)
       {
            Destroy(gameObject);
       }
    }
    void OnDestroy()
    {
        Debug.Log("삭제");
    }
}
