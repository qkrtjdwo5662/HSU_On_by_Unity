using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public InputField question1;
    public Button H1;
    public Button H2;
    public Button H3;
    public Button H4;
    public Button H5;
    public Button Submit;
    public Image right;
    public Image Wrong;
    public Image Stamp1;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void Start()
    {
        H1.interactable = false;
        H2.interactable = false;
        H3.interactable = false;
        H4.interactable = false;
        H5.interactable = false;
    }
    public void Button()
    {

            if (question1.text == "2")
            {
                right.gameObject.SetActive(true);
            }
            else
            {
                Wrong.gameObject.SetActive(true);
            }
      
    }

    public void Complete()
	{
        Stamp1.gameObject.SetActive(true);
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
