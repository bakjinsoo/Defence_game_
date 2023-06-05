using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Movement : MonoBehaviour
{
    public Button button;
    public bool button_check;//버튼이 눌렸는지 확인하는 변수
    // Start is called before the first frame update
    public void Awake()
    {
        button.onClick.AddListener(movement_check);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void movement_check()
    {
        button_check=true;
    }
}
