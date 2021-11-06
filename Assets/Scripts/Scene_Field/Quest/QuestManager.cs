using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int questId;
    //NPC1 Quiz
    public InputField NPC_1_Quiz_1_Answer;
    public Image right1;
    public Image Wrong1;

    public InputField question2;

    //NPC5 Quiz
    public InputField NPC_5_Quiz_1_Answer, NPC_5_Quiz_2_Answer, NPC_5_Quiz_3_Answer;
    public Image right5;
    public Image Wrong5;
    public Image right6;
    public Image Wrong6;
    public Image right7;
    public Image Wrong7;
    //NPC5 Quiz end

    //NPC Chicken Quiz
    public InputField NPC_Chicken_Answer;
    public Image right2;
    public Image Wrong2;
    public Image HcompletStamp;

    //NPC4 Quiz
    public int count_1 = 0;
    public int count_2 = 0;
    public InputField NPC_4_Quiz_1_Answer, NPC_4_Quiz_2_Answer, NPC_4_Quiz_3_Answer, NPC_4_Quiz_4_Answer;
    public Image Right41;
    public Image Right42;
    public Image Right43;
    public Image Right44;
    public Image Wrong41;
    public Image Wrong42;
    public Image Wrong43;
    public Image Wrong44;
    public Image Wrong45;
    public Image Wrong46;

    //NPC4 Quiz end

    public Button M1;
    public Button M2;
    public Button M3;
    public Button M4;
    public Button M5;

    public Button H1;
    public Text H1Text;
    public Button H2;
    public Text H2Text;
    public Button H3;
    public Text H3Text;
    public Button H4;
    public Text H4Text;
    public Button H5;
    public Text H5Text;
    public Button Submit;

    //NPC Tutle Puzzle Quiz
    public InputField NPC_Puzzle1_Answer, NPC_Puzzle2_Answer;
    public Image rightPuzzle1;
    public Image rightPuzzle2;
    public Image WrongPuzzle1;
    public Image WrongPuzzle2;
    /*//NPC 한성냥이
    public Text gameTimeUI;
    
    public int Cor_Count = 0;
    public GameObject FindER;
    public Button ER1;
    public Button ER2;
    public Button ER3;
    public Button ER4;
    public Button ER5; */
    //NPC FoodZone Quiz
    public InputField NPC_Food_Answer;
    public Image right8;
    public Image Wrong8;
    

    public Image right4;
    public Image Wrong4;
    public Image CompleteStamp;

    Dictionary<int, QuestData> questList;

    
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void Start()
    {
        //파이어베이스 스키마 가져올거임 m1~m5, h1~h5 까지 bool값으로 
        
        
        
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
    
    //NPC1 Quiz
    public void NPC_1_Quiz()
    {
       
            if (NPC_1_Quiz_1_Answer.text == "4268")
            {
                right1.gameObject.SetActive(true);
                //파이어베이스 현재로그인된 계정으로 m1 스키마 true 바꾸는 코드 (수정)
            }
            else
            {
                Wrong1.gameObject.SetActive(true);
                NPC_1_Quiz_1_Answer.text = "";
            }

    }

    //NPC Chicken Quiz
    public void NPC_Chicken_Quiz()
    {
        if(NPC_Chicken_Answer.text == "chicken")
        {
            right2.gameObject.SetActive(true);
            NPC_Chicken_Answer.text = "";
        }
        else
        {
            Wrong2.gameObject.SetActive(true);
            NPC_Chicken_Answer.text = "";
        }
    }
    //NPC FoodZone Quiz
    public void NPC_Food_Quiz()
    {
        if (NPC_Food_Answer.text == "70500")
        {
            right8.gameObject.SetActive(true);
            NPC_Food_Answer.text = "";
        }
        else
        {
            Wrong8.gameObject.SetActive(true);
            NPC_Food_Answer.text = "";
        }
    }
    //NPC4 Quiz
    public void NPC_4_Quiz_1()
    {

        if (NPC_4_Quiz_1_Answer.text == "2")
        {
            Right41.gameObject.SetActive(true);
            NPC_4_Quiz_1_Answer.text = "";
        }
        else if(count_1 == 0)
        {
            Wrong41.gameObject.SetActive(true);
            NPC_4_Quiz_1_Answer.text = "";
            count_1++;
        }
        else if(count_1 == 1)
        {
            Wrong41.gameObject.SetActive(false);
            Wrong44.gameObject.SetActive(true);
            NPC_4_Quiz_1_Answer.text = "";
        }

    }
    public void NPC_4_Quiz_2()
    {

        if (NPC_4_Quiz_2_Answer.text == "4")
        {
            Right42.gameObject.SetActive(true);
            NPC_4_Quiz_2_Answer.text = "";
        }
        else if(count_2 ==0)
        {
            Wrong42.gameObject.SetActive(true);
            NPC_4_Quiz_2_Answer.text = "";
            count_2++;
        }
        else if(count_2 == 1)
        {
            Wrong42.gameObject.SetActive(false);
            Wrong45.gameObject.SetActive(true);
            NPC_4_Quiz_2_Answer.text = "";
        }

    }
    public void NPC_4_Quiz_3()
    {

        if (NPC_4_Quiz_3_Answer.text == "이보영")
        {
            Right43.gameObject.SetActive(true);
            NPC_4_Quiz_3_Answer.text = "";
        }
        else
        {
            Wrong43.gameObject.SetActive(true);
            NPC_4_Quiz_3_Answer.text = "";
        }

    }
    public void NPC_4_Quiz_4()
    {

        if (NPC_4_Quiz_4_Answer.text == "다이빙")
        {
            Right44.gameObject.SetActive(true);
            NPC_4_Quiz_4_Answer.text = "";
        }
        else
        {
            Wrong46.gameObject.SetActive(true);
            NPC_4_Quiz_4_Answer.text = "";
        }

    }
    //NPC4 Quiz end

    //NPC5 Quiz
    public void NPC_5_Quiz_1()
    {
        if(NPC_5_Quiz_1_Answer.text == "25")
        {
            right5.gameObject.SetActive(true);
            NPC_5_Quiz_1_Answer.text = "";
        }
        else
        {
            Wrong5.gameObject.SetActive(true);
            NPC_5_Quiz_1_Answer.text = "";
        }
    }
    public void NPC_5_Quiz_2()
    {
        if (NPC_5_Quiz_2_Answer.text == "낙산멍이")
        {
            right6.gameObject.SetActive(true);
            NPC_5_Quiz_2_Answer.text = "";
        }
        else
        {
            Wrong6.gameObject.SetActive(true);
            NPC_5_Quiz_2_Answer.text = "";
        }
    }
    public void NPC_5_Quiz_3()
    {
        if (NPC_5_Quiz_3_Answer.text == "코딩하는쿼카")
        {
            right7.gameObject.SetActive(true);
            NPC_5_Quiz_3_Answer.text = "";
        }
        else
        {
            Wrong7.gameObject.SetActive(true);
            NPC_5_Quiz_3_Answer.text = "";
        }
    }
    //NPC5 Quiz end

    //NPC Tutle Puzzle Quiz
    public void NPC_Puzzle_Quiz_1()
    {
        if(NPC_Puzzle1_Answer.text == "대동제")
        {
            rightPuzzle1.gameObject.SetActive(true);
            NPC_Puzzle1_Answer.text = "";
        }
        else
        {
            WrongPuzzle1.gameObject.SetActive(true);
            NPC_Puzzle1_Answer.text = "";
        }
    }

    public void NPC_Puzzle_Quiz_2()
    {
        if (NPC_Puzzle2_Answer.text == "낙산공원")
        {
            rightPuzzle2.gameObject.SetActive(true);
            NPC_Puzzle2_Answer.text = "";
        }
        else
        {
            WrongPuzzle2.gameObject.SetActive(true);
            NPC_Puzzle2_Answer.text = "";
        }
    }
    //NPC Tutle Puzzle end
    public void Quiz3Button()
    {
        if (question2.text == "박성재")
        {
            right4.gameObject.SetActive(true);
        }
        else
        {
            Wrong4.gameObject.SetActive(true);
        }
    }

    public void Mission1QuestOpen()
	{
        M1.interactable = true;

	}

    public void Mission2QuestOpen()
	{
        
        M2.interactable = true;
	}

    public void Mission3QuestOpen()
    {
       
        M3.interactable = true;
    }

    public void Mission4QuestOpen()
    {
        
        M4.interactable = true;
    }

    public void Mission5QuestOpen()
    {
        
        M5.interactable = true;
    }
    public void Hidden1QuestOpen()
    {
        H1.interactable = true;
        H1Text.text = "꼬꼬&꾸꾸 밥 주기";
    }
    

    public void Hidden2QuestOpen()
    {
        H2.interactable = true;
        H2Text.text = "그라지에 메뉴 맞추기";
    }
   
    public void Hidden3QuestOpen()
    {
        H3.interactable = true;
        H3Text.text = "낱말퍼즐 풀기";
    }
    public void Hidden4QuestOpen()
    {
        H4.interactable = true;
        H4Text.text = "선물상자 열기";
    }
    public void Hidden5QuestOpen()
    {
        H5.interactable = true;
        H5Text.text = "매출액 계산하기";
    }

    public void Complete()
	{
        CompleteStamp.gameObject.SetActive(true);
	}

  
    public void CompleteH2()
    {
        HcompletStamp.gameObject.SetActive(true);
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
