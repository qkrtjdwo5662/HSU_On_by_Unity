using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Extensions;

public class QuestManager : MonoBehaviour
{
    //Join.cs
    public Join join;
    //돈
    public string money;
    //OT_NPC1 Quiz
    public InputField OT_NPC1_Quiz_Answer;
    public Image OT_NPC1_Quiz_right, OT_NPC1_Quiz_Wrong;
    //OT_NPC2 Quiz
    public InputField OT_NPC2_Quiz_Answer;
    public Image OT_NPC2_Quiz_right, OT_NPC2_Quiz_Wrong;
    //OT_NPC3 Quiz
    public InputField OT_NPC3_Quiz_Answer;
    public Image OT_NPC3_Quiz_right, OT_NPC3_Quiz_Wrong;
    public InputField OT_NPC3_Quiz2_Answer;
    public Image OT_NPC3_Quiz2_right, OT_NPC3_Quiz2_Wrong;
    //OT_NPC5 Quiz
    public InputField OT_NPC5_Quiz_Answer;
    public Image OT_NPC5_Quiz_right, OT_NPC5_Quiz_Wrong;
    public InputField OT_NPC5_Quiz2_Answer;
    public Image OT_NPC5_Quiz2_right, OT_NPC5_Quiz2_Wrong;
    //NPC1 Quiz
    public InputField NPC1_Quiz_Answer;
    public Image NPC1_Quiz_right, NPC1_Quiz_Wrong;
    //NPC1 Quiz
    //Hidden NPC
    public GameObject Hidden1;
    public GameObject Hidden2;
    public GameObject Hidden3;
    public GameObject Hidden4;
    public GameObject Hidden5;
    //NPC4 Quiz
    public int count_1 = 0;
    public int count_2 = 0;
    public InputField NPC4_Quiz1_Answer, NPC4_Quiz2_Answer, NPC4_Quiz3_Answer, NPC4_Quiz4_Answer;
    public Image NPC4_Quiz1_right, NPC4_Quiz1_wrong;
    public Image NPC4_Quiz2_right, NPC4_Quiz2_wrong;
    public Image NPC4_Quiz3_right, NPC4_Quiz3_wrong;
    public Image NPC4_Quiz4_right, NPC4_Quiz4_wrong;
    public Image NPC4_Quiz1_wrong2, NPC4_Quiz2_wrong2;
    //NPC4 Quiz end

    //NPC5 Quiz
    public InputField NPC5_Quiz1_Answer, NPC5_Quiz2_Answer;
    public Image NPC5_Quiz1_right, NPC5_Quiz1_wrong;
    public Image NPC5_Quiz2_right, NPC5_Quiz2_wrong;
    //NPC5 Quiz end

    //NPC Chicken Quiz
    public InputField NPC_Chicken_Quiz_Answer;
    public Image NPC_Chicken_Quiz_right, NPC_Chicken_Quiz_wrong;
    //NPC chicken Quiz end

    //NPC Tutle Puzzle Quiz
    public InputField NPC_WordPuzzle_Quiz1_Answer, NPC_WordPuzzle_Quiz2_Answer;
    public Image NPC_WordPuzzle_Quiz1_right, NPC_WordPuzzle_Quiz1_wrong;
    public Image NPC_WordPuzzle_Quiz2_right, NPC_WordPuzzle_Quiz2_wrong;
    //end

    //NPC FoodZone Quiz
    public InputField NPC_FoodZone_Quiz_Answer;
    public Image NPC_FoodZone_Quiz_right, NPC_FoodZone_Quiz_wrong;
    //end

    public Button QuestButton;

    public Image Sangjji;
    public float fadeTime = 1.5f;
    public AnimationCurve fadeCurve;


    //Quest List Button
    public Button M1;
    public Button M2;
    public Button M3;
    public Button M4;
    public Button M5;

    public Button OT1;
    public Button OT2;
    public Button OT3;
    public Button OT4;
    public Button OT5;

    public Button D1;
    public Button D2;
    public Button D3;
    public Button D4;
    public Button D5;

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



    public Image H1_talk1, H1_ClearAfterTalk;
    public Image H2_talk1, H2_ClearAfterTalk;
    public Image H3_talk1, H3_ClearAfterTalk;
    public Image H4_talk1, H4_ClearAfterTalk;
    public Image H5_talk1, H5_ClearAfterTalk;

