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

    public GameObject ClearPanel;
    int[] oneObjStage = {10,20,30,36,37,38};
    int[] fiftyObjStage = {21,22};
    int[] eightObjStage = {31,32,33};
    int[] threeObjStage = {34,35};
    public GameObject BossHP;

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

    public int stageIdx = 0;
    // Update is called once per frame
    void Update()
    {
        if(round >= 21 && round <= 30)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject player in players) // 
            {
                player.GetComponent<SpriteRenderer>().color =  Color.grey; 
            }
        }

        if(isSpawnEnded && leftCount == 0){ // 스폰이 전부 종료되었을때 몹이 0마리면 스테이지 종료 판정


            timeManager.GameTime = 60f;
            

            if(round > 0){ //0라운드에는 카드뽑기 진행 X
                if((round+1) == 11 || (round+1) == 21){ // 맵 변경 스테이지
                    Instantiate(Resources.Load("Prefabs/FadeOut") as GameObject); // 삭제는 애니메이션 끝나면 자동으로 삭제된다.
                } 
                

                /* 여기는 스테이지마다 나오는 몬스터 수 관리해주기*/


                if ((round + 1) == 10 || (round +1) == 20 || (round + 1 ) == 30 || round+1 == 36 || round + 1 == 37 || round + 1 == 38){ // 5,10,15,.. 스테이지
                    // 보스 portrait등록해주기
                    enermyCount = 1;
                }else if(round+1 == 21 || round +1 == 22){ // 50마리 스테이지
                    enermyCount = 50;
                }else if(round+1 == 31 || round +1 == 32 || round +1 == 33){ // 8마리 스테이지
                    enermyCount = 8;
                }else if(round+1 == 34 || round +1 == 35){ // 3마리 스테이지
                    enermyCount = 3;
                }else if(round+1 ==39)
                {
                    ClearPanel.SetActive(true);
                }
                else{ // 10의 배수가 아닐때 (즉 1,2,3,4,6,7,8,9 스테이지)
                    enermyCount = 30;
                }



                //////////////////////////////////////////////////////////////////

                if(round % 3 == 0){
                    Time.timeScale = 0.1f;
                    StageEndPanel.SetActive(true);
                    for(int i = 0; i < cardList.Count ; i++) {
                        GameObject Card = Instantiate(Resources.Load("Prefabs/Cards/Card"+Random.Range(0,cardIndex + 1)) as GameObject, cardList[i].transform.position, Quaternion.identity);
                        Card.transform.localScale = new Vector2(0.3f,0.3f);
                        Card.transform.parent = cardList[i].transform.parent;
                    }
                }else{
                    // if(GameObject.Find("StageEnd") != null){
                    //     GameObject.Find("StageEnd").SetActive(false);
                    // }..


                    
   
                }
        }
            StartCoroutine(spawn());
                 if(round+1 == 31)
        {
            // GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "사이클롭스";
            // Destroy(tmp,3f);
        }else if(round+1 == 32)
        {
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "네크로멘서";
            Destroy(tmp,3f);
        }
        else if(round + 1 == 33){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "타락한 기사";
            Destroy(tmp,3f);
        }else if(round + 1 == 34){
            // GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "좀비 킹";
            // Destroy(tmp,3f);
        }else if(round + 1 == 35){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "오염된 나무";
            Destroy(tmp,3f);
        }else if(round + 1 == 36){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "올드 가디언";
            Destroy(tmp,3f);
        }else if(round + 1 == 37){
            // GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "데몬";
            BossHP.GetComponent<Slider>().maxValue = 120000;
            BossHP.GetComponent<Slider>().value = 120000;
            BossHP.SetActive(true);
            // Destroy(tmp,3f);
        }else if(round + 1 == 38){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "얼음";
            BossHP.GetComponent<Slider>().maxValue = 140000;
            BossHP.GetComponent<Slider>().value = 140000;
            BossHP.SetActive(true);
            Destroy(tmp,3f);
        }

        else if((round + 1) % 10 == 0){

            if(round + 1 == 10){
                BossHP.GetComponent<Slider>().maxValue = 1000;
                BossHP.GetComponent<Slider>().value = 1000;
                BossHP.SetActive(true);
            }
            else if(round + 1 == 20){
                GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
                GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "어둠의 숲";
                BossHP.GetComponent<Slider>().maxValue = 7500;
                BossHP.GetComponent<Slider>().value = 7500;
                BossHP.SetActive(true);
                Destroy(tmp,3f);
            }
            else if(round + 1 == 30){
            GameObject tmp = Instantiate(Resources.Load("Prefabs/BOSSStageStart") as GameObject);
            GameObject.Find("Stage_Text_Map").GetComponent<Text>().text = "사원";
            BossHP.GetComponent<Slider>().maxValue = 10000;
            BossHP.GetComponent<Slider>().value = 10000;
            BossHP.SetActive(true);
            Destroy(tmp,3f);
            }

            
        }else{
                if((round) % 3 != 0 ){ // 일반몹 Stage
                    GameObject tmp = Instantiate(Resources.Load("Prefabs/StartStagePanel") as GameObject);
                    GameObject.Find("StageIndicateText").GetComponent<Text>().text = "Stage " + (round + 1).ToString(); // 스테이지 시작 패널에 스테이지 표시
                    Destroy(tmp,3f);
                }
            }
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
