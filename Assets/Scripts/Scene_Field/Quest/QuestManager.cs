using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public InputField question1, question2;
   

    public Button M1;
    public Button M2;
    public Button M3;
    public Button M4;
    public Button M5;

    public Button H1;
    public Button H2;
    public Button H3;
    public Button H4;
    public Button H5;
    public Button Submit;
    public Image right;
    public Image Wrong;
    public Image CompleteStamp;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void Start()
    {
        M1.interactable = false;
        M2.interactable = false;
        M3.interactable = false;
        M4.interactable = false;
        M5.interactable = false;

        H1.interactable = false;
        H2.interactable = false;
        H3.interactable = false;
        H4.interactable = false;
        H5.interactable = false;
    }
    public void Button()
    {

            if (question1.text == "2"|| question2.text =="박성재")
            {
                right.gameObject.SetActive(true);
            }
            else
            {
                Wrong.gameObject.SetActive(true);
            }
       


    }
    

    public void Mission1QuestOpen()
	{
        M1.interactable = true;

	}

    public void Mission2QuestOpen()
	{
        M1.interactable = true;
        M2.interactable = true;
	}

    public void Mission3QuestOpen()
    {
        M1.interactable = true;
        M2.interactable = true;
        M3.interactable = true;
    }

    public void Mission4QuestOpen()
    {
        M1.interactable = true;
        M2.interactable = true;
        M3.interactable = true;
        M4.interactable = true;
    }


    public void Complete()
	{
        CompleteStamp.gameObject.SetActive(true);
	}

  

   

    void GenerateData()
	{
        //questList.Add(10, new QuestData("첫 번째 퀘스트", new int[1] { }));
	}
    
    public int GetQuestTalkIndex(int id)
	{
        return questId;
	}
    // Start is called before the first frame update
}
