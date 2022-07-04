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
            //GetTalk(Yes, ButtonCount)가져오기
            //Problem 1. GetTalk의 값을 여기서 지정해주는 것이 가능한가?
            //Problem 2. NPC마다의 Yes버튼 눌렀을때 대화를 통일하는 것이 맞을까?
            //Problem 3. NPC마다의 Yes버튼 눌렀을때 각 다른 이벤트 처리는 어떻게 할 것인가? (NPC0에서 Yes버튼 클릭시 Quest창 true)
        });
        NoButton.onClick.AddListener(() =>
        {
            //GetTalk(No, ButtonCount)가져오기
            //Problem 1. GetTalk의 값을 여기서 지정해주는 것이 가능한가?
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

}
