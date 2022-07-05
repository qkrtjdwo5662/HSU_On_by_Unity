using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Dialog dialog; //dialog script
    public int size = 0; // dialog talkdata length

    public GameObject Talk0; //Button object
    public Button StartButton; //button from Talk0

    public GameObject Talk1; // Text, Button Object
    public Button NextButton; // button from Talk1(next)
    public Text text; // text from Talk1
    public int ButtonCount = 0; // Nextbutton click count
    public Button XButton; // button from Talk1(exit)
    public Button NextButton2; // button from nextbutton

    public GameObject Talk2;
    public Button YesButton; // button from Talk2(yes)
    public Button NoButton; // button from Talk2(no)


    // Start is called before the first frame update
    void Start()
    {
        size = dialog.getSize(gameObject.name);
        StartButton.onClick.AddListener(() => //lamda function
        {

            Talk0.SetActive(false);
            Talk1.SetActive(true);
            Debug.Log(gameObject.name);
            StartCoroutine(TypingEffect());
            //카메라 온

        });
        NextButton.onClick.AddListener(() => {
            if (ButtonCount < size)
            {
                StartCoroutine(TypingEffect());
                ButtonCount++;
                if (ButtonCount == size - 1)
                {
                    NextButton.gameObject.SetActive(false); // Talk2와 NextButton이 겹쳐 보이는 문제
                    NextButton2.gameObject.SetActive(false);
                    Talk2.SetActive(true);
                }
            }
            else
            {
                ButtonCount = 0;
                Talk1.SetActive(false);
                NextButton.gameObject.SetActive(true); // NextButton 꺼진거 다시키기
                Talk2.SetActive(false);
                //카메라 리턴
            }
        });
        XButton.onClick.AddListener(() =>
        {
            ButtonCount = 0;
            Talk0.SetActive(false);
            Talk1.SetActive(false);
            NextButton.gameObject.SetActive(true); // X버튼 눌렀을때 NextButton 다시켜기
            Talk2.SetActive(false);
            //카메라 리턴
        });
        YesButton.onClick.AddListener(() =>
        {
            ButtonCount = 0;
            Talk2.SetActive(false);
            NextButton2.gameObject.SetActive(true);
            Debug.Log(YesButton.name);
            StopCoroutine(TypingEffect());
            StopCoroutine(TypingEffect2());

            StartCoroutine(TypingEffect1());
            NextButton2.onClick.AddListener(() =>
            {
                if (ButtonCount < size)
                {
                    StartCoroutine(TypingEffect1());
                    ButtonCount++;
                    
                }
                else
                {
                    ButtonCount = 0;
                    Talk1.SetActive(false);
                    NextButton.gameObject.SetActive(true); // NextButton 꺼진거 다시키기
                    NextButton2.gameObject.SetActive(false);
                    Talk2.SetActive(false);
                    //카메라 리턴
                }
            });
            //GetTalk(Yes, ButtonCount)가져오기
            //Problem 1. GetTalk의 값을 여기서 지정해주는 것이 가능한가?
            //Solution 1. TypingEffect1()함수 추가 (YesButton 클릭시에 Yes_Button의 value값 가져옴)
            //Solution 2. YesButton.onClick.AddListener 추가 : ButtonCount초기화, Yes/No Button 끄기, TypingEffect1() 코루틴 시작, nextbutton 복구
            //Solution 3. NextButton2를 만들어줌


            //Problem 2. NPC마다의 Yes버튼 눌렀을때 대화를 통일하는 것이 맞을까?
            //Problem 3. NPC마다의 Yes버튼 눌렀을때 각 다른 이벤트 처리는 어떻게 할 것인가? (NPC0에서 Yes버튼 클릭시 Quest창 true)
        });
        NoButton.onClick.AddListener(() =>
        {
            //GetTalk(No, ButtonCount)가져오기
            //Problem 1. GetTalk의 값을 여기서 지정해주는 것이 가능한가?
            //Solution TypingEffect1()함수 추가
            StartCoroutine(TypingEffect2());
        });

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {
            Talk0.SetActive(true);

        }
    }
    public void OnTriggerExit(Collider other)
    {
        ButtonCount = 0;
        Talk0.SetActive(false);
        Talk1.SetActive(false);
        //카메라 리턴
    }
    IEnumerator TypingEffect()
    {
        for (int i = 0; i < dialog.GetTalk(gameObject.name, ButtonCount).Length; i++)
        {
            text.text = dialog.GetTalk(gameObject.name, ButtonCount).Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator TypingEffect1()
    {
        for (int i = 0; i < dialog.GetTalk(YesButton.name, ButtonCount).Length; i++)
        {
            text.text = dialog.GetTalk(YesButton.name, ButtonCount).Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator TypingEffect2()
    {
        for (int i = 0; i < dialog.GetTalk(NoButton.name, ButtonCount).Length; i++)
        {
            text.text = dialog.GetTalk(NoButton.name, ButtonCount).Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
