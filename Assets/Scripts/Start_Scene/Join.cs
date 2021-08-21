using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Firebase.Auth;

using Firebase;
using Firebase.Database;

public class Join : MonoBehaviour 
{
    Queue<string> queue = new Queue<string>();


    [SerializeField] string email;
    [SerializeField] string password;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public Text loginResult;


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

            loginResult.text = "회원가입 성공";

        });

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
        public string name;
        public string dept;
        public int stdID;

        public JoinDB(string name,string dept,int stdID)
        {
            this.name = name;
            this.dept = dept;
            this.stdID = stdID;
        }

        public Dictionary<string,object> ToDictionary()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["name"] = this.name;
            dic["dept"] = this.dept;
            dic["stdID"] = this.stdID;
            return dic;
        }
    }

    private DatabaseReference reference = null;

 


}
