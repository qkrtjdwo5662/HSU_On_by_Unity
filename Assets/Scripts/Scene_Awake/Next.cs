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

    string CurrentVersion = "1.4"; // OT Version
    string ServerVersion;
    // Start is called before the first frame update

    

    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.GetReference("info");

        
        
        NextButton.onClick.AddListener(ButtonClick);
    }


    void GetServerVersionFromFireBase()
    {
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
    }
    // Update is called once per frame
    void Update()
    {
        
        if (ServerVersion == null || ServerVersion =="1.2" || ServerVersion == "1.3")
        {
            text.text = "서버 정보를 불러오는 중입니다\n\n\n\n";
            GetServerVersionFromFireBase();
        }
        else 
        {
            text.text = "터치하여 시작하세요\n\n\n\n";
        }
    }

    void ButtonClick() 
    {
        
        
        if (ServerVersion == CurrentVersion)
        {
            LoadingSceneController.Instance.LoadScene("Scene_Login");
        }
        else
        {
            text.text = "업데이트가 필요합니다. 스토어에서 업데이트를 해주세요\n 현재버전: " + CurrentVersion + "\n 최신버전 :" + ServerVersion + "\n\n";
        }

        
        
        
    }
}
