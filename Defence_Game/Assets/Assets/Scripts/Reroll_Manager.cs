using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reroll_Manager : MonoBehaviour
{
    public int coin=500;
    public Button button;
    bool isreroll = false;
    public bool able_reroll = false;
    public GameObject character_manager;
    public void Awake()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(onclick_up_Reroll);
    }
    public void onclick_up_Reroll()
    {
        isreroll = true;
        Debug.Log("버튼업");
    }
    public void onclick_down_Reroll()
    {
        isreroll = false;
        Debug.Log("버튼다운");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isreroll)
        {   
            int r = Random.Range(0,100);
            if(characterData.Instance.freeReroll > r){
                able_reroll=true;
                isreroll=false;
                Debug.Log("사건발생");
            }
            else if(coin>=50&&character_manager.GetComponent<Character_Manager>().player_count<72)
            {
                coin-=50;
                able_reroll=true;
                isreroll=false;
            }
            else{
                able_reroll=false;
            }
        }
    }
}
