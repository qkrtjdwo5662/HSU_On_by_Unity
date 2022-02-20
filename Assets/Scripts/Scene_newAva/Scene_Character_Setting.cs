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
    public Texture HC01, HC11, HC21, HC31, HC41, HC51, HC61;
    public Texture HC02, HC12, HC22, HC32, HC42, HC52, HC62;
    public Texture HC03, HC13, HC23, HC33, HC43, HC53, HC63;
    public Texture HC04, HC14, HC24, HC34, HC44, HC54, HC64;
    public Texture HC05, HC15, HC25, HC35, HC45, HC55, HC65;
    public Texture HC06, HC16, HC26, HC36, HC46, HC56, HC66;
    public Texture HC07, HC17, HC27, HC37, HC47, HC57, HC67;
    public Texture HC08, HC18, HC28, HC38, HC48, HC58, HC68;
    public Texture HC09, HC19, HC29, HC39, HC49, HC59, HC69;
    public Texture HC10, HC20, HC30, HC40, HC50, HC60, HC70;
    // 머리색 끝
    
    // 상의 
    public Texture C01, C11, C21, C31, C41, C51, C61;
    public Texture C02, C12, C22, C32, C42, C52, C62;
    public Texture C03, C13, C23, C33, C43, C53, C63;
    public Texture C04, C14, C24, C34, C44, C54, C64;
    public Texture C05, C15, C25, C35, C45, C55, C65;
    public Texture C06, C16, C26, C36, C46, C56, C66;
    public Texture C07, C17, C27, C37, C47, C57, C67;
    public Texture C08, C18, C28, C38, C48, C58, C68;
    public Texture C09, C19, C29, C39, C49, C59, C69;
    public Texture C10, C20, C30, C40, C50, C60, C70;
    // 상의 끝

    // 하의
    public Texture P01, P11, P21, P31, P41, P51, P61;
    public Texture P02, P12, P22, P32, P42, P52, P62;
    public Texture P03, P13, P23, P33, P43, P53, P63;
    public Texture P04, P14, P24, P34, P44, P54, P64;
    public Texture P05, P15, P25, P35, P45, P55, P65;
    public Texture P06, P16, P26, P36, P46, P56, P66;
    public Texture P07, P17, P27, P37, P47, P57, P67;
    public Texture P08, P18, P28, P38, P48, P58, P68;
    public Texture P09, P19, P29, P39, P49, P59, P69;
    public Texture P10, P20, P30, P40, P50, P60, P70;
    // 하의 끝

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
    
    public void CBtn()
    {
        btnC01.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C01);
                    clothes = "C01";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C11);
                    clothes = "C11";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C21);
                    clothes = "C21";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C31);
                    clothes = "C31";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C41);
                    clothes = "C41";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C51);
                    clothes = "C51";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C61);
                    clothes = "C61";
                    break;
            }
        });
        btnC02.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
                    clothes = "C02";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C12);
                    clothes = "C12";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C22);
                    clothes = "C22";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C32);
                    clothes = "C32";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C42);
                    clothes = "C42";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C52);
                    clothes = "C52";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C62);
                    clothes = "C62";
                    break;
            }
        });
        btnC03.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C03);
                    clothes = "C03";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C13);
                    clothes = "C13";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C23);
                    clothes = "C23";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C33);
                    clothes = "C33";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C43);
                    clothes = "C43";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C53);
                    clothes = "C53";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C63);
                    clothes = "C63";
                    break;
            }
        });
        btnC04.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C04);
                    clothes = "C04";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C14);
                    clothes = "C14";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C24);
                    clothes = "C24";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C34);
                    clothes = "C34";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C44);
                    clothes = "C44";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C54);
                    clothes = "C54";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C64);
                    clothes = "C64";
                    break;
            }
        });
        btnC05.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C05);
                    clothes = "C05";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C15);
                    clothes = "C15";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C25);
                    clothes = "C25";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C35);
                    clothes = "C35";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C45);
                    clothes = "C45";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C55);
                    clothes = "C55";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C65);
                    clothes = "C65";
                    break;
            }
        });
        btnC06.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C06);
                    clothes = "C06";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C16);
                    clothes = "C16";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C26);
                    clothes = "C26";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C36);
                    clothes = "C36";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C46);
                    clothes = "C46";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C56);
                    clothes = "C56";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C66);
                    clothes = "C66";
                    break;
            }
        });
        btnC07.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C07);
                    clothes = "C07";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C17);
                    clothes = "C17";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C27);
                    clothes = "C27";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C37);
                    clothes = "C37";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C47);
                    clothes = "C47";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C57);
                    clothes = "C57";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C67);
                    clothes = "C67";
                    break;
            }
        });
        btnC08.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C08);
                    clothes = "C08";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C18);
                    clothes = "C18";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C28);
                    clothes = "C28";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C38);
                    clothes = "C38";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C48);
                    clothes = "C48";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C58);
                    clothes = "C58";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C68);
                    clothes = "C68";
                    break;
            }
        });
        btnC01.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C09);
                    clothes = "C09";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C19);
                    clothes = "C19";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C29);
                    clothes = "C29";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C39);
                    clothes = "C39";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C49);
                    clothes = "C49";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C59);
                    clothes = "C59";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C69);
                    clothes = "C69";
                    break;
            }
        });
        btnC10.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C10);
                    clothes = "C10";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C20);
                    clothes = "C20";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C30);
                    clothes = "C30";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C40);
                    clothes = "C40";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C50);
                    clothes = "C50";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C60);
                    clothes = "C60";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C70);
                    clothes = "C70";
                    break;
            }
        });
    }
    public void BBtn()
    {
        btnP01.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P01);
                    pants = "P01";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P11);
                    pants = "P11";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P21);
                    pants = "P21";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P31);
                    pants = "P31";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P41);
                    pants = "P41";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P51);
                    pants = "P51";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P61);
                    pants = "P61";
                    break;
            }
        });
        btnP02.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P02);
                    pants = "P02";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P12);
                    pants = "P12";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P22);
                    pants = "P22";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P32);
                    pants = "P32";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P42);
                    pants = "P42";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P52);
                    pants = "P52";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P62);
                    pants = "P62";
                    break;
            }
        });
        btnP03.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P03);
                    pants = "P03";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P13);
                    pants = "P13";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P23);
                    pants = "P23";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P33);
                    pants = "P33";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P43);
                    pants = "P43";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P53);
                    pants = "P53";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P63);
                    pants = "P63";
                    break;
            }
        });
        btnP04.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P04);
                    pants = "P04";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P14);
                    pants = "P14";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P24);
                    pants = "P24";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P34);
                    pants = "P34";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P44);
                    pants = "P44";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P54);
                    pants = "P54";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P64);
                    pants = "P64";
                    break;
            }
        }); 
        btnP05.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P05);
                    pants = "P05";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P15);
                    pants = "P15";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P25);
                    pants = "P25";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P35);
                    pants = "P35";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P45);
                    pants = "P45";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P55);
                    pants = "P55";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P65);
                    pants = "P65";
                    break;
            }
        });
        btnP06.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P06);
                    pants = "P06";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P16);
                    pants = "P16";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P26);
                    pants = "P26";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P36);
                    pants = "P36";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P46);
                    pants = "P46";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P56);
                    pants = "P56";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P66);
                    pants = "P66";
                    break;
            }
        }); 
        btnP07.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P07);
                    pants = "P07";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P17);
                    pants = "P17";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P27);
                    pants = "P27";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P37);
                    pants = "P37";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P47);
                    pants = "P47";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P57);
                    pants = "P57";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P67);
                    pants = "P67";
                    break;
            }
        });
        btnP08.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P08);
                    pants = "P08";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P18);
                    pants = "P18";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P28);
                    pants = "P28";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P38);
                    pants = "P38";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P48);
                    pants = "P48";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P58);
                    pants = "P58";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P68);
                    pants = "P68";
                    break;
            }
        }); 
        btnP09.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P09);
                    pants = "P09";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P19);
                    pants = "P19";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P29);
                    pants = "P29";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P39);
                    pants = "P39";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P49);
                    pants = "P49";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P59);
                    pants = "P59";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P69);
                    pants = "P69";
                    break;
            }
        });
        btnP10.onClick.AddListener(() => {
            switch (model)
            {
                case "F1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P10);
                    pants = "P10";
                    break;
                case "F3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P20);
                    pants = "P20";
                    break;
                case "F4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P30);
                    pants = "P30";
                    break;
                case "M1":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P40);
                    pants = "P40";
                    break;
                case "M2":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P50);
                    pants = "P50";
                    break;
                case "M3":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P60);
                    pants = "P60";
                    break;
                case "M4":
                    CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P70);
                    pants = "P70";
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
