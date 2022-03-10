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

    //hair color
    public string hc01 = "false";
    public string hc02 = "false";
    public string hc03 = "false";
    public string hc04 = "false";
    public string hc05 = "false";
    public string hc06 = "false";
    public string hc07 = "false";
    public string hc08 = "false";
    public string hc09 = "false";
    public string hc10 = "false";

    //clothes
    public string c01 = "false";
    public string c02 = "false";
    public string c03 = "false";
    public string c04 = "false";
    public string c05 = "false";
    public string c06 = "false";
    public string c07 = "false";
    public string c08 = "false";
    public string c09 = "false";
    public string c10 = "false";

    //pants
    public string p01 = "false";
    public string p02 = "false";
    public string p03 = "false";
    public string p04 = "false";
    public string p05 = "false";
    public string p06 = "false";
    public string p07 = "false";
    public string p08 = "false";
    public string p09 = "false";
    public string p10 = "false";

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

                money = dataSnapshot.Child("money").GetValue(true).ToString();

                hc01 = dataSnapshot.Child("HC01").GetValue(true).ToString();
                hc02 = dataSnapshot.Child("HC02").GetValue(true).ToString();
                hc03 = dataSnapshot.Child("HC03").GetValue(true).ToString();
                hc04 = dataSnapshot.Child("HC04").GetValue(true).ToString();
                hc05 = dataSnapshot.Child("HC05").GetValue(true).ToString();
                hc06 = dataSnapshot.Child("HC06").GetValue(true).ToString();
                hc07 = dataSnapshot.Child("HC07").GetValue(true).ToString();
                hc08 = dataSnapshot.Child("HC08").GetValue(true).ToString();
                hc09 = dataSnapshot.Child("HC09").GetValue(true).ToString();
                hc10 = dataSnapshot.Child("HC10").GetValue(true).ToString();
                Debug.Log("hc " + hc01 + " " + hc02 + " " + hc03 + " " + hc04 + " " + hc05 + " " + hc06 + " " + hc07 + " " + hc08 + " " + hc09 + " " + hc10);
                
                c01 = dataSnapshot.Child("C01").GetValue(true).ToString();
                c02 = dataSnapshot.Child("C02").GetValue(true).ToString();
                c03 = dataSnapshot.Child("C03").GetValue(true).ToString();
                c04 = dataSnapshot.Child("C04").GetValue(true).ToString();
                c05 = dataSnapshot.Child("C05").GetValue(true).ToString();
                c06 = dataSnapshot.Child("C06").GetValue(true).ToString();
                c07 = dataSnapshot.Child("C07").GetValue(true).ToString();
                c08 = dataSnapshot.Child("C08").GetValue(true).ToString();
                c09 = dataSnapshot.Child("C09").GetValue(true).ToString();
                c10 = dataSnapshot.Child("C10").GetValue(true).ToString();

                p01 = dataSnapshot.Child("P01").GetValue(true).ToString();
                p02 = dataSnapshot.Child("P02").GetValue(true).ToString();
                p03 = dataSnapshot.Child("P03").GetValue(true).ToString();
                p04 = dataSnapshot.Child("P04").GetValue(true).ToString();
                p05 = dataSnapshot.Child("P05").GetValue(true).ToString();
                p06 = dataSnapshot.Child("P06").GetValue(true).ToString();
                p07 = dataSnapshot.Child("P07").GetValue(true).ToString();
                p08 = dataSnapshot.Child("P08").GetValue(true).ToString();
                p09 = dataSnapshot.Child("P09").GetValue(true).ToString();
                p10 = dataSnapshot.Child("P10").GetValue(true).ToString();

                pet01 = dataSnapshot.Child("PET01").GetValue(true).ToString();
                pet02 = dataSnapshot.Child("PET02").GetValue(true).ToString();
                pet03 = dataSnapshot.Child("PET03").GetValue(true).ToString();
                pet04 = dataSnapshot.Child("PET04").GetValue(true).ToString();
                pet05 = dataSnapshot.Child("PET05").GetValue(true).ToString();
                pet06 = dataSnapshot.Child("PET06").GetValue(true).ToString();
                pet07 = dataSnapshot.Child("PET07").GetValue(true).ToString();
                pet08 = dataSnapshot.Child("PET08").GetValue(true).ToString();
                pet09 = dataSnapshot.Child("PET09").GetValue(true).ToString();
                pet10 = dataSnapshot.Child("PET10").GetValue(true).ToString();

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


        public bool HC01;
        public bool HC02;
        public bool HC03;
        public bool HC04;
        public bool HC05;
        public bool HC06;
        public bool HC07;
        public bool HC08;
        public bool HC09;
        public bool HC10;
        //머리색

        public bool C01;
        public bool C02;
        public bool C03;
        public bool C04;
        public bool C05;
        public bool C06;
        public bool C07;
        public bool C08;
        public bool C09;
        public bool C10;
        //상의

        public bool P01;
        public bool P02;
        public bool P03;
        public bool P04;
        public bool P05;
        public bool P06;
        public bool P07;
        public bool P08;
        public bool P09;
        public bool P10;
        //하의

        public bool PET01;
        public bool PET02;
        public bool PET03;
        public bool PET04;
        public bool PET05;
        public bool PET06;
        public bool PET07;
        public bool PET08;
        public bool PET09;
        public bool PET10;
        //펫

        public string money;


        
        public JoinDB(string UserID, string email, string password, string name, string dept, string stdID,
            bool OT0, bool OT1, bool OT2, bool OT3, bool OT4, bool OT5, 
            bool D1, bool D2, bool D3, bool D4, bool D5,
            bool M1, bool M2, bool M3, bool M4, bool M5,
            bool H1, bool H2, bool H3, bool H4, bool H5, 
            bool HC01, bool HC02, bool HC03, bool HC04, bool HC05, bool HC06, bool HC07, bool HC08, bool HC09, bool HC10,
            bool C01, bool C02, bool C03, bool C04, bool C05, bool C06, bool C07, bool C08, bool C09, bool C10,
            bool P01, bool P02, bool P03, bool P04, bool P05, bool P06, bool P07, bool P08, bool P09, bool P10,
            bool PET01, bool PET02, bool PET03, bool PET04, bool PET05, bool PET06, bool PET07, bool PET08, bool PET09, bool PET10, string money) 
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


            this.HC01 = HC01;
            this.HC02 = HC02;
            this.HC03 = HC03;
            this.HC04 = HC04;
            this.HC05 = HC05;
            this.HC06 = HC06;
            this.HC07 = HC07;
            this.HC08 = HC08;
            this.HC09 = HC09;
            this.HC10 = HC10;

            this.C01 = C01;
            this.C02 = C02;
            this.C03 = C03;
            this.C04 = C04;
            this.C05 = C05;
            this.C06 = C06;
            this.C07 = C07;
            this.C08 = C08;
            this.C09 = C09;
            this.C10 = C10;

            this.P01 = P01;
            this.P02 = P02;
            this.P03 = P03;
            this.P04 = P04;
            this.P05 = P05;
            this.P06 = P06;
            this.P07 = P07;
            this.P08 = P08;
            this.P09 = P09;
            this.P10 = P10;

            this.PET01 = PET01;
            this.PET02 = PET02;
            this.PET03 = PET03;
            this.PET04 = PET04;
            this.PET05 = PET05;
            this.PET06 = PET06;
            this.PET07 = PET07;
            this.PET08 = PET08;
            this.PET09 = PET09;
            this.PET10 = PET10;

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
            dic["HC01"] = this.HC01;
            dic["HC02"] = this.HC02;
            dic["HC03"] = this.HC03;
            dic["HC04"] = this.HC04;
            dic["HC05"] = this.HC05;
            dic["HC06"] = this.HC06;
            dic["HC07"] = this.HC07;
            dic["HC08"] = this.HC08;
            dic["HC09"] = this.HC09;
            dic["HC10"] = this.HC10;
            dic["C01"] = this.C01;
            dic["C02"] = this.C02;
            dic["C03"] = this.C03;
            dic["C04"] = this.C04;
            dic["C05"] = this.C05;
            dic["C06"] = this.C06;
            dic["C07"] = this.C07;
            dic["C08"] = this.C08;
            dic["C09"] = this.C09;
            dic["C10"] = this.C10;
            dic["P01"] = this.P01;
            dic["P02"] = this.P02;
            dic["P03"] = this.P03;
            dic["P04"] = this.P04;
            dic["P05"] = this.P05;
            dic["P06"] = this.P06;
            dic["P07"] = this.P07;
            dic["P08"] = this.P08;
            dic["P09"] = this.P09;
            dic["P10"] = this.P10;
            dic["PET01"] = this.PET01;
            dic["PET02"] = this.PET02;
            dic["PET03"] = this.PET03;
            dic["PET04"] = this.PET04;
            dic["PET05"] = this.PET05;
            dic["PET06"] = this.PET06;
            dic["PET07"] = this.PET07;
            dic["PET08"] = this.PET08;
            dic["PET09"] = this.PET09;
            dic["PET10"] = this.PET10;
            dic["money"] = this.money;
        
            return dic;
        }
    }






}
