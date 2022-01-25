using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public Text text;
    FirebaseAuth auth;
    DataSnapshot ds;
    FirebaseApp app;
    public DatabaseReference reference = null;
    public Button NextButton;

    string CurrentVersion = "1.2"; // OT Version
    public string ServerVersion = "0.0";
    // Start is called before the first frame update

    

    void Start()
    {
        
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.GetReference("info");

        reference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot dataSnapshot = task.Result;
                ds = dataSnapshot;
                ServerVersion = dataSnapshot.Child("ServerVersion").GetValue(true).ToString();
                Debug.Log(ServerVersion);
               
            }
        });
        
        NextButton.onClick.AddListener(ButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClick() 
    {
        if (ServerVersion == "0.0") 
        {
            text.text = "서버 정보를 불러오는 중입니다. 잠시 후에 다시 시도해주세요\n\n\n\n";
        }
        else if (ServerVersion == CurrentVersion)
        {
            LoadingSceneController.Instance.LoadScene("Scene_Login");
        }
        else
        {
            text.text = "업데이트가 필요합니다. 스토어에서 업데이트를 해주세요.\n 현재버전: " + CurrentVersion + "\n 최신버전 :" + ServerVersion + "\n\n";
        }

        
        
        
    }
}
