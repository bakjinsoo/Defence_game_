using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Spawn_Manager : MonoBehaviour
{
    public GameObject[] enemies;
    public int enermyCount=25;
    // Start is called before the first frame update
    public int round = 0;
    public int leftCount = 0;
    public TextMeshProUGUI leftMob;
    bool isSpawnEnded = true; // spawn 이 다 끝나고 몬스터가 0이면 스테이지 오버를 체크하기 위함
    GameObject CardsList;
    private int cardNum;
    public int cardIndex; // resources폴더 내에 있는 카드 개수
    [SerializeField]
    private GameObject StageEndPanel;
    [SerializeField]
    private GameObject StageStartPanel;
    List<GameObject> cardList = new List<GameObject>();
    private TimeManager timeManager;
    void Start()
    {
        // StartCoroutine(spawn());
        GameObject tmp = Instantiate(StageStartPanel);
        GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시
        Destroy(tmp,3f);
        CardsList = GameObject.Find("CardsList");
        cardNum = CardsList.transform.childCount;
        for(int i = 0; i < cardNum; i++)
        {
            cardList.Add(CardsList.transform.GetChild(i).gameObject);
        }
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawnEnded && leftCount == 0){ // 스폰이 전부 종료되었을때 몹이 0마리면 스테이지 종료 판정
            Debug.Log("Stage 이동합니다 : " + round);


            timeManager.GameTime = 60f;
            
            if(round > 0){ //0라운드에는 카드뽑기 진행 X
                Time.timeScale = 0.1f;
                StageEndPanel.SetActive(true);
                for(int i = 0; i < cardList.Count ; i++) {
                    GameObject Card = Instantiate(Resources.Load("Prefabs/Cards/Card"+Random.Range(0,cardIndex)) as GameObject, cardList[i].transform.position, Quaternion.identity);
                    Card.transform.parent = cardList[i].transform.parent;
                    Debug.Log(cardList[i].transform.position);
                }
            }
            StartCoroutine(spawn());
        }
    }
    IEnumerator spawn()
    {
        isSpawnEnded = false;
        for(int i=0;i<enermyCount;i++)
        {
            Instantiate(enemies[round], new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
            leftCount++;
            leftMob.text = leftCount.ToString();
            yield return new WaitForSeconds(0.5f);

        }
        round++;
        isSpawnEnded = true;
    }
}
