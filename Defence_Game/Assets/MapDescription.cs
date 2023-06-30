using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDescription : MonoBehaviour
{
    
    public void MapChange()
    {
        Debug.Log("MapChange");
        int stageNum = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>().round;
        Debug.Log("stageNum" + stageNum);
        if(stageNum == 11)
        {
            Debug.Log("MapChange to BrightForest");
            GameObject tmp = GameObject.Find("BrightForest");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/DarkForest") as GameObject);
        }
        else if(stageNum == 21)
        {
            GameObject.Find("BrightForest").SetActive(false);
            GameObject.Find("DarkForest").SetActive(true);
        }
        else if(stageNum == 31)
        {
            GameObject.Find("BrightForest").SetActive(false);
            GameObject.Find("DarkForest").SetActive(true);
        }
    }

    
}
