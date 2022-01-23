using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Firebase.Auth;

using Firebase;
using Firebase.Database;
using System;

using Photon.Pun;
using Photon.Realtime;
using Firebase.Extensions;

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
    [SerializeField] string name;
    [SerializeField] string dept;
    [SerializeField] string stdID;

    [SerializeField] bool OT0 = false;
    [SerializeField] bool OT1 = false;
    [SerializeField] bool OT2 = false;
    [SerializeField] bool OT3 = false;
    [SerializeField] bool OT4 = false;
    [SerializeField] bool OT5 = false;

    [SerializeField] bool D1 = false;
    [SerializeField] bool D2 = false;
    [SerializeField] bool D3 = false;
    [SerializeField] bool D4 = false;
    [SerializeField] bool D5 = false;

    [SerializeField] bool M1 = false;
    [SerializeField] bool M2 = false;
    [SerializeField] bool M3 = false;
    [SerializeField] bool M4 = false;
    [SerializeField] bool M5 = false;

    [SerializeField] bool H1 = false;
    [SerializeField] bool H2 = false;
    [SerializeField] bool H3 = false;
    [SerializeField] bool H4 = false;
    [SerializeField] bool H5 = false;

    [SerializeField ]string UserID;

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

    public string getUserID() {
        return UserID;
    }
    
    public string getName() {
        return name;
    }
    public string getStdId() {
        return stdID;
    }

    JoinDB user;

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
        if(queue.Count > 0)
        {
            Invoke(queue.Dequeue(), 0.1f);
        }
    }

    

    //버튼이 눌리면 실행할 함수.
    public void JoinBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;
        name = inputName.text;
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
                user = new JoinDB(UserID, email, password, name, dept, stdID,OT0,OT1,OT2, OT3, OT4, OT5, D1, D2, D3, D4, D5, M1, M2, M3, M4, M5, H1, H2, H3, H4, H5);
                CreateUserWithJson(UserID, new JoinDB(UserID, email, password, name, dept, stdID,OT0, OT1, OT2, OT3, OT4, OT5, D1, D2, D3, D4, D5, M1, M2, M3, M4, M5, H1, H2, H3, H4, H5));
                joinFlag = true;
                queue.Enqueue("JoinNext");
                return;
            }
          
        });
    }
    void GetUserInformationFromFireBase() {
        reference = FirebaseDatabase.DefaultInstance.GetReference("users").Child(UserID);

        reference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot dataSnapshot = task.Result;

                name = dataSnapshot.Child("name").GetValue(true).ToString();

                Debug.Log(name);
                stdID = dataSnapshot.Child("stdID").GetValue(true).ToString();

                Debug.Log(stdID);





                return;
            }
        });
    }

    public void  CreateUserWithJson(string _userID, JoinDB _userInfo)
    {

        string data = JsonUtility.ToJson(_userInfo);
        Debug.Log(data);
        reference.Child("users").Child(_userInfo.UserID).SetRawJsonValueAsync(data);

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
                return;
            }


        });//

    }

        public  void LoginNext()
    {
        
        if (loginFlag)
        {
            loginResult.text = "로그인 성공";
            GetUserInformationFromFireBase();
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

    public class JoinDB
    {
        public string UserID;
        public string email;
        public string password;
        public string name;
        public string dept;
        public string stdID;

        public bool OT0;
        public bool OT1;
        public bool OT2;
        public bool OT3;
        public bool OT4;
        public bool OT5;

        public bool D1;
        public bool D2;
        public bool D3;
        public bool D4;
        public bool D5;

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

        public JoinDB(string UserID, string email, string password, string name, string dept, string stdID, 
            bool OT0, bool OT1, bool OT2, bool OT3, bool OT4, bool OT5, bool D1, bool D2, bool D3, bool D4, bool D5, bool M1, bool M2, bool M3, bool M4, bool M5, bool H1, bool H2, bool H3, bool H4, bool H5)
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
        }

        public Dictionary<string,object> ToDictionary()
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

            return dic;
        }
    }

    public DatabaseReference reference = null;

 


}
