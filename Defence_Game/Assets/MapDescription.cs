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
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in players) // HSV 값에서 V 값 70으로 변경
            {
                player.GetComponent<SpriteRenderer>().color =  Color.grey;
            }
            GameObject tmp = GameObject.Find("BrightForest");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/DarkForest") as GameObject);
        }
        else if(stageNum == 21)
        {
            GameObject tmp = GameObject.Find("DarkForest(Clone)");
            Debug.Log("MapName" + tmp.name);
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in players) // 
            {
                player.GetComponent<SpriteRenderer>().color =  Color.white; 
            }
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/Temple") as GameObject);
        }
        else if(stageNum == 31)
        {
            GameObject tmp = GameObject.Find("Temple(Clone)");
            Debug.Log("MapName" + tmp.name);
            Destroy(tmp);
            Instantiate(Resources.Load("Prefabs/devilDungeon") as GameObject);
        }
    }

    
}
