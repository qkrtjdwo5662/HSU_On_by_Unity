using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene_newCharacter_Setting : MonoBehaviour
{

    public int WhatSelected = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    Text NickName;
    public GameObject TMP;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        NickName = GameObject.Find("NickName").GetComponent<Text>();
        TMP.GetComponent<TextMeshPro>().text = NickName.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
