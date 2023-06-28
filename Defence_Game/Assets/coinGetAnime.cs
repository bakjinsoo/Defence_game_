using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGetAnime : MonoBehaviour
{
    Transform coin;
    float soundVolume;
    void Start()
    {
        soundVolume = GameObject.Find("StopGame").GetComponent<StopButton>().saveEffectsSlider;
        GetComponent<AudioSource>().volume = soundVolume;
        CoinMove();
    }
    public void CoinMove(){

        coin = GameObject.Find("Coin").transform;
        StartCoroutine(CoinMoveCoroutine());

    }
    IEnumerator CoinMoveCoroutine(){
        while(Vector3.Distance(coin.position,transform.position) > 0.3f){
            transform.position = Vector3.MoveTowards(transform.position,coin.position,300f * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
