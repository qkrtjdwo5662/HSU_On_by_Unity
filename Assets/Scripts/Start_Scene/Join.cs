using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Join : MonoBehaviourPunCallbacks
{
    //private string gameVersion = "1";

    public Text connectionInfoText;
    public Text JoinInfoText;
    public Button LoginBtn;
    public Image arrow;
    Queue<string> queue = new Queue<string>();


    [SerializeField] public int PVID;
    [SerializeField] string email;
    [SerializeField] string password;
    [SerializeField] string userName;
    [SerializeField] string dept;
    [SerializeField] string stdID;
    [SerializeField] string UserID;



    public string m1cleared = "false";
    public string m2cleared = "false";
    public string m3cleared = "false";
    public string m4cleared = "false";
    public string m5cleared = "false";
    public string h1cleared = "false";
    public string h2cleared = "false";
    public string h3cleared = "false";
    public string h4cleared = "false";
    public string h5cleared = "false";

    public string ot0cleared = "false";
    public string ot1cleared = "false";
    public string ot2cleared = "false";
    public string ot3cleared = "false";
    public string ot4cleared = "false";
    public string ot5cleared = "false";

    public string d1cleared = "false";
    public string d2cleared = "false";
    public string d3cleared = "false";
    public string d4cleared = "false";
    public string d5cleared = "false";

    //--------------inventory-------------

    //hair
    public string hair01 = "false";
    public string hair02 = "false";
    public string hair03 = "false";
    public string hair04 = "false";
    public string hair05 = "false";
    public string hair06 = "false";
    public string hair07 = "false";
    public string hair08 = "false";
    public string hair09 = "false";
    public string hair10 = "false";

    //shirts
    public string shirts01 = "false";
    public string shirts02 = "false";
    public string shirts03 = "false";
    public string shirts04 = "false";
    public string shirts05 = "false";
    public string shirts06 = "false";
    public string shirts07 = "false";
    public string shirts08 = "false";
    public string shirts09 = "false";
    public string shirts10 = "false";

    //pants
    public string pants01 = "false";
    public string pants02 = "false";
    public string pants03 = "false";
    public string pants04 = "false";
    public string pants05 = "false";
    public string pants06 = "false";
    public string pants07 = "false";
    public string pants08 = "false";
    public string pants09 = "false";
    public string pants10 = "false";

    //pet
    public string pet01 = "false";
    public string pet02 = "false";
    public string pet03 = "false";
    public string pet04 = "false";
    public string pet05 = "false";
    public string pet06 = "false";
    public string pet07 = "false";
    public string pet08 = "false";
    public string pet09 = "false";
    public string pet10 = "false";

    public string money = "0";



    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public InputField inputTextEmail2;
    public InputField inputTextPassword2;
    public InputField inputName;
    public InputField inputStdId;
    public InputField inputDept;

    public Text joinResult;
    public Text loginResult;
    public Text LogZone;

    
    public bool isQueryEnd = false;

    public string getUserID()
    {
        return UserID;
    }

    public string getName()
    {
        return userName;
    }
    public string getStdId()
    {
        return stdID;
    }

    JoinDB user;
    DatabaseReference reference;
    FirebaseAuth auth;

    bool loginFlag = false;
    bool joinFlag = false;

    private void Start()
    {

        DontDestroyOnLoad(this);
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");

        // 파이어베이스의 메인 참조 얻기
        reference = FirebaseDatabase.DefaultInstance.RootReference;

    }


    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;

        //Invoke("JoinBtnOnClick", 1f);
    }

    private void Update()
    {
        if (queue.Count > 0)
        {
            Invoke(queue.Dequeue(), 0.1f);
        }
    }



    //버튼이 눌리면 실행할 함수.
    public void JoinBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;
        userName = inputName.text;
        dept = inputDept.text;
        stdID = inputStdId.text;

        Debug.Log("email:" + email + ",password:" + password);


        CreateUser();

    }

    void CreateUser()
    {

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync was cnaceled.");
                queue.Enqueue("JoinNext");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                queue.Enqueue("JoinNext");
                return;
            }

            if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0}({1})", newUser.DisplayName, newUser.UserId);
                UserID = newUser.UserId;
                Debug.Log("회원가입 성공");
                user = new JoinDB(UserID, email, password, userName, dept, stdID, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, 
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, "0");
                //item = new JoinDB.ItemDB(false, false, false, false, false, false, false, false, false, false);
                CreateUserWithJson(UserID, new JoinDB(UserID, email, password, userName, dept, stdID, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, false, false, false, false, false, false, false,
                    false, false, false, "0"));
                //CreateUserWithJson(item, new JoinDB.ItemDB(false, false, false, false, false, false, false, false, false, false));
                joinFlag = true;
                queue.Enqueue("JoinNext");
                return;
            }

        });
    }
    public void GetUserInformationFromFireBase()
    {
        reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(UserID);
        //item = FirebaseDatabase.DefaultInstance.GetReference("users").Child(UserID).Child("item");


        reference.GetValueAsync().ContinueWithOnMainThread(task =>
        {

            if (task.IsCompleted)
            {
                DataSnapshot dataSnapshot = task.Result;
                userName = dataSnapshot.Child("name").GetValue(true).ToString();
                stdID = dataSnapshot.Child("stdID").GetValue(true).ToString();
                Debug.Log(userName + " " + stdID);

                m1cleared = dataSnapshot.Child("M1").GetValue(true).ToString();
                m2cleared = dataSnapshot.Child("M2").GetValue(true).ToString();
                m3cleared = dataSnapshot.Child("M3").GetValue(true).ToString();
                m4cleared = dataSnapshot.Child("M4").GetValue(true).ToString();
                m5cleared = dataSnapshot.Child("M5").GetValue(true).ToString();
                Debug.Log("M " + m1cleared + " " + m2cleared + " " + m3cleared + " " + m4cleared + " " + m5cleared);


                h1cleared = dataSnapshot.Child("H1").GetValue(true).ToString();
                h2cleared = dataSnapshot.Child("H2").GetValue(true).ToString();
                h3cleared = dataSnapshot.Child("H3").GetValue(true).ToString();
                h4cleared = dataSnapshot.Child("H4").GetValue(true).ToString();
                h5cleared = dataSnapshot.Child("H5").GetValue(true).ToString();
                Debug.Log("H " + h1cleared + " " + h2cleared + " " + h3cleared + " " + h4cleared + " " + h5cleared);


                ot0cleared = dataSnapshot.Child("OT0").GetValue(true).ToString(); // 퀘스트 Open 여부
                ot1cleared = dataSnapshot.Child("OT1").GetValue(true).ToString();
                ot2cleared = dataSnapshot.Child("OT2").GetValue(true).ToString();
                ot3cleared = dataSnapshot.Child("OT3").GetValue(true).ToString();
                ot4cleared = dataSnapshot.Child("OT4").GetValue(true).ToString();
                ot5cleared = dataSnapshot.Child("OT5").GetValue(true).ToString();
                Debug.Log("OT " + ot1cleared + " " + ot2cleared + " " + ot3cleared + " " + ot4cleared + " " + ot5cleared);


                d1cleared = dataSnapshot.Child("D1").GetValue(true).ToString();
                d2cleared = dataSnapshot.Child("D2").GetValue(true).ToString();
                d3cleared = dataSnapshot.Child("D3").GetValue(true).ToString();
                d4cleared = dataSnapshot.Child("D4").GetValue(true).ToString();
                d5cleared = dataSnapshot.Child("D5").GetValue(true).ToString();
                Debug.Log("D " + d1cleared + " " + d2cleared + " " + d3cleared + " " + d4cleared + " " + d5cleared);
                Debug.Log("퀘스트 클리어 여부: " + ot0cleared);

                money = dataSnapshot.Child("Money").GetValue(true).ToString();

                hair01 = dataSnapshot.Child("Hair01").GetValue(true).ToString();
                hair02 = dataSnapshot.Child("Hair02").GetValue(true).ToString();
                hair03 = dataSnapshot.Child("Hair03").GetValue(true).ToString();
                hair04 = dataSnapshot.Child("Hair04").GetValue(true).ToString();
                hair05 = dataSnapshot.Child("Hair05").GetValue(true).ToString();
                hair06 = dataSnapshot.Child("Hair06").GetValue(true).ToString();
                hair07 = dataSnapshot.Child("Hair07").GetValue(true).ToString();
                hair08 = dataSnapshot.Child("Hair08").GetValue(true).ToString();
                hair09 = dataSnapshot.Child("Hair09").GetValue(true).ToString();
                hair10 = dataSnapshot.Child("Hair10").GetValue(true).ToString();
                Debug.Log("Hair " + hair01 + " " + hair02 + " " + hair03 + " " + hair04 + " " + hair05 + " " + hair06 + " " + hair07 + " " + hair08 + " " + hair09 + " " + hair10);
                
                shirts01 = dataSnapshot.Child("Shirts01").GetValue(true).ToString();
                shirts02 = dataSnapshot.Child("Shirts02").GetValue(true).ToString();
                shirts03 = dataSnapshot.Child("Shirts03").GetValue(true).ToString();
                shirts04 = dataSnapshot.Child("Shirts04").GetValue(true).ToString();
                shirts05 = dataSnapshot.Child("Shirts05").GetValue(true).ToString();
                shirts06 = dataSnapshot.Child("Shirts06").GetValue(true).ToString();
                shirts07 = dataSnapshot.Child("Shirts07").GetValue(true).ToString();
                shirts08 = dataSnapshot.Child("Shirts08").GetValue(true).ToString();
                shirts09 = dataSnapshot.Child("Shirts09").GetValue(true).ToString();
                shirts10 = dataSnapshot.Child("Shirts10").GetValue(true).ToString();

                pants01 = dataSnapshot.Child("Pants01").GetValue(true).ToString();
                pants02 = dataSnapshot.Child("Pants02").GetValue(true).ToString();
                pants03 = dataSnapshot.Child("Pants03").GetValue(true).ToString();
                pants04 = dataSnapshot.Child("Pants04").GetValue(true).ToString();
                pants05 = dataSnapshot.Child("Pants05").GetValue(true).ToString();
                pants06 = dataSnapshot.Child("Pants06").GetValue(true).ToString();
                pants07 = dataSnapshot.Child("Pants07").GetValue(true).ToString();
                pants08 = dataSnapshot.Child("Pants08").GetValue(true).ToString();
                pants09 = dataSnapshot.Child("Pants09").GetValue(true).ToString();
                pants10 = dataSnapshot.Child("Pants10").GetValue(true).ToString();

                pet01 = dataSnapshot.Child("Pet01").GetValue(true).ToString();
                pet02 = dataSnapshot.Child("Pet02").GetValue(true).ToString();
                pet03 = dataSnapshot.Child("Pet03").GetValue(true).ToString();
                pet04 = dataSnapshot.Child("Pet04").GetValue(true).ToString();
                pet05 = dataSnapshot.Child("Pet05").GetValue(true).ToString();
                pet06 = dataSnapshot.Child("Pet06").GetValue(true).ToString();
                pet07 = dataSnapshot.Child("Pet07").GetValue(true).ToString();
                pet08 = dataSnapshot.Child("Pet08").GetValue(true).ToString();
                pet09 = dataSnapshot.Child("Pet09").GetValue(true).ToString();
                pet10 = dataSnapshot.Child("Pet10").GetValue(true).ToString();

                isQueryEnd = true;

            }
            else if (task.IsFaulted) 
            {
                Debug.Log("테스크 생성 오류");
            }
        });
    }

    public void CreateUserWithJson(string _userID, JoinDB _userInfo)
    {

        string data = JsonUtility.ToJson(_userInfo);
        Debug.Log(data);
        reference.Child("users").Child(_userInfo.UserID).SetRawJsonValueAsync(data);
        //reference.Child("users").Child(_userInfo.UserID).Child("item").SetRawJsonValueAsync(data);
    }

    public void LoginBtnOnClick()
    {
        email = inputTextEmail2.text;
        password = inputTextPassword2.text;

        Debug.Log("email:" + email + ",password:" + password);


        LoginUser();

    }

    void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync was cnaceled.");
                queue.Enqueue("LoginNext");
                return;
            }
            else if (task.IsFaulted)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                queue.Enqueue("LoginNext");
                return;
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("Firebase user login successfully: {0}({1})", newUser.DisplayName, newUser.UserId);
                loginFlag = true;
                UserID = newUser.UserId;
                queue.Enqueue("LoginNext");
                
            }


        });

    }

    public void LoginNext()
    {

        if (loginFlag)
        {
            loginResult.text = "로그인 성공";
            
            
            LoadingSceneController.Instance.LoadScene("Scene_Character");
        }
        else
        {
            loginResult.text = "로그인 실패 : 이메일과 비밀번호를 확인해 주세요";
        }
    }
    public void JoinNext()
    {
        Debug.Log("조인넥스트 실행");
        if (joinFlag)
        {
            joinResult.text = "회원가입 성공";
            arrow.gameObject.SetActive(true);
        }
        else
        {
            joinResult.text = "회원가입 실패 : 요구사항을 정확히 입력해 주세요";
        }
    }

    public void SetValueFireBase(string msg) {

        reference.Child(msg).SetValueAsync(true);

    }
    public void SetValueFireBase(string msg, int money)
    {

        reference.Child(msg).SetValueAsync(money);

    }
    public class JoinDB
    {
        public string UserID;
        public string email;
        public string password;
        public string name;
        public string dept;
        public string stdID;
        //회원정보

        public bool OT0;
        public bool OT1;
        public bool OT2;
        public bool OT3;
        public bool OT4;
        public bool OT5;
        //OT 퀘스트

        public bool D1;
        public bool D2;
        public bool D3;
        public bool D4;
        public bool D5;
        //대동제 퀘스트

        public bool M1;
        public bool M2;
        public bool M3;
        public bool M4;
        public bool M5;
        //메인 퀘스트

        public bool H1;
        public bool H2;
        public bool H3;
        public bool H4;
        public bool H5;
        //히든 퀘스트



        //*----------------inventory----------------*//


        public bool Hair01;
        public bool Hair02;
        public bool Hair03;
        public bool Hair04;
        public bool Hair05;
        public bool Hair06;
        public bool Hair07;
        public bool Hair08;
        public bool Hair09;
        public bool Hair10;
        //머리색

        public bool Shirts01;
        public bool Shirts02;
        public bool Shirts03;
        public bool Shirts04;
        public bool Shirts05;
        public bool Shirts06;
        public bool Shirts07;
        public bool Shirts08;
        public bool Shirts09;
        public bool Shirts10;
        //상의

        public bool Pants01;
        public bool Pants02;
        public bool Pants03;
        public bool Pants04;
        public bool Pants05;
        public bool Pants06;
        public bool Pants07;
        public bool Pants08;
        public bool Pants09;
        public bool Pants10;
        //하의

        public bool Pet01;
        public bool Pet02;
        public bool Pet03;
        public bool Pet04;
        public bool Pet05;
        public bool Pet06;
        public bool Pet07;
        public bool Pet08;
        public bool Pet09;
        public bool Pet10;
        //펫

        public string money;


        
        public JoinDB(string UserID, string email, string password, string name, string dept, string stdID,
            bool OT0, bool OT1, bool OT2, bool OT3, bool OT4, bool OT5, 
            bool D1, bool D2, bool D3, bool D4, bool D5,
            bool M1, bool M2, bool M3, bool M4, bool M5,
            bool H1, bool H2, bool H3, bool H4, bool H5, 
            bool Hair01, bool Hair02, bool Hair03, bool Hair04, bool Hair05, bool Hair06, bool Hair07, bool Hair08, bool Hair09, bool Hair10,
            bool Shirts01, bool Shirts02, bool Shirts03, bool Shirts04, bool Shirts05, bool Shirts06, bool Shirts07, bool Shirts08, bool Shirts09, bool Shirts10,
            bool Pants01, bool Pants02, bool Pants03, bool Pants04, bool Pants05, bool Pants06, bool Pants07, bool Pants08, bool Pants09, bool Pants10,
            bool Pet01, bool Pet02, bool Pet03, bool Pet04, bool Pet05, bool Pet06, bool Pet07, bool Pet08, bool Pet09, bool Pet10, string money) 
        {
            this.UserID = UserID;
            this.email = email;
            this.password = password;
            this.name = name;
            this.dept = dept;
            this.stdID = stdID;

            this.OT0 = OT0;
            this.OT1 = OT1;
            this.OT2 = OT2;
            this.OT3 = OT3;
            this.OT4 = OT4;
            this.OT5 = OT5;
            this.D1 = D1;
            this.D2 = D2;
            this.D3 = D3;
            this.D4 = D4;
            this.D5 = D5;
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


            this.Hair01 = Hair01;
            this.Hair02 = Hair02;
            this.Hair03 = Hair03;
            this.Hair04 = Hair04;
            this.Hair05 = Hair05;
            this.Hair06 = Hair06;
            this.Hair07 = Hair07;
            this.Hair08 = Hair08;
            this.Hair09 = Hair09;
            this.Hair10 = Hair10;

            this.Shirts01 = Shirts01;
            this.Shirts02 = Shirts02;
            this.Shirts03 = Shirts03;
            this.Shirts04 = Shirts04;
            this.Shirts05 = Shirts05;
            this.Shirts06 = Shirts06;
            this.Shirts07 = Shirts07;
            this.Shirts08 = Shirts08;
            this.Shirts09 = Shirts09;
            this.Shirts10 = Shirts10;

            this.Pants01 = Pants01;
            this.Pants02 = Pants02;
            this.Pants03 = Pants03;
            this.Pants04 = Pants04;
            this.Pants05 = Pants05;
            this.Pants06 = Pants06;
            this.Pants07 = Pants07;
            this.Pants08 = Pants08;
            this.Pants09 = Pants09;
            this.Pants10 = Pants10;

            this.Pet01 = Pet01;
            this.Pet02 = Pet02;
            this.Pet03 = Pet03;
            this.Pet04 = Pet04;
            this.Pet05 = Pet05;
            this.Pet06 = Pet06;
            this.Pet07 = Pet07;
            this.Pet08 = Pet08;
            this.Pet09 = Pet09;
            this.Pet10 = Pet10;

            this.money = money;
        }




    public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["UserID"] = this.UserID;
            dic["email"] = this.email;
            dic["password"] = this.password;
            dic["name"] = this.name;
            dic["dept"] = this.dept;
            dic["stdID"] = this.stdID;
            dic["OT0"] = this.OT0;
            dic["OT1"] = this.OT1;
            dic["OT2"] = this.OT2;
            dic["OT3"] = this.OT3;
            dic["OT4"] = this.OT4;
            dic["OT5"] = this.OT5;
            dic["D1"] = this.D1;
            dic["D2"] = this.D2;
            dic["D3"] = this.D3;
            dic["D4"] = this.D4;
            dic["D5"] = this.D5;
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
            dic["Hair01"] = this.Hair01;
            dic["Hair02"] = this.Hair02;
            dic["Hair03"] = this.Hair03;
            dic["Hair04"] = this.Hair04;
            dic["Hair05"] = this.Hair05;
            dic["Hair06"] = this.Hair06;
            dic["Hair07"] = this.Hair07;
            dic["Hair08"] = this.Hair08;
            dic["Hair09"] = this.Hair09;
            dic["Hair10"] = this.Hair10;
            dic["Shirts01"] = this.Shirts01;
            dic["Shirts02"] = this.Shirts02;
            dic["Shirts03"] = this.Shirts03;
            dic["Shirts04"] = this.Shirts04;
            dic["Shirts05"] = this.Shirts05;
            dic["Shirts06"] = this.Shirts06;
            dic["Shirts07"] = this.Shirts07;
            dic["Shirts08"] = this.Shirts08;
            dic["Shirts09"] = this.Shirts09;
            dic["Shirts10"] = this.Shirts10;
            dic["Pants01"] = this.Pants01;
            dic["Pants02"] = this.Pants02;
            dic["Pants03"] = this.Pants03;
            dic["Pants04"] = this.Pants04;
            dic["Pants05"] = this.Pants05;
            dic["Pants06"] = this.Pants06;
            dic["Pants07"] = this.Pants07;
            dic["Pants08"] = this.Pants08;
            dic["Pants09"] = this.Pants09;
            dic["Pants10"] = this.Pants10;
            dic["Pet01"] = this.Pet01;
            dic["Pet02"] = this.Pet02;
            dic["Pet03"] = this.Pet03;
            dic["Pet04"] = this.Pet04;
            dic["Pet05"] = this.Pet05;
            dic["Pet06"] = this.Pet06;
            dic["Pet07"] = this.Pet07;
            dic["Pet08"] = this.Pet08;
            dic["Pet09"] = this.Pet09;
            dic["Pet10"] = this.Pet10;
            dic["money"] = this.money;
        
            return dic;
        }
    }






}
