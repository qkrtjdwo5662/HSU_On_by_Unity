using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if(gm.userType == "1")
        {
            Debug.Log("교수 로그인");
        }else if(gm.userType == "2")
        {
            Debug.Log("조교 로그인");
        }
        else
        {
            Debug.Log("학생 로그인");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