    //info
    public Text IdentityID_text;
    public Text StuID_text;

    //NPC Object
    public GameObject NPC0;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject NPC5;

    //NPC_OT Object
    public GameObject OTNPC0;
    public GameObject OTNPC1;
    public GameObject OTNPC2;
    public GameObject OTNPC3;
    public GameObject OTNPC4;
    public GameObject OTNPC5;

    //Stamp Imgae
    public Image M1Stamp;
    public Image M2Stamp;
    public Image M3Stamp;
    public Image M4Stamp;
    public Image M5Stamp;
    public Image H1Stamp;
    public Image H2Stamp;
    public Image H3Stamp;
    public Image H4Stamp;
    public Image H5Stamp;

    public Image OT1Stamp;
    public Image OT2Stamp;
    public Image OT3Stamp;
    public Image OT4Stamp;
    public Image OT5Stamp;

    //Complete Image
    public Image M1Complete;
    public Image M2Complete;
    public Image M3Complete;
    public Image M4Complete;
    public Image M5Complete;
    public Image H1Complete;
    public Image H2Complete;
    public Image H3Complete;
    public Image H4Complete;
    public Image H5Complete;


    public Image OT1Complete;
    public Image OT2Complete;
    public Image OT3Complete;
    public Image OT4Complete;
    public Image OT5Complete;

    public Image D1Complete;
    public Image D2Complete;
    public Image D3Complete;
    public Image D4Complete;
    public Image D5Complete;
    //Quest
    public Image QuestList;

    public Image M_list;
    public Image H_list;
    public Image O_list;
    public Image OT_list;
    public Image D_list;
    public Image Main;

    public Image Basic_detail;
    public GameObject M_detail;
    public GameObject H_detail;
    public GameObject O_detail;
    public GameObject OT_detail;
    public GameObject Main_detail;

    Dictionary<int, QuestData> questList;
    FirebaseAuth auth;

    public string myName = "0";
    public string myStdId;





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

        /*OT1.interactable = false;
          OT2.interactable = false;
        OT3.interactable = false;
        OT4.interactable = false;
        OT5.interactable = false;

        D1.interactable = false;
        D2.interactable = false;
        D3.interactable = false;
        D4.interactable = false;
        D5.interactable = false; */

        join = GameObject.Find("Join").GetComponent<Join>();

        IdentityID_text.text = join.getUserID().Substring(10);
        StuID_text.text = "학번 : " + join.getStdId() + "\n" + "이름 : " + join.getName();


        if (join.ot0cleared.Equals("True"))
        {
            QuestOpen();
        }

        if (join.ot1cleared.Equals("True"))
        {
            OT1QuestCleared();
        }

        if (join.ot2cleared.Equals("True"))
        {
            OT2QuestCleared();
        }

        if (join.ot3cleared.Equals("True"))
        {
            OT3QuestCleared();
        }

        if (join.ot4cleared.Equals("True"))
        {
            OT4QuestCleared();
        }

        if (join.ot5cleared.Equals("True"))
        {
            OT5QuestCleared();
        }


        if (join.d1cleared.Equals("True"))
        {
            Mission1QuestCleared();
        }

        if (join.d2cleared.Equals("True"))
        {
            Mission2QuestCleared();
        }

        if (join.d3cleared.Equals("True"))
        {
            Mission3QuestCleared();
        }

        if (join.d4cleared.Equals("True"))
        {
            Mission4QuestCleared();
        }

        if (join.d5cleared.Equals("True"))
        {
            Mission5QuestCleared();
        }


        if (join.h1cleared.Equals("True"))
        {
            Hidden1QuestCleared();
        }

        if (join.h2cleared.Equals("True"))
        {
            Hidden2QuestCleared();
        }

        if (join.h3cleared.Equals("True"))
        {
            Hidden3QuestCleared();
        }

        if (join.h4cleared.Equals("True"))
        {
            Hidden4QuestCleared();
        }

