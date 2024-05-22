using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuizStart : MonoBehaviour
{
    public GameObject quizbackground;
    public GameObject response;
    public GameObject timerpannel;
    public int stage_count = 0;
    public bool quiz_stage = true;
    public TextMeshProUGUI quiz_expression;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            if (stage_count == 1)
            {
                quiz_expression.text = "AIDS�� ����� ������ ������ ������ȯ�̴�.";
            }
            else if(stage_count == 2)
            {
                quiz_expression.text = "���� ��ȯ�� ���� ������ �������� ���� �߻��Ѵ�.";
            }
            response.SetActive(false);
            quizbackground.SetActive(true);
            timerpannel.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            response.SetActive(true);
            quizbackground.SetActive(false);
            timerpannel.SetActive(false);
            if (quiz_stage)
            {
                stage_count++;
                quiz_stage=false;
            }
        }
        if(Input.GetKeyDown(KeyCode.D)){
            response.SetActive(false);
            quizbackground.SetActive(false);
            timerpannel.SetActive(true);
            quiz_stage = true;
        }
    }
}
