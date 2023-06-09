using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    
    // Start is called before the first frame update
    Reroll_Manager CoinGetter;
    TextMeshProUGUI coin_Count;
    void Start()
    {
        CoinGetter = GameObject.Find("Reroll_Button").GetComponent<Reroll_Manager>();
        coin_Count = GameObject.Find("Coin_Count").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log(CoinGetter.coin.ToString());
        coin_Count.text = CoinGetter.coin.ToString();
    }
}
