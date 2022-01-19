using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene_newCharacter_Setting : MonoBehaviour
{
    public int WhatSelected = 0;
    public GameObject TMP;
    Join join;
    string NickName;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        join = GameObject.Find("Join").GetComponent<Join>();
        NickName = join.getStdId().Substring(0, 2) + " " + join.getName();
        TMP.GetComponent<TextMeshPro>().text = NickName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
