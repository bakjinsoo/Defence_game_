using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial_Manager : MonoBehaviour
{
    public GameObject range;
    public int tutorial_key;
    public GameObject text_panel;
    public GameObject archer_ui_selected;
    public GameObject gunner_ui_selected;
    public GameObject magician_ui_selected;
    GameObject characterAura;
    public GameObject spawn_manager;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("hamster_magician").GetComponentInChildren<magician_attack>().magician_grade=6;
        GameObject.Find("hamster_archer_1").GetComponentInChildren<archer_attack>().archer_grade=6;
        GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=6;
        characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x,GameObject.Find("hamster_gunner_1").transform.position.y);
    }
    GameObject ui_class_one;
    GameObject ui_class_two;
    GameObject ui_class_three;
    GameObject ui_class_four;
    GameObject ui_class_five;
    GameObject ui_class_six;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            tutorial_key++;
            if(tutorial_key==1)
            {
                text.text="안녕하세요, 저는 햄찌에요! 랜덤디펜스 전투에서 유닛들로 여러분만의 조합을 완성해 전투에서 살아남으세요. 끝까지 살아남아 승리하세요!";
            }
            else if(tutorial_key==2){
                text.text="유닛의 종류는 총 3가지가 있습니다!";
            }
            else if(tutorial_key==3){
                archer_ui_selected.SetActive(true);
                text.text="이 유닛은 궁수유닛이에요. 궁수유닛은 적에게 공격을 할때 단일타겟으로 공격을 해요";
            }
            else if(tutorial_key==4){
                text.text="적을 한번에 많이 잡진 못하지만, 적에게 입히는 데미지는 뒤에 설명해줄 거너,마법사 유닛보다 데미지가 훨씬 강한녀석이에요! 이 유닛을 잘 활용하여 끝까지 살아남으세요!";
            }
            else if(tutorial_key==5){
                archer_ui_selected.SetActive(false);
                gunner_ui_selected.SetActive(true);
                text.text="이 유닛은 거너유닛이에요. 거너유닛은 적에게 공격을 할때 다중타겟으로 공격을 해요";
            }
            else if(tutorial_key==6){
                text.text="공격할때마다 적의 타겟수는 마법사유닛보다는 적지만 데미지는 마법사 유닛보다 강합니다! 이 유닛을 잘 활용하여 끝까지 살아남으세요! ";
            }
            else if(tutorial_key==7){
                gunner_ui_selected.SetActive(false);
                magician_ui_selected.SetActive(true);
                text.text="이유닛을 마법사 유닛이에요. 마법사유닛은 적에게 공격을 할때 적을 가장많이 타겟팅할수 있는 유닛이에요";
            }
            else if(tutorial_key==8){
                text.text="적을 가장많이 타겟팅할수있는 장점은 있지만, 데미지는 가장 약하다는 단점도 있답니다! 이 유닛을 잘 활용하여 끝까지 살아남으세요!";
            }
            else if(tutorial_key==9){
                magician_ui_selected.SetActive(false);
                GameObject.Find("box ui_0").SetActive(false);
                GameObject.Find("box ui_0 (1)").SetActive(false);
                GameObject.Find("box ui_0 (2)").SetActive(false);
                GameObject.Find("hamster_magician").SetActive(false);
                GameObject.Find("hamster_archer_1").SetActive(false);
                spawn_manager.SetActive(true);
                text.text="유닛의 등급은 총 6가지가 있습니다.";
            }
            else if(tutorial_key==10){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=6;
                ui_class_six=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_3"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                ui_class_six.transform.position=new Vector2(5.5f,4);
                range.transform.localScale=new Vector3(5.33f,5.33f,1f);
                range.SetActive(true);
                text.text="클래스는 총 6가지로 분류되며, 레어, 에픽, 유니크, 레전더리, 히어로, 갓이 있습니다. 해당 유닛은 가장 낮은 클래스인 레어 클래스 입니다!";
            }
            else if(tutorial_key==11){
                text.text="해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다. 공격속도및 데미지는 클래스가 높아짐에 따라 증가합니다,";
            }
            else if(tutorial_key==12){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=5;
                Destroy(ui_class_six);
                range.transform.localScale=new Vector3(6.65f,6.65f,1f);
                ui_class_five=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_1"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                ui_class_five.transform.position=new Vector2(5.5f,5);
                characterAura = Instantiate(Resources.Load("Prefabs/Aura/PurpleAura"), transform.position, Quaternion.identity) as GameObject;
                characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x-0.5f,GameObject.Find("hamster_gunner_1").transform.position.y);
                text.text="에픽클래스 입니다. 해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다.";
            }
            else if(tutorial_key==13){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=4;
                Destroy(ui_class_five);
                Destroy(characterAura);
                characterAura = Instantiate(Resources.Load("Prefabs/Aura/GreenAura"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x-0.5f,GameObject.Find("hamster_gunner_1").transform.position.y);
                range.transform.localScale=new Vector3(8.85f,8.85f,1f);
                ui_class_four=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_2"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                ui_class_four.transform.position=new Vector2(5.5f,5);
                text.text="유니크 클래스입니다. 해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다.";
            }
            else if(tutorial_key==14){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=3;
                Destroy(ui_class_four);
                Destroy(characterAura);
                characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlueAura"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x-0.5f,GameObject.Find("hamster_gunner_1").transform.position.y);
                range.transform.localScale=new Vector3(11.05f,11.05f,1f);
                ui_class_three=Instantiate(Resources.Load("Prefabs/Class/ui_class_1_0"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                ui_class_three.transform.position=new Vector2(5.5f,5);
                text.text="레전더리 클래스입니다.해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다.";
            }
            else if(tutorial_key==15){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=2;
                Destroy(ui_class_three);
                Destroy(characterAura);
                characterAura = Instantiate(Resources.Load("Prefabs/Aura/RedAura"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x-0.5f,GameObject.Find("hamster_gunner_1").transform.position.y);
                range.transform.localScale=new Vector3(14.2f,14.2f,1f);
                ui_class_two=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_1"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                ui_class_two.transform.position=new Vector2(5.5f,5);
                text.text="히어로 클래스입니다. 해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다.";
            }
            else if(tutorial_key==16){
                GameObject.Find("hamster_gunner_1").GetComponentInChildren<gunner_attack>().gunner_grade=1;
                Destroy(ui_class_two);
                Destroy(characterAura);
                characterAura = Instantiate(Resources.Load("Prefabs/Aura/BlackAura"), GameObject.Find("hamster_gunner_1").transform.position, Quaternion.identity) as GameObject;
                characterAura.transform.position=new Vector2(GameObject.Find("hamster_gunner_1").transform.position.x-0.5f,GameObject.Find("hamster_gunner_1").transform.position.y);
                range.transform.localScale=new Vector3(22f,22f,1f);
                ui_class_one=Instantiate(Resources.Load("Prefabs/Class/ui_class_2_0"), transform.position, Quaternion.identity) as GameObject;
                ui_class_one.transform.position=new Vector2(5.5f,5);
                text.text="갓 클래스입니다. 해당 쿨래스의 유닛들은 이 범위 안에 들어오는 적을 공격할수 있습니다. ";
            }
            else if(tutorial_key==17){
                text.text="가장 높은 클래스이며, 어떤 위치에 있어도 전범위 공격이 가능합니다! 갓클래스의 유닛들은 당신의 생존에 큰 도움이 될것입니다!";
            }
        }
    }
}
