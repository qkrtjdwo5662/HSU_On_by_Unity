using Firebase.Database;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class noticeSaver : MonoBehaviour
{
    public string headLine;
    public string notice;
    public string noticeDate;
    public Next n;

    public bool findFlag = false;
    private DataSnapshot ds;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);


    }
    /*  IEnumerator FindN()
      {

          while (true)
          {
              ds = n.ds;
              if (ds != null)
              {
                  headLine = ds.Child("HeadLine").GetValue(true).ToString();
                  notice = ds.Child("Notice").GetValue(true).ToString();
                  noticeDate = ds.Child("NoticeDate").GetValue(true).ToString();
                  break;
              }
              yield return null;
          }
      }*/
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene_Awake")
        {
            try
            {
                if (!findFlag)
                {
                    ds = n.ds;

                    headLine = ds.Child("HeadLine").GetValue(true).ToString();
                    notice = ds.Child("Notice").GetValue(true).ToString();
                    noticeDate = ds.Child("NoticeDate").GetValue(true).ToString();
                }
            }
            catch (Exception e)
            {
                Debug.Log("notice Query is doing");
            }
        }
    }

}
