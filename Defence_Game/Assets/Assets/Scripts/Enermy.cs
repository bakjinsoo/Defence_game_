using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Transform center;
    public float speed = 2f; 
    public float radius=5.1f;
    private float angle=0;

    void Start()
    {
        
    }

    void Update()
    {
        angle += Time.deltaTime * speed; 
        transform.position = center.position + new Vector3(Mathf.Cos(angle) , Mathf.Sin(angle),0)*radius;
    }
}
