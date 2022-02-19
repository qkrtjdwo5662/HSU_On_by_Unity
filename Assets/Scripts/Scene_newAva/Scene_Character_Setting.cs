using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Character_Setting : MonoBehaviour
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

    //F1 머리색 1~10 | F3 11~20 | F4 21~30 | M1 31~40 | M2 41~50 | M3 51~60 | M4 61~70
    public Texture HC01;
    public Texture HC02;
    public Texture HC03;
    public Texture HC04;
    public Texture HC05;
    public Texture HC06;
    public Texture HC07;
    public Texture HC08;
    public Texture HC09;
    public Texture HC10;
    public Texture HC11;
    public Texture HC12;
    public Texture HC13;
    public Texture HC14;
    public Texture HC15;
    public Texture HC16;
    public Texture HC17;
    public Texture HC18;
    public Texture HC19;
    public Texture HC20;
    public Texture HC21;
    public Texture HC22;
    public Texture HC23;
    public Texture HC24;
    public Texture HC25;
    public Texture HC26;
    public Texture HC27;
    public Texture HC28;
    public Texture HC29;
    public Texture HC30;
    public Texture HC31;
    public Texture HC32;
    public Texture HC33;
    public Texture HC34;
    public Texture HC35;
    public Texture HC36;
    public Texture HC37;
    public Texture HC38;
    public Texture HC39;
    public Texture HC40;
    public Texture HC41;
    public Texture HC42;
    public Texture HC43;
    public Texture HC44;
    public Texture HC45;
    public Texture HC46;
    public Texture HC47;
    public Texture HC48;
    public Texture HC49;
    public Texture HC50;
    public Texture HC51;
    public Texture HC52;
    public Texture HC53;
    public Texture HC54;
    public Texture HC55;
    public Texture HC56;
    public Texture HC57;
    public Texture HC58;
    public Texture HC59;
    public Texture HC60;
    public Texture HC61;
    public Texture HC62;
    public Texture HC63;
    public Texture HC64;
    public Texture HC65;
    public Texture HC66;
    public Texture HC67;
    public Texture HC68;
    public Texture HC69;
    public Texture HC70;
    // 머리색 끝

    public Texture C01;
    public Texture C02;
    public Texture C03;
    public Texture C04;
    public Texture C05;
    public Texture C06;
    public Texture C07;
    public Texture C08;
    public Texture C09;
    public Texture C10;

    public Texture P01;
    public Texture P02;
    public Texture P03;
    public Texture P04;
    public Texture P05;
    public Texture P06;
    public Texture P07;
    public Texture P08;
    public Texture P09;
    public Texture P10;


    //----------------------------------------Button in Canvas---------------------------------------


    public Button btnF1;
    public Button btnF3;
    public Button btnF4;
    public Button btnM1;
    public Button btnM2;
    public Button btnM3;
    public Button btnM4;

    public Button btnHC01;
    public Button btnHC02;
    public Button btnHC03;
    public Button btnHC04;
    public Button btnHC05;
    public Button btnHC06;
    public Button btnHC07;
    public Button btnHC08;
    public Button btnHC09;
    public Button btnHC10;

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

    public Button btnP01;
    public Button btnP02;
    public Button btnP03;
    public Button btnP04;
    public Button btnP05;
    public Button btnP06;
    public Button btnP07;
    public Button btnP08;
    public Button btnP09;
    public Button btnP10;





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
        /*
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
        });*/

        
        btnC01.onClick.AddListener( ()=> {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C01);
            clothes = "C01";
        });
        btnC02.onClick.AddListener(() => {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
            clothes = "C02";
        });
    }

    public void HCbtn()
    {
        btnHC01.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC01);
                    hair = "HC01";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC11);
                    hair = "HC11";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC21);
                    hair = "HC21";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC31);
                    hair = "HC31";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC41);
                    hair = "HC41";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC51);
                    hair = "HC51";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC61);
                    hair = "HC61";
                    break;
            }         
        });
        btnHC02.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC02);
                    hair = "HC02";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC12);
                    hair = "HC12";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC22);
                    hair = "HC22";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC32);
                    hair = "HC32";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC42);
                    hair = "HC42";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC52);
                    hair = "HC52";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC62);
                    hair = "HC62";
                    break;
            }
        });
        btnHC03.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC03);
                    hair = "HC03";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC13);
                    hair = "HC13";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC23);
                    hair = "HC23";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC33);
                    hair = "HC33";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC43);
                    hair = "HC43";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC53);
                    hair = "HC53";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC63);
                    hair = "HC63";
                    break;
            }
        });
        btnHC04.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC04);
                    hair = "HC04";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC14);
                    hair = "HC14";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC24);
                    hair = "HC24";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC34);
                    hair = "HC34";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC44);
                    hair = "HC44";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC54);
                    hair = "HC54";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC64);
                    hair = "HC64";
                    break;
            }
        });
        btnHC05.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC05);
                    hair = "HC05";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC15);
                    hair = "HC15";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC25);
                    hair = "HC25";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC35);
                    hair = "HC35";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC45);
                    hair = "HC45";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC55);
                    hair = "HC55";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC65);
                    hair = "HC65";
                    break;
            }
        });
        btnHC06.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC06);
                    hair = "HC06";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC16);
                    hair = "HC16";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC26);
                    hair = "HC26";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC36);
                    hair = "HC36";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC46);
                    hair = "HC46";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC56);
                    hair = "HC56";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC66);
                    hair = "HC66";
                    break;
            }
        });
        btnHC07.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC07);
                    hair = "HC07";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC17);
                    hair = "HC17";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC27);
                    hair = "HC27";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC37);
                    hair = "HC37";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC47);
                    hair = "HC47";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC57);
                    hair = "HC57";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC67);
                    hair = "HC67";
                    break;
            }
        });
        btnHC08.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC08);
                    hair = "HC08";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC18);
                    hair = "HC18";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC28);
                    hair = "HC28";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC38);
                    hair = "HC38";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC48);
                    hair = "HC48";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC58);
                    hair = "HC58";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC68);
                    hair = "HC68";
                    break;
            }
        });
        btnHC09.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC09);
                    hair = "HC09";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC19);
                    hair = "HC19";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC29);
                    hair = "HC29";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC39);
                    hair = "HC39";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC49);
                    hair = "HC49";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC59);
                    hair = "HC59";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC69);
                    hair = "HC69";
                    break;
            }
        });
        btnHC10.onClick.AddListener(() =>
        {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC10);
                    hair = "HC10";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC20);
                    hair = "HC20";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC30);
                    hair = "HC30";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC40);
                    hair = "HC40";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC50);
                    hair = "HC50";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC60);
                    hair = "HC60";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC70);
                    hair = "HC70";
                    break;
            }
        });
    }

    public void selectAvatar()
    {
        btnF1.onClick.AddListener(() => {
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
    }
    // Update is called once per frame
    void Update()
    {

    }
}
