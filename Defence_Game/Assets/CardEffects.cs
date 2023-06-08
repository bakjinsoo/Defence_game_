using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
 
    public void TimeResetToOne(){
        Time.timeScale = 1;
        Destroy(GameObject.Find("CardsList"));
    }

}
