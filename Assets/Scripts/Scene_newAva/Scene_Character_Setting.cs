using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Character_Setting : MonoBehaviour
{
    public int WhatSelected = 0;

    [SerializeField]
    private string model = "";
    [SerializeField]
    private string hair = "";
    [SerializeField]
    private string clothes = "";
    [SerializeField]
    private string pants = "";
    [SerializeField]
    private string pet = null;

    public string getModel()
    {
        return this.model;
    }






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
    public Texture C01, C02, C03, C04, C05, C06, C07, C08, C09, C10;

    // 상의 끝

    // 하의
    public Texture P01, P02, P03, P04, P05, P06, P07, P08, P09, P10;

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
        selectAvatar();
        CurrentModel = null;
    }

    public void HCbtn()
    {
        btnHC01.onClick.AddListener(() =>
        {
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
        btnHC03.onClick.AddListener(() =>
        {
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
        btnHC06.onClick.AddListener(() =>
        {
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
        btnHC08.onClick.AddListener(() =>
        {
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
        btnC01.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC02.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC03.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC04.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC05.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC06.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC07.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC08.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC09.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnC10.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
    }
    public void BBtn()
    {
        btnP01.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP02.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP03.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP04.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP05.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP06.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP07.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP08.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP09.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
        btnP10.onClick.AddListener(() =>
        {
            CurrentModel.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C02);
        });
    }
    public void selectAvatar()
    {
        btnF1.onClick.AddListener(() =>
        {
            F1.SetActive(true);
            F3.SetActive(false);
            F4.SetActive(false);
            M1.SetActive(false);
            M2.SetActive(false);
            M3.SetActive(false);
            M4.SetActive(false);
            CurrentModel = F1;
            model = "F1";
        });
        btnF3.onClick.AddListener(() =>
        {
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
        btnF4.onClick.AddListener(() =>
        {
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
        btnM1.onClick.AddListener(() =>
        {
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
        btnM2.onClick.AddListener(() =>
        {
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
        btnM3.onClick.AddListener(() =>
        {
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
        btnM4.onClick.AddListener(() =>
        {
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
}
