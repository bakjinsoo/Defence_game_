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
        if(stageNum == 10)
        {
            Debug.Log("MapChange to BrightForest");
            GameObject tmp = GameObject.Find("BrightForest");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/DarkForest") as GameObject);
        }
        else if(stageNum == 20)
        {
            GameObject tmp = GameObject.Find("DarkForest(Clone)");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/Temple") as GameObject);
        }
        else if(stageNum == 30)
        {
            GameObject tmp = GameObject.Find("Temple(Clone)");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/devilDungeon") as GameObject);
        }
    }

    
}
