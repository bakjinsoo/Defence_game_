using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    public void stopTime()
    {
        Time.timeScale=0;
    }
    public void DestroyObj(){
        Destroy(this.gameObject, 0.1f);
    }

}