        if (join.h5cleared.Equals("True"))
        {
            Hidden5QuestCleared();
        }
    }



    IEnumerator CoFade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color color = Sangjji.color;
        while (percent < 1f)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));

            Sangjji.color = color;
            yield return null;
        }

    }

    public void FadeIn()
    {
        StartCoroutine(CoFade(0, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(CoFade(1, 0));
    }

    public void OT_NPC1_Quiz()
    {
        if (OT_NPC1_Quiz_Answer.text == "창의열람실")
        {
            OT_NPC1_Quiz_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC1_Quiz_Wrong.gameObject.SetActive(true);
            OT_NPC1_Quiz_Answer.text = "";
        }
    }

    public void OT_NPC2_Quiz()
    {
        if (OT_NPC2_Quiz_Answer.text == "원스톱지원센터")
        {
            OT_NPC2_Quiz_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC2_Quiz_Wrong.gameObject.SetActive(true);
            OT_NPC2_Quiz_Answer.text = "";
        }
    }
    public void OT_NPC3_Quiz()
    {
        if (OT_NPC3_Quiz_Answer.text == "삶과꿈")
        {
            OT_NPC3_Quiz_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC3_Quiz_Wrong.gameObject.SetActive(true);
            OT_NPC3_Quiz_Answer.text = "";
        }
    }
    public void OT_NPC3_Quiz2()
    {
        if (OT_NPC3_Quiz2_Answer.text == "새내기")
        {
            OT_NPC3_Quiz2_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC3_Quiz2_Wrong.gameObject.SetActive(true);
            OT_NPC3_Quiz2_Answer.text = "";
        }
    }
    public void OT_NPC5_Quiz()
    {
        if (OT_NPC5_Quiz_Answer.text == "그라찌에")
        {
            OT_NPC5_Quiz_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC5_Quiz_Wrong.gameObject.SetActive(true);
            OT_NPC5_Quiz_Answer.text = "";
        }
    }
    public void OT_NPC5_Quiz2()
    {
        if (OT_NPC5_Quiz2_Answer.text == "신입생오리엔테이션")
        {
            OT_NPC5_Quiz2_right.gameObject.SetActive(true);
        }
        else
        {
            OT_NPC5_Quiz2_Wrong.gameObject.SetActive(true);
            OT_NPC5_Quiz2_Answer.text = "";
        }
    }
    public void NPC1_Quiz()
    {

        if (NPC1_Quiz_Answer.text == "2587")
        {
            NPC1_Quiz_right.gameObject.SetActive(true);
        }
        else
        {
            NPC1_Quiz_Wrong.gameObject.SetActive(true);
            NPC1_Quiz_Answer.text = "";
        }

    } //NPC1 Quiz



    public void NPC4_Quiz1()
    {

        if (NPC4_Quiz1_Answer.text == "2")
        {
            NPC4_Quiz1_right.gameObject.SetActive(true);
            NPC4_Quiz1_Answer.text = "";
        }
        else if (count_1 == 0)
        {
            NPC4_Quiz1_wrong.gameObject.SetActive(true);
            NPC4_Quiz1_Answer.text = "";
            count_1++;
        }
        else if (count_1 == 1)
        {
            NPC4_Quiz1_wrong.gameObject.SetActive(false);
            NPC4_Quiz1_wrong2.gameObject.SetActive(true);
            NPC4_Quiz1_Answer.text = "";
        }

    }
    public void NPC4_Quiz2()
    {

        if (NPC4_Quiz2_Answer.text == "4")
        {
            NPC4_Quiz2_right.gameObject.SetActive(true);
            NPC4_Quiz2_Answer.text = "";
        }
        else if (count_2 == 0)
        {
            NPC4_Quiz2_wrong.gameObject.SetActive(true);
            NPC4_Quiz2_Answer.text = "";
            count_2++;
        }
        else if (count_2 == 1)
        {
            NPC4_Quiz2_wrong.gameObject.SetActive(false);
            NPC4_Quiz2_wrong2.gameObject.SetActive(true);
            NPC4_Quiz2_Answer.text = "";
        }

    }
    public void NPC4_Quiz3()
    {

        if (NPC4_Quiz3_Answer.text == "이보영")
        {
            NPC4_Quiz3_right.gameObject.SetActive(true);
            NPC4_Quiz3_Answer.text = "";
        }
        else
        {
            NPC4_Quiz3_wrong.gameObject.SetActive(true);
            NPC4_Quiz3_Answer.text = "";
        }
    }
    public void NPC4_Quiz4()
    {

        if (NPC4_Quiz4_Answer.text == "다이빙")
        {
            NPC4_Quiz4_right.gameObject.SetActive(true);
            NPC4_Quiz4_Answer.text = "";
        }
        else
        {
            NPC4_Quiz4_wrong.gameObject.SetActive(true);
            NPC4_Quiz4_Answer.text = "";
        }

    }//NPC4 Quiz

    public void NPC5_Quiz1()
    {
        if (NPC5_Quiz1_Answer.text == "25")
        {
            NPC5_Quiz1_right.gameObject.SetActive(true);
            NPC5_Quiz1_Answer.text = "";
        }
        else
        {
            NPC5_Quiz1_wrong.gameObject.SetActive(true);
            NPC5_Quiz1_Answer.text = "";
        }
    }
    public void NPC5_Quiz2()
    {
        if (NPC5_Quiz2_Answer.text == "낙산멍이")
        {
            NPC5_Quiz2_right.gameObject.SetActive(true);
            NPC5_Quiz2_Answer.text = "";
        }
        else
        {
            NPC5_Quiz2_wrong.gameObject.SetActive(true);
            NPC5_Quiz2_Answer.text = "";
        }
    }//NPC5 Quiz

    public void NPC_Chicken_Quiz()
    {
        if (NPC_Chicken_Quiz_Answer.text == "chicken")
        {
            NPC_Chicken_Quiz_right.gameObject.SetActive(true);
            NPC_Chicken_Quiz_Answer.text = "";
        }
        else
        {
            NPC_Chicken_Quiz_wrong.gameObject.SetActive(true);
            NPC_Chicken_Quiz_Answer.text = "";
        }
    }//NPC Chicken Quiz


    public void NPC_Food_Quiz()
    {
        if (NPC_FoodZone_Quiz_Answer.text == "70500")
        {
            NPC_FoodZone_Quiz_right.gameObject.SetActive(true);
            NPC_FoodZone_Quiz_Answer.text = "";
        }
        else
        {
            NPC_FoodZone_Quiz_wrong.gameObject.SetActive(true);
            NPC_FoodZone_Quiz_Answer.text = "";
        }
    }//NPC FoodZone Quiz




    public void NPC_WordPuzzle_Quiz1()
    {
        if (NPC_WordPuzzle_Quiz1_Answer.text == "대동제")
        {
            NPC_WordPuzzle_Quiz1_right.gameObject.SetActive(true);
            NPC_WordPuzzle_Quiz1_Answer.text = "";
        }
        else
        {
            NPC_WordPuzzle_Quiz1_wrong.gameObject.SetActive(true);
            NPC_WordPuzzle_Quiz1_Answer.text = "";
        }
    }

    public void NPC_WordPuzzle_Quiz2()
    {
        if (NPC_WordPuzzle_Quiz2_Answer.text == "낙산공원")
        {
            NPC_WordPuzzle_Quiz2_right.gameObject.SetActive(true);
            NPC_WordPuzzle_Quiz2_Answer.text = "";
        }
        else
        {
            NPC_WordPuzzle_Quiz2_wrong.gameObject.SetActive(true);
            NPC_WordPuzzle_Quiz2_Answer.text = "";
        }
    }//NPC Tutle Puzzle

    public void Hidden1QuestStart()
    {

        if (H1Stamp.gameObject.activeSelf == true)
        {
            H1_talk1.gameObject.SetActive(false);
            H1_ClearAfterTalk.gameObject.SetActive(true);
        }

        else
        {
            H1_talk1.gameObject.SetActive(true);
            H1_ClearAfterTalk.gameObject.SetActive(false);
        }
    }
    public void Hidden2QuestStart()
    {

        if (H2Stamp.gameObject.activeSelf == true)
        {
            H2_talk1.gameObject.SetActive(false);
            H2_ClearAfterTalk.gameObject.SetActive(true);
        }

        else
        {
            H2_talk1.gameObject.SetActive(true);
            H2_ClearAfterTalk.gameObject.SetActive(false);
        }
    }
    public void Hidden3QuestStart()
    {

        if (H3Stamp.gameObject.activeSelf == true)
        {
            H3_talk1.gameObject.SetActive(false);
            H3_ClearAfterTalk.gameObject.SetActive(true);
        }

        else
        {
            H3_talk1.gameObject.SetActive(true);
            H3_ClearAfterTalk.gameObject.SetActive(false);
        }
    }
    public void Hidden4QuestStart()
    {

        if (H4Stamp.gameObject.activeSelf == true)
        {
            H4_talk1.gameObject.SetActive(false);
            H4_ClearAfterTalk.gameObject.SetActive(true);
        }

        else
        {
            H4_talk1.gameObject.SetActive(true);
            H4_ClearAfterTalk.gameObject.SetActive(false);
        }
    }


    public void Hidden5QuestStart()
    {

        if (H5Stamp.gameObject.activeSelf == true)
        {
            H5_talk1.gameObject.SetActive(false);
            H5_ClearAfterTalk.gameObject.SetActive(true);
        }

        else
        {
            H5_talk1.gameObject.SetActive(true);
            H5_ClearAfterTalk.gameObject.SetActive(false);
        }
    }
    //QuestDialog 
    //--------------------------------------------------퀘스트완료처리---------------------------------------//

    public void QuestOpen()
    {
        QuestButton.gameObject.SetActive(true);

        //M1.interactable = true;
        OT1.interactable = true;

        Hidden1.gameObject.SetActive(true);
        Hidden2.gameObject.SetActive(true);
        Hidden3.gameObject.SetActive(true);
        Hidden4.gameObject.SetActive(true);
        Hidden5.gameObject.SetActive(true);

        OTNPC0.gameObject.SetActive(false);
        OTNPC1.gameObject.SetActive(true);

        join.SetValueFireBase("OT0");
        Debug.Log("Quest Open");
    }


    //OT Mission
    public void OT1QuestClear()
    {
        OT2.interactable = true;

        OTNPC1.gameObject.SetActive(false);
        OTNPC2.gameObject.SetActive(true);

        OT1Stamp.gameObject.SetActive(true);
        OT1Complete.gameObject.SetActive(true);

        OT_ButtonClick();

        join.SetValueFireBase("OT1");
        Debug.Log("OT1 clear & save");

        plusMoney();
    }

    public void OT1QuestCleared()
    {
        OT2.interactable = true;

        OTNPC1.gameObject.SetActive(false);
        OTNPC2.gameObject.SetActive(true);

        OT1Stamp.gameObject.SetActive(true);
        OT1Complete.gameObject.SetActive(true);

        OT_ButtonClick();
    }

    public void OT2QuestClear()
    {
        OT3.interactable = true;

        OTNPC2.gameObject.SetActive(false);
        OTNPC3.gameObject.SetActive(true);

        OT2Stamp.gameObject.SetActive(true);
        OT2Complete.gameObject.SetActive(true);
        plusMoney();

        OT_ButtonClick();

        join.SetValueFireBase("OT2");
        Debug.Log("OT2 clear & save");
    }

    public void OT2QuestCleared()
    {
        OT3.interactable = true;

        OTNPC2.gameObject.SetActive(false);
        OTNPC3.gameObject.SetActive(true);

        OT2Stamp.gameObject.SetActive(true);
        OT2Complete.gameObject.SetActive(true);

        OT_ButtonClick();
    }

    public void OT3QuestClear()
    {
        OT4.interactable = true;

        OTNPC3.gameObject.SetActive(false);
        OTNPC4.gameObject.SetActive(true);

        OT3Stamp.gameObject.SetActive(true);
        OT3Complete.gameObject.SetActive(true);

        OT_ButtonClick();
        plusMoney();
        join.SetValueFireBase("OT3");
        Debug.Log("OT3 clear & save");
    }
    public void OT3QuestCleared()
    {
        OT4.interactable = true;

        OTNPC3.gameObject.SetActive(false);
        OTNPC4.gameObject.SetActive(true);

        OT3Stamp.gameObject.SetActive(true);
        OT3Complete.gameObject.SetActive(true);

        OT_ButtonClick();

    }
    public void OT4QuestClear()
    {
        OT5.interactable = true;

        OTNPC4.gameObject.SetActive(false);
        OTNPC5.gameObject.SetActive(true);

        OT4Stamp.gameObject.SetActive(true);
        OT4Complete.gameObject.SetActive(true);

        OT_ButtonClick();
        plusMoney();
        join.SetValueFireBase("OT4");
        Debug.Log("OT4 clear & save");
    }
    public void OT4QuestCleared()
    {
        OT5.interactable = true;

        OTNPC4.gameObject.SetActive(false);
        OTNPC5.gameObject.SetActive(true);

        OT4Stamp.gameObject.SetActive(true);
        OT4Complete.gameObject.SetActive(true);

        OT_ButtonClick();

    }
    public void OT5QuestClear()
    {
        OTNPC4.gameObject.SetActive(false);

        OT5Stamp.gameObject.SetActive(true);
        OT5Complete.gameObject.SetActive(true);

        OT_ButtonClick();
        plusMoney();
        join.SetValueFireBase("OT5");
        Debug.Log("OT5 clear & save");
        NPC1.gameObject.SetActive(true);
        OTNPC5.gameObject.SetActive(false);
        M1.interactable = true;
        //NPC0.gameObject.SetActive(false);
        //NPC1.gameObject.SetActive(true);
    }
    public void OT5QuestCleared()
    {
        OTNPC4.gameObject.SetActive(false);

        OT5Stamp.gameObject.SetActive(true);
        OT5Complete.gameObject.SetActive(true);

        OT_ButtonClick();

        NPC1.gameObject.SetActive(true);
        OTNPC5.gameObject.SetActive(false);
        M1.interactable = true;
        //NPC0.gameObject.SetActive(false);
        //NPC1.gameObject.SetActive(true);
    }
    // OT End 

    public void Mission1QuestClear()
    {
        M2.interactable = true;

        NPC1.gameObject.SetActive(false);
        NPC2.gameObject.SetActive(true);

        M1Stamp.gameObject.SetActive(true);
        M1Complete.gameObject.SetActive(true);

        M_ButtonClick();
        plusMoney();
        join.SetValueFireBase("D1");
        Debug.Log("Mission1 clear & save");
    }
    public void Mission1QuestCleared()
    {
        M2.interactable = true;

        NPC1.gameObject.SetActive(false);
        NPC2.gameObject.SetActive(true);

        M1Stamp.gameObject.SetActive(true);
        M1Complete.gameObject.SetActive(true);

        M_ButtonClick();
    }
    public void Mission2QuestClear()
    {
        M3.interactable = true;

        NPC2.gameObject.SetActive(false);
        NPC3.gameObject.SetActive(true);

        M2Stamp.gameObject.SetActive(true);
        M2Complete.gameObject.SetActive(true);

        M_ButtonClick();
        plusMoney();
        join.SetValueFireBase("D2");
        Debug.Log("Mission2 clear & save");
    }
    public void Mission2QuestCleared()
    {
        M3.interactable = true;

        NPC2.gameObject.SetActive(false);
        NPC3.gameObject.SetActive(true);

        M2Stamp.gameObject.SetActive(true);
        M2Complete.gameObject.SetActive(true);

        M_ButtonClick();
    }
    public void Mission3QuestClear()
    {
        M4.interactable = true;

        NPC3.gameObject.SetActive(false);
        NPC4.gameObject.SetActive(true);

        M3Stamp.gameObject.SetActive(true);
        M3Complete.gameObject.SetActive(true);

        M_ButtonClick();
        plusMoney();
        join.SetValueFireBase("D3");
        Debug.Log("Mission3 clear & save");
    }
    public void Mission3QuestCleared()
    {
        M4.interactable = true;

        NPC3.gameObject.SetActive(false);
        NPC4.gameObject.SetActive(true);

        M3Stamp.gameObject.SetActive(true);
        M3Complete.gameObject.SetActive(true);

        M_ButtonClick();

    }

    public void Mission4QuestClear()
    {
        M5.interactable = true;

        NPC4.gameObject.SetActive(false);
        NPC5.gameObject.SetActive(true);

        M4Stamp.gameObject.SetActive(true);
        M4Complete.gameObject.SetActive(true);

        M_ButtonClick();
        plusMoney();
        join.SetValueFireBase("D4");
        Debug.Log("Mission4 clear & save");
    }
    public void Mission4QuestCleared()
    {
        M5.interactable = true;

        NPC4.gameObject.SetActive(false);
        NPC5.gameObject.SetActive(true);

        M4Stamp.gameObject.SetActive(true);
        M4Complete.gameObject.SetActive(true);

        M_ButtonClick();
    }
    public void Mission5QuestClear()
    {
        NPC4.gameObject.SetActive(false);

        M5Stamp.gameObject.SetActive(true);
        M5Complete.gameObject.SetActive(true);

        M_ButtonClick();
        plusMoney();
        join.SetValueFireBase("D5");
        Debug.Log("Mission5 clear & save");

    }
    public void Mission5QuestCleared()
    {
        NPC4.gameObject.SetActive(false);

        M5Stamp.gameObject.SetActive(true);
        M5Complete.gameObject.SetActive(true);

        M_ButtonClick();

    }
    public void Hidden1QuestClear()
    {
        H1.interactable = true;
        H1Text.text = "꼬꼬&꾸꾸 밥 주기";

        H1Stamp.gameObject.SetActive(true);
        H1Complete.gameObject.SetActive(true);

        H_ButtonClick();
        plusMoney();
        join.SetValueFireBase("H1");
        Debug.Log("HiddenMission1 clear & save");
    }
    public void Hidden1QuestCleared()
    {
        H1.interactable = true;
        H1Text.text = "꼬꼬&꾸꾸 밥 주기";

        H1Stamp.gameObject.SetActive(true);
        H1Complete.gameObject.SetActive(true);

        H_ButtonClick();
    }

    public void Hidden2QuestClear()
    {
        H2.interactable = true;
        H2Text.text = "그라지에 메뉴 맞추기";

        H2Stamp.gameObject.SetActive(true);
        H2Complete.gameObject.SetActive(true);

        H_ButtonClick();
        plusMoney();
        join.SetValueFireBase("H2");
        Debug.Log("HiddenMission2 clear & save");
    }
    public void Hidden2QuestCleared()
    {
        H2.interactable = true;
        H2Text.text = "그라지에 메뉴 맞추기";

        H2Stamp.gameObject.SetActive(true);
        H2Complete.gameObject.SetActive(true);

        H_ButtonClick();
    }
    public void Hidden3QuestClear()
    {
        H3.interactable = true;
        H3Text.text = "낱말퍼즐 풀기";

        H3Stamp.gameObject.SetActive(true);
        H3Complete.gameObject.SetActive(true);

        H_ButtonClick();
        plusMoney();
        join.SetValueFireBase("H3");
        Debug.Log("HiddenMission3 clear & save");
    }
    public void Hidden3QuestCleared()
    {
        H3.interactable = true;
        H3Text.text = "낱말퍼즐 풀기";

        H3Stamp.gameObject.SetActive(true);
        H3Complete.gameObject.SetActive(true);

        H_ButtonClick();
    }
    public void Hidden4QuestClear()
    {
        H4.interactable = true;
        H4Text.text = "틀린그림찾기";

        H4Stamp.gameObject.SetActive(true);
        H4Complete.gameObject.SetActive(true);

        H_ButtonClick();
        plusMoney();
        join.SetValueFireBase("H4");
        Debug.Log("HiddenMission4 clear & save");
    }
    public void Hidden4QuestCleared()
    {
        H4.interactable = true;
        H4Text.text = "틀린그림찾기";

        H4Stamp.gameObject.SetActive(true);
        H4Complete.gameObject.SetActive(true);

        H_ButtonClick();
    }
    public void Hidden5QuestClear()
    {
        H5.interactable = true;
        H5Text.text = "매출액 계산하기";

        H5Stamp.gameObject.SetActive(true);
        H5Complete.gameObject.SetActive(true);

        H_ButtonClick();
        plusMoney();
        join.SetValueFireBase("H5");
        Debug.Log("HiddenMission5 clear & save");
    }
    public void Hidden5QuestCleared()
    {
        H5.interactable = true;
        H5Text.text = "매출액 계산하기";

        H5Stamp.gameObject.SetActive(true);
        H5Complete.gameObject.SetActive(true);

        H_ButtonClick();
    }
    //Clear

    public void QuestButtonClick()
    {
        QuestList.gameObject.SetActive(true);
        M_list.gameObject.SetActive(false); //나중에 바꿔야함!!
        H_list.gameObject.SetActive(false);
        O_list.gameObject.SetActive(false);
        OT_list.gameObject.SetActive(true);

        Basic_detail.gameObject.SetActive(true);
        M_detail.gameObject.SetActive(false);
        H_detail.gameObject.SetActive(false);
        O_detail.gameObject.SetActive(false);
        OT_detail.gameObject.SetActive(false);
    }

    public void M_ButtonClick()
    {
        M_list.gameObject.SetActive(true);
        H_list.gameObject.SetActive(false);
        O_list.gameObject.SetActive(false);
        OT_list.gameObject.SetActive(false);
        Main.gameObject.SetActive(false);

        Basic_detail.gameObject.SetActive(true);
        M_detail.gameObject.SetActive(false);
        H_detail.gameObject.SetActive(false);
        O_detail.gameObject.SetActive(false);
        OT_detail.gameObject.SetActive(false);
        Main_detail.gameObject.SetActive(false);
    }

    public void H_ButtonClick()
    {
        M_list.gameObject.SetActive(false);
        H_list.gameObject.SetActive(true);
        O_list.gameObject.SetActive(false);
        OT_list.gameObject.SetActive(false);
        Main.gameObject.SetActive(false);

        Basic_detail.gameObject.SetActive(true);
        M_detail.gameObject.SetActive(false);
        H_detail.gameObject.SetActive(false);
        O_detail.gameObject.SetActive(false);
        OT_detail.gameObject.SetActive(false);
        Main_detail.gameObject.SetActive(false);
    }

    public void Main_ButtonClick()
    {
        M_list.gameObject.SetActive(false);
        H_list.gameObject.SetActive(false);
        O_list.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);

        Basic_detail.gameObject.SetActive(true);
        M_detail.gameObject.SetActive(false);
        H_detail.gameObject.SetActive(false);
        O_detail.gameObject.SetActive(false);
        //Main_detail.gameObject.SetActive(true);
    }

    public void OT_ButtonClick()
    {
        M_list.gameObject.SetActive(false);
        H_list.gameObject.SetActive(false);
        O_list.gameObject.SetActive(false);
        OT_list.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);

        Basic_detail.gameObject.SetActive(true);
        M_detail.gameObject.SetActive(false);
        H_detail.gameObject.SetActive(false);
        O_detail.gameObject.SetActive(false);
        OT_detail.gameObject.SetActive(true);
        Main_detail.gameObject.SetActive(false);
    }
    //QuestList

    public void Questreset()
    {

        /*reference.Child("M1").SetValueAsync(false);
        reference.Child("M2").SetValueAsync(false);
        reference.Child("M3").SetValueAsync(false);
        reference.Child("M4").SetValueAsync(false);
        reference.Child("M5").SetValueAsync(false);
        reference.Child("H1").SetValueAsync(false);
        reference.Child("H2").SetValueAsync(false);
        reference.Child("H3").SetValueAsync(false);
        reference.Child("H4").SetValueAsync(false);
        reference.Child("H5").SetValueAsync(false);
        //QuestField true -> false

        NPC0.gameObject.SetActive(true);
        NPC1.gameObject.SetActive(false);
        NPC2.gameObject.SetActive(false);
        NPC3.gameObject.SetActive(false);
        NPC4.gameObject.SetActive(false);
        NPC5.gameObject.SetActive(false);
        //NPC reset

        M1Stamp.gameObject.SetActive(false);
        M2Stamp.gameObject.SetActive(false);
        M3Stamp.gameObject.SetActive(false);
        M4Stamp.gameObject.SetActive(false);
        M5Stamp.gameObject.SetActive(false);
        H1Stamp.gameObject.SetActive(false);
        H2Stamp.gameObject.SetActive(false);
        H3Stamp.gameObject.SetActive(false);
        H4Stamp.gameObject.SetActive(false);
        H5Stamp.gameObject.SetActive(false);
        //All Stamp reset

        M1Complete.gameObject.SetActive(false);
        M2Complete.gameObject.SetActive(false);
        M3Complete.gameObject.SetActive(false);
        M4Complete.gameObject.SetActive(false);
        M5Complete.gameObject.SetActive(false);
        H1Complete.gameObject.SetActive(false);
        H2Complete.gameObject.SetActive(false);
        H3Complete.gameObject.SetActive(false);
        H4Complete.gameObject.SetActive(false);
        H5Complete.gameObject.SetActive(false);
        //All Complete reset


        M1.interactable = true;
        M2.interactable = false;
        M3.interactable = false;
        M4.interactable = false;
        M5.interactable = false;

        H1.interactable = false;
        H2.interactable = false;
        H3.interactable = false;
        H4.interactable = false;
        H5.interactable = false;

        H1Text.text = "?????";
        H2Text.text = "?????";
        H3Text.text = "?????";
        H4Text.text = "?????";
        H5Text.text = "?????";
        //Quest List Button reset


        Debug.Log("Quest Reset");*/
    }
    public void plusMoney()
    {
        money = join.money;
        int m = int.Parse(money);
        m += 200;
        join.SetValueFireBase("money", money);
    }

}