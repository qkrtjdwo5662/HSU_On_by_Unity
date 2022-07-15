using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Dialog dialog; //dialog.cs
    public QuestManager qm;// QusetManager.cs

    public int size = 0; // dialog talkdata[gameObject] length
    public int size_Y = 0; //  dialog talkdata[gameObject + _Yes] length
    public int size_N = 0; // dialog talkdata[gameObject + _No] length

    public GameObject Talk0; //Button object
    public Button StartButton; //button from Talk0

    public GameObject Talk1; // Text, Button Object
    public Button NextButton; // button from Talk1 (main dialog, next)
    public Text text; // text from Talk1
    public int ButtonCount = 0; // Nextbutton click count
    public Button XButton; // button from Talk1(exit)
    public Button NextButton2; // button from Talk1 (yes dialog, next)
    public Button NextButton3; // button from Talk1 (no dialog, next)

    public GameObject Talk2;
    public Button YesButton; // button from Talk2(yes)
    public Button NoButton; // button from Talk2(no)
    public InputField InputField;
    public Button SubmitButton;

    
    
    public enum NPC
	{
        OT_NPC0, OT_NPC1, OT_NPC2, OT_NPC3, OT_NPC4, OT_NPC5, // OT_NPC
        H_NPC1, H_NPC2, H_NPC3, H_NPC4, H_NPC5 // Hidden_NPC
    }
    public NPC npc;
    
    void Start()
    {
        size = dialog.getSize(gameObject.name);
        size_Y = dialog.getSize(gameObject.name + "_Yes");
        size_N = dialog.getSize(gameObject.name + "_No");

        StartButton.onClick.AddListener(() => //lamda function
        {

            Talk0.SetActive(false);
            Talk1.SetActive(true);
            Debug.Log(this.npc);
            StartCoroutine(TypingEffect(gameObject.name));
            //카메라 온

        });

        NextButton.onClick.AddListener(() => {
            if (ButtonCount < size)
            {
                StartCoroutine(TypingEffect(gameObject.name));
                ButtonCount++;
                if (ButtonCount == size - 1)
                {
                    NextButton.gameObject.SetActive(false);
                    NextButton2.gameObject.SetActive(false);
                    if (npc == NPC.OT_NPC0) 
                    {
                        Talk2.SetActive(true); // Yes/No Button ON
                        YesButton.gameObject.SetActive(true);
                        NoButton.gameObject.SetActive(true);
                    }
                    if (npc == NPC.OT_NPC1)
                    {
                        InputField.gameObject.SetActive(true);
                        SubmitButton.gameObject.SetActive(true);
                    }
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
            StopAllCoroutines(); // coroutine all stop
            //카메라 리턴
        });

        YesButton.onClick.AddListener(() =>
        {
            ButtonCount = 0;
            Talk2.SetActive(false);
            NextButton2.gameObject.SetActive(true);
            Debug.Log(YesButton.name);
            StartCoroutine(TypingEffect(gameObject.name + "_Yes"));
            if (npc==NPC.OT_NPC0) 
            {
                qm.QuestOpen();
               return;
            }

        });
        NextButton2.onClick.AddListener(() =>
        {
            if (ButtonCount < size_Y-1)
            {
                StartCoroutine(TypingEffect(gameObject.name + "_Yes"));
                ButtonCount++;

            }
            else
            {
                ButtonCount = 0;
                Talk1.SetActive(false);
                NextButton.gameObject.SetActive(true); // NextButton 꺼진거 다시키기
                NextButton2.gameObject.SetActive(false);
                NextButton3.gameObject.SetActive(false);
                Talk2.SetActive(false);
                //카메라 리턴
            }
        });

        NoButton.onClick.AddListener(() =>
        {
            ButtonCount = 0;
            Talk2.SetActive(false);
            NextButton3.gameObject.SetActive(true);
            Debug.Log(NoButton.name);
            
            StartCoroutine(TypingEffect(gameObject.name + "_No"));


        });

        NextButton3.onClick.AddListener(() =>
        {
            if (ButtonCount < size_N-1)
            {
                StartCoroutine(TypingEffect(gameObject.name + "_No"));
                ButtonCount++;

            }
            else
            {
                ButtonCount = 0;
                Talk1.SetActive(false);
                NextButton.gameObject.SetActive(true); // NextButton 꺼진거 다시키기
                NextButton2.gameObject.SetActive(false);
                NextButton3.gameObject.SetActive(false);
                Talk2.SetActive(false);
                //카메라 리턴
            }
        });

        SubmitButton.onClick.AddListener(() =>
        {
            ButtonCount = 0;
            Talk2.SetActive(false);
            if(InputField.text == "창의열람실")
			{
                NextButton2.gameObject.SetActive(true);
                //correct
                StartCoroutine(gameObject.name + "_Yes");
			}
            else
			{
                NextButton.gameObject.SetActive(true);
                //wrong
                InputField.text = "";
                StartCoroutine(gameObject.name + "_No");
            }
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
    IEnumerator TypingEffect(string key)
    {
        for (int i = 0; i < dialog.GetTalk(key, ButtonCount).Length; i++)
        {
            text.text = dialog.GetTalk(key, ButtonCount).Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
