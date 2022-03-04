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
    public Text verText;
    
    public DatabaseReference reference = null;
    public Button NextButton;

    public DataSnapshot ds;
    public noticeSaver ns;
    string CurrentVersion = "1.4"; // OT Version
    string ServerVersion;
    // Start is called before the first frame update

    

    void Start()
    {
        FirebaseApp.DefaultInstance.Options.DatabaseUrl =
                   new System.Uri("https://hsuon-4c8e4-default-rtdb.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.GetReference("info");

        verText.text = "ver " + Application.version;

        
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
                ServerVersion = dataSnapshot.Child("ServerVersion").GetValue(true).ToString();
                ds = dataSnapshot;
                Debug.Log(ServerVersion);

            }
        });
    }
    // Update is called once per frame
    void Update()
    {
        
        if (ServerVersion == null)
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
        else if (ServerVersion == "점검중")
        {
            text.text = "서버 점검중입니다. \n\n\n";
            GetServerVersionFromFireBase();
        }
        else
        {
            text.text = "업데이트가 필요합니다. 스토어에서 업데이트를 해주세요\n 현재버전: " + CurrentVersion + "\n 최신버전 :" + ServerVersion + "\n\n";
        }




    }
}
