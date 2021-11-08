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

    //NPC1 Quiz
    public InputField NPC_1_Quiz_1_Answer;
    public Image right1;
    public Image Wrong1;

    public InputField question2;

    //NPC5 Quiz
    public InputField NPC_5_Quiz_1_Answer, NPC_5_Quiz_2_Answer;
    public Image right5;
    public Image Wrong5;
    public Image right6;
    public Image Wrong6;
    
    //NPC5 Quiz end

    //NPC Chicken Quiz
    public InputField NPC_Chicken_Answer;
    public Image right2;
    public Image Wrong2;

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
    public Button QuestButton;

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
    
    //NPC FoodZone Quiz
    public InputField NPC_Food_Answer;
    public Image right8;
    public Image Wrong8;
    

    public Image right4;
    public Image Wrong4;


    //NPC Object
    public GameObject NPC0;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject NPC5;

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


    Dictionary<int, QuestData> questList;
    JoinDB user;
    FirebaseAuth auth;
    [SerializeField]
    public DatabaseReference reference = null;
    string myName="0";
    string myStdId;
    string m0cleared = "false";
    string m1cleared = "false";
    string m2cleared = "false";
    string m3cleared = "false";
    string m4cleared = "false";
    string m5cleared = "false";
    string h1cleared = "false";
    string h2cleared = "false";
    string h3cleared = "false";
    string h4cleared = "false";
    string h5cleared = "false";


    DataSnapshot ds;
    FirebaseApp app;

    void Awake()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });



        auth = FirebaseAuth.DefaultInstance;
        questList = new Dictionary<int, QuestData>();
        
    }

    void Start()
    {

        join = GameObject.Find("Join").GetComponent<Join>();

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

        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsu-on-festival-default-rtdb.firebaseio.com/");

        
        // 파이어베이스의 메인 참조 얻기
        //reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(join.email);
        reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(join.password);
        
        reference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
              // Handle the error...
            }
            else if (task.IsCompleted)
            {
              DataSnapshot dataSnapshot = task.Result;
                ds = dataSnapshot;
                myName = dataSnapshot.Child("name").GetValue(true).ToString();
                Debug.Log(myName);
                myStdId = dataSnapshot.Child("stdID").GetValue(true).ToString();
                Debug.Log(myStdId);
                m0cleared = dataSnapshot.Child("M0").GetValue(true).ToString();
                Debug.Log(m0cleared);
                m1cleared = dataSnapshot.Child("M1").GetValue(true).ToString();
                Debug.Log(m1cleared);
                m2cleared = dataSnapshot.Child("M2").GetValue(true).ToString();
                Debug.Log(m2cleared);
                m3cleared = dataSnapshot.Child("M3").GetValue(true).ToString();
                Debug.Log(m3cleared);
                m4cleared = dataSnapshot.Child("M4").GetValue(true).ToString();
                Debug.Log(m4cleared);
                m5cleared = dataSnapshot.Child("M5").GetValue(true).ToString();
                Debug.Log(m5cleared);
                h1cleared = dataSnapshot.Child("H1").GetValue(true).ToString();
                Debug.Log(h1cleared);
                h2cleared = dataSnapshot.Child("H2").GetValue(true).ToString();
                Debug.Log(h2cleared);
                h3cleared = dataSnapshot.Child("H3").GetValue(true).ToString();
                Debug.Log(h3cleared);
                h4cleared = dataSnapshot.Child("H4").GetValue(true).ToString();
                Debug.Log(h4cleared);
                h5cleared = dataSnapshot.Child("H5").GetValue(true).ToString();
                Debug.Log(h5cleared);

                if(m0cleared.Equals("True"))
                {
                    QuestOpen();
                }

                if (m1cleared.Equals("True"))
                {
                    Mission1QuestClear();
                }

                if (m2cleared.Equals("True"))
                {
                    Mission2QuestClear();
                }

                if (m3cleared.Equals("True"))
                {
                    Mission3QuestClear();
                }

                if (m4cleared.Equals("True"))
                {
                    Mission4QuestClear();
                }

                if (m5cleared.Equals("True"))
                {
                    Mission5QuestClear();
                }



                else return;
                /*myName = ds.Child("name").GetValue(true).ToString();
                myStdId = ds.Child("stdId").GetValue(true).ToString();
                Debug.Log(myName);
                Debug.Log(myStdId);*/
                // Do something with snapshot...
            }
        });
        

        



        //Debug.Log(ds.Children);



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


    public void QuestOpen()
	{
        QuestButton.gameObject.SetActive(true);

        M1.interactable = true;
        
        NPC0.gameObject.SetActive(false);
        NPC1.gameObject.SetActive(true);

        reference.Child("M0").SetValueAsync(true);
        Debug.Log("Quest Open");
    }

    public void Mission1QuestClear()
	{
        M2.interactable = true;

        NPC1.gameObject.SetActive(false);
        NPC2.gameObject.SetActive(true);

        M1Stamp.gameObject.SetActive(true);
        M1Complete.gameObject.SetActive(true);

        reference.Child("M1").SetValueAsync(true);
        Debug.Log("Mission1 clear & save");
    }

    public void Mission2QuestClear()
	{
        M3.interactable = true;

        NPC2.gameObject.SetActive(false);
        NPC3.gameObject.SetActive(true);

        M2Stamp.gameObject.SetActive(true);
        M2Complete.gameObject.SetActive(true);

        reference.Child("M2").SetValueAsync(true);
        Debug.Log("Mission2 clear & save");
    }

    public void Mission3QuestClear()
    {
        M4.interactable = true;

        NPC3.gameObject.SetActive(false);
        NPC4.gameObject.SetActive(true);

        M3Stamp.gameObject.SetActive(true);
        M3Complete.gameObject.SetActive(true);

        reference.Child("M3").SetValueAsync(true);
        Debug.Log("Mission3 clear & save");
    }

    public void Mission4QuestClear()
    {
        M5.interactable = true;

        NPC4.gameObject.SetActive(false);
        NPC5.gameObject.SetActive(true);

        M4Stamp.gameObject.SetActive(true);
        M4Complete.gameObject.SetActive(true);

        reference.Child("M4").SetValueAsync(true);
        Debug.Log("Mission4 clear & save");
    }

    public void Mission5QuestClear()
    {
        NPC4.gameObject.SetActive(false);

        M5Stamp.gameObject.SetActive(true);
        M5Complete.gameObject.SetActive(true);

        reference.Child("M5").SetValueAsync(true);
        Debug.Log("Mission5 clear & save");

    }

    public void Hidden1QuestOpen()
    {
        H1.interactable = true;
        H1Text.text = "꼬꼬&꾸꾸 밥 주기";
        reference.Child("H1").SetValueAsync(true);
    }
    

    public void Hidden2QuestOpen()
    {
        H2.interactable = true;
        H2Text.text = "그라지에 메뉴 맞추기";
        reference.Child("H2").SetValueAsync(true);
    }
   
    public void Hidden3QuestOpen()
    {
        H3.interactable = true;
        H3Text.text = "낱말퍼즐 풀기";
        reference.Child("H3").SetValueAsync(true);
    }
    public void Hidden4QuestOpen()
    {
        H4.interactable = true;
        H4Text.text = "틀린그림찾기";
        reference.Child("H4").SetValueAsync(true);
    }
    public void Hidden5QuestOpen()
    {
        H5.interactable = true;
        H5Text.text = "매출액 계산하기";
        reference.Child("H5").SetValueAsync(true);
    }

    
   
    public void Questreset()
	{
        reference.Child("M1").SetValueAsync(false);
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
        //All Stamp reset
		
        
        Debug.Log("Quest Reset");
    }

    




    public class JoinDB
    {
        public string email;
        public string password;
        public string name;
        public string dept;
        public string stdID;
        public bool M0;
        public bool M1;
        public bool M2;
        public bool M3;
        public bool M4;
        public bool M5;
        public bool H1;
        public bool H2;
        public bool H3;
        public bool H4;
        public bool H5;

        public JoinDB(string email, string password, string name, string dept, string stdID, bool M0, bool M1, bool M2, bool M3, bool M4, bool M5, bool H1, bool H2, bool H3, bool H4, bool H5)
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.dept = dept;
            this.stdID = stdID;
            this.M0 = M0;
            this.M1 = M1;
            this.M2 = M2;
            this.M3 = M3;
            this.M4 = M4;
            this.M5 = M5;
            this.H1 = H1;
            this.H2 = H2;
            this.H3 = H3;
            this.H4 = H4;
            this.H5 = H5;
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["email"] = this.email;
            dic["password"] = this.password;
            dic["name"] = this.name;
            dic["dept"] = this.dept;
            dic["stdID"] = this.stdID;
            dic["M0"] = this.M0;
            dic["M1"] = this.M1;
            dic["M2"] = this.M2;
            dic["M3"] = this.M3;
            dic["M4"] = this.M4;
            dic["M5"] = this.M5;
            dic["H1"] = this.H1;
            dic["H2"] = this.H2;
            dic["H3"] = this.H3;
            dic["H4"] = this.H4;
            dic["H5"] = this.H5;

            return dic;
        }
    }
}
