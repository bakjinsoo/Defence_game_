using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Button_Manager : MonoBehaviour
{
    public bool is_move=false;
    public Button button;
    public void onClick_up_move()
    {
        is_move=true;
    }
    public void onClick_down_move()
    {
        is_move=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClick_up_move);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
