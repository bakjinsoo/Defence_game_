using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public float hp=100f;
    public Transform center;//enermy collider프리펩의 위치 조정을 통한 적의 타원형운동 반복
    public float speed = 2f; 
    public float radius=4.8f;
    private float angle=0;
    void OnColisionStay2D()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        angle += Time.deltaTime * speed; 
        
        transform.position = center.position + new Vector3(Mathf.Cos(angle)*1.6f , Mathf.Sin(angle)*0.9f,0)*radius;
    }
}
