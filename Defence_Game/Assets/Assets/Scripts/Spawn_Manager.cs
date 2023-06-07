using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawn_Manager : MonoBehaviour
{
    public GameObject[] enemies;
    public int enermyCount=25;
    // Start is called before the first frame update
    public int round = 0;
    public int leftCount = 0;
    public TextMeshProUGUI leftMob;
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawn()
    {
        for(int i=0;i<enermyCount;i++)
        {
            Instantiate(enemies[round], new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
            leftCount++;
            leftMob.text = leftCount.ToString();
            yield return new WaitForSeconds(0.5f);

        }
    }
}
