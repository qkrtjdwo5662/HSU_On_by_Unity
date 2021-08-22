using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Firebase.Auth;

using Firebase;
using Firebase.Database;
using System;

public class Join : MonoBehaviour 
{
    Queue<string> queue = new Queue<string>();


    [SerializeField] string email;
    [SerializeField] string password;
    [SerializeField] string name;
    [SerializeField] string dept;
    [SerializeField] string stdID;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public InputField inputName;
    public InputField inputStdId;
    public InputField inputDept;

    public Text loginResult;

    JoinDB user;

    FirebaseAuth auth;


    private void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://dbexample-b0dc2-default-rtdb.firebaseio.com/");

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
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was cnaceled.");
                loginResult.text = "회원가입 실패";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                loginResult.text = "회원가입 실패";
                return;
            }


            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0}({1})",
                newUser.DisplayName, newUser.UserId);
            Debug.Log("회원가입 성공");
            user = new JoinDB(email, password, name, dept, stdID);

        
   
            CreateUserWithJson(stdID, new JoinDB(email,password,name,dept,stdID));
          
        });

    }


    public void  CreateUserWithJson(string _userID, JoinDB _userInfo)
    {
        
        string data = JsonUtility.ToJson(_userInfo);
        Debug.Log(data);
        reference.Child("users").Child(_userInfo.stdID).SetRawJsonValueAsync(data);
        
    }

    public void LoginBtnOnClick()
    {
        email = inputTextEmail.text;
        password = inputTextPassword.text;

        Debug.Log("email:" + email + ",password:" + password);

        LoginUser();
    }

    void LoginUser()
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was cnaceled.");
                loginResult.text = "로그인 실패";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                loginResult.text = "로그인 실패";
                return;
            }
           
            Firebase.Auth.FirebaseUser newUser = task.Result;

            Debug.LogFormat("Firebase user created successfully: {0}({1})",
                newUser.DisplayName, newUser.UserId);

            //LoginNext();
            queue.Enqueue("LoginNext");
            //Invoke("LoginNext", 0.1f);
        });
    }

    public  void LoginNext()
    {
        Debug.Log("다음신넘어가라");
        LoadingSceneController.Instance.LoadScene("LobbyScene"); 
    }

    public class JoinDB
    {
        public string email;
        public string password;
        public string name;
        public string dept;
        public string stdID;

        public JoinDB(string email,string password,string name,string dept,string stdID)
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.dept = dept;
            this.stdID = stdID;
        }

        public Dictionary<string,object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["email"] = this.email;
            dic["password"] = this.password;
            dic["name"] = this.name;
            dic["dept"] = this.dept;
            dic["stdID"] = this.stdID;
            return dic;
        }
    }

    public DatabaseReference reference = null;

 


}
