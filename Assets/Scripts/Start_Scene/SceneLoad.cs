using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneLoad : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //LoadingSceneController.Instance.LoadScene("Scene2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartOption(string arg)
    {
        GameObject gm = GameObject.FindWithTag("GameManager");

        if(arg == "1")
        {
            gm.GetComponent<GameManager>().userType = "1";
        }
        else if(arg == "2")
        {
            gm.GetComponent<GameManager>().userType = "2";
        }
        else
        {
            gm.GetComponent<GameManager>().userType = "3";
        }

        LoadingSceneController.Instance.LoadScene("Scene2");
    }
}
