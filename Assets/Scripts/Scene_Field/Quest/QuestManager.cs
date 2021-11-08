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
    public InputField NPC1_Quiz_Answer;
    public Image NPC1_Quiz_right, NPC1_Quiz_Wrong;
    //NPC1 Quiz

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

    //Quest List Button
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

    
    public Text IdentityID_text;
    public Text StuID_text;

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
        reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(join.IdentityID);
        
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

                IdentityID_text.text = join.IdentityID.Substring(10);
                StuID_text.text = "학번 : "+myStdId+ "\n" + "이름 : " + myName;

                if (m0cleared.Equals("True"))
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

                if(h1cleared.Equals("True"))
                {
                    Hidden1QuestClear();
                }

                if (h2cleared.Equals("True"))
                {
                    Hidden2QuestClear();
                }

                if (h3cleared.Equals("True"))
                {
                    Hidden3QuestClear();
                }

                if (h4cleared.Equals("True"))
                {
                    Hidden4QuestClear();
                }

                if (h5cleared.Equals("True"))
                {
                    Hidden5QuestClear();
                }

                else return;
            }
        });
    }
    

   
    public void NPC1_Quiz()
    {
       
            if (NPC1_Quiz_Answer.text == "4268")
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
        if(NPC_Chicken_Quiz_Answer.text == "chicken")
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
        if(NPC_WordPuzzle_Quiz1_Answer.text == "대동제")
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

    public void Hidden1QuestClear()
    {
        H1.interactable = true;
        H1Text.text = "꼬꼬&꾸꾸 밥 주기";

        H1Stamp.gameObject.SetActive(true);
        H1Complete.gameObject.SetActive(true);

        reference.Child("H1").SetValueAsync(true);
        Debug.Log("HiddenMission1 clear & save");
    }
    

    public void Hidden2QuestClear()
    {
        H2.interactable = true;
        H2Text.text = "그라지에 메뉴 맞추기";

        H2Stamp.gameObject.SetActive(true);
        H2Complete.gameObject.SetActive(true);

        reference.Child("H2").SetValueAsync(true);
        Debug.Log("HiddenMission2 clear & save");
    }
   
    public void Hidden3QuestClear()
    {
        H3.interactable = true;
        H3Text.text = "낱말퍼즐 풀기";

        H3Stamp.gameObject.SetActive(true);
        H3Complete.gameObject.SetActive(true);

        reference.Child("H3").SetValueAsync(true);
        Debug.Log("HiddenMission3 clear & save");
    }
    public void Hidden4QuestClear()
    {
        H4.interactable = true;
        H4Text.text = "틀린그림찾기";

        H4Stamp.gameObject.SetActive(true);
        H4Complete.gameObject.SetActive(true);

        reference.Child("H4").SetValueAsync(true);
        Debug.Log("HiddenMission4 clear & save");
    }
    public void Hidden5QuestClear()
    {
        H5.interactable = true;
        H5Text.text = "매출액 계산하기";

        H5Stamp.gameObject.SetActive(true);
        H5Complete.gameObject.SetActive(true);

        reference.Child("H5").SetValueAsync(true);
        Debug.Log("HiddenMission5 clear & save");
    }



    public void Questreset()
    {
        reference.Child("M0").SetValueAsync(false);
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
