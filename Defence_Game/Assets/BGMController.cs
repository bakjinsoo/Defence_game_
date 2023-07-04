using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

    Spawn_Manager spawn_manager;
    void Start(){
        spawn_manager = GameObject.Find("SpawnManager").GetComponent<Spawn_Manager>();
    }
    void Update()
    {
        if((spawn_manager.round + 1 == 10 || spawn_manager.round + 1 == 20 || spawn_manager.round + 1 == 30) && spawn_manager.leftCount == 0)
        {
            AudioClip clip = Resources.Load<AudioClip>("Prefabs/sound/BossBGM");
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
        }
        if((spawn_manager.round+1 == 11 || spawn_manager.round + 1 ==21) && spawn_manager.leftCount == 0)
        {
            AudioClip clip = Resources.Load<AudioClip>("Prefabs/sound/NormalStageBGM");
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
        }
    }
}
