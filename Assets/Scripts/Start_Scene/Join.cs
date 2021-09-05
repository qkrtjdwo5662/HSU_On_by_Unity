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


public class Join : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";

    public Text connectionInfoText;

    public Button LoginBtn;

    Queue<string> queue = new Queue<string>();



    [SerializeField] string email;
    [SerializeField] string password;
    [SerializeField] string name;
    [SerializeField] string dept;
    [SerializeField] string stdID;

    public InputField inputTextEmail;
    public InputField inputTextPassword;
    public InputField inputTextEmail2;
    public InputField inputTextPassword2;
    public InputField inputName;
    public InputField inputStdId;
    public InputField inputDept;

    public Text joinResult;
    public Text loginResult;

    JoinDB user;

    FirebaseAuth auth;


    private void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://dbexample-b0dc2-default-rtdb.firebaseio.com/");

        // 파이어베이스의 메인 참조 얻기
        reference = FirebaseDatabase.DefaultInstance.RootReference;


        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.GameVersion = gameVersion;

        PhotonNetwork.ConnectUsingSettings();

        LoginBtn.interactable = false;
        LoginBtn.onClick.AddListener(Connect);

        connectionInfoText.text = "서버에 접속중..";

   
    }
    //마스터 서버 접속 성공시
    public override void OnConnectedToMaster()
    {
        LoginBtn.interactable = true;

        connectionInfoText.text = "온라인 : 마스터 서버와 연결완료";

        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
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

    
    //마스터 서버 접속 실패시
    public override void OnDisconnected(DisconnectCause cause)
    {
        // 룸 접속 버튼을 비활성화
        LoginBtn.interactable = false;

        //접속 정보 표시
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도중...";
        //마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedLobby()//로비에 연결시 작동
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000).ToString("0000");
        //들어온사람 이름 랜덤으로 숫자붙여서 정해주기
    }

    //룸 접속 시도
    public void Connect()
    {
        LoginBtn.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "룸에 접속..";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도중...";
            //마스터 서버로의 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "로그인 성공, 새로운 방 생성중..";


        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });

    }

    public override void OnJoinedRoom()
    {
        //접속 상태 표시
        connectionInfoText.text = "로그인 성공, 생성된 방 접속 중...";
        PhotonNetwork.LoadLevel("Scene_Field");
        //LoadingSceneController.Instance.LoadScene("Scene_selcAva");

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
                joinResult.text = "회원가입 실패";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error:" + task.Exception);
                joinResult.text = "회원가입 실패";
                return;
            }


            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0}({1})",
                newUser.DisplayName, newUser.UserId);
            joinResult.text = "회원가입 성공";
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
            loginResult.text = "로그인 성공";

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
