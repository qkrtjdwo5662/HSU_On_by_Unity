using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene_newCharacter_Setting : MonoBehaviour
{
    public int WhatSelected = 0;
    
    public string model = "";
    public string hair = "";
    public string clothes = "";
    public string pants = "";
    public string pet = null;
    public GameObject CurrentModel;

    public GameObject F1;
    public GameObject F3;
    public GameObject F4;
    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;


    public Texture C01;
    public Texture C02;



    //----------------------------------------Button in Canvas---------------------------------------

    public Button btnF1;
    public Button btnF3;
    public Button btnF4;
    public Button btnM1;
    public Button btnM2;
    public Button btnM3;
    public Button btnM4;

    public Button btnC01;
    public Button btnC02;
    public Button btnC03;
    public Button btnC04;
    public Button btnC05;
    public Button btnC06;
    public Button btnC07;
    public Button btnC08;
    public Button btnC09;
    public Button btnC10;

    public Button hair_f1_01;

   


    /*
    아이템코드
    

    머리 F101     
    F1 = 모델이름 (M1, M2, M3, M4, F1, F3, F4)
    01 = 머리색 코드
    

    상의 C01
    C = 상의 코드
    01 = 일련번호 (01~99)

    하의 P01
    P = 하의 코드
    01 = 일련번호 (01~99)

    */

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        CurrentModel = F1;
        btnF1.onClick.AddListener(()=>{
            CurrentModel.SetActive(false);
            F1.SetActive(true);
            CurrentModel = F1;
            model = "F1";
        });
        btnF3.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(true);
            F4.SetActive(false);
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            CurrentModel = F3;
            model = "F3";
        });
        btnF4.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(true);
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            CurrentModel = F4;
            model = "F4";
        });
        btnM1.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(false);
            M1.SetActive(true);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            CurrentModel = M1;
            model = "M1";
        });
        btnM2.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(false);
            M1.SetActive(false);
            M2.SetActive(true);
            M3.SetActive(false);
            M4.SetActive(false);
            CurrentModel = M2;
            model = "M2";
        });
        btnM3.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(false);
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(true);
            M4.SetActive(false);
            CurrentModel = M3;
            model = "M3";
        });
        btnM4.onClick.AddListener(() => {
            F1.SetActive(false);
            F3.SetActive(false);
            F4.SetActive(false);
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(true);
            CurrentModel = M4;
            model = "M4";
        });

        
        btnC01.onClick.AddListener( ()=> {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C01);
            clothes = "C01";
        });
        btnC02.onClick.AddListener(() => {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
            clothes = "C02";
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
