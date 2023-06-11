using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sell_Button_Manager : MonoBehaviour
{
    public bool is_sell=false;
    public Button button;
    public void onClick_up_sell()
    {
        is_sell=true;
    }
    public void onClick_down_sell()
    {
        is_sell=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onClick_up_sell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
