using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectCharacter : MonoBehaviour
{
    public Scene_newCharacter_Setting scene_NewCharacter_Setting;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public Button button14;

    public GameObject Male1_1;
    public GameObject Male1_2;
    public GameObject Male2_1;
    public GameObject Male2_2;
    public GameObject Male3_1;
    public GameObject Male3_2;
    public GameObject Male4_1;
    public GameObject Male4_2;
    public GameObject Female1_1;
    public GameObject Female1_2;
    public GameObject Female3_1;
    public GameObject Female3_2;
    public GameObject Female4_1;
    public GameObject Female4_2;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(buttonClick1);
        button2.onClick.AddListener(buttonClick2);
        button3.onClick.AddListener(buttonClick3);
        button4.onClick.AddListener(buttonClick4);
        button5.onClick.AddListener(buttonClick5); 
        button6.onClick.AddListener(buttonClick6);
        button7.onClick.AddListener(buttonClick7);
        button8.onClick.AddListener(buttonClick8);
        button9.onClick.AddListener(buttonClick9);
        button10.onClick.AddListener(buttonClick10);
        button11.onClick.AddListener(buttonClick11);
        button12.onClick.AddListener(buttonClick12);
        button13.onClick.AddListener(buttonClick13);
        button14.onClick.AddListener(buttonClick14);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void buttonClick1()
    {
        scene_NewCharacter_Setting.WhatSelected = 1;
        Male1_1.SetActive(true);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);

    }
    void buttonClick2()
    {
        scene_NewCharacter_Setting.WhatSelected = 2;
        Male1_1.SetActive(false);
        Male1_2.SetActive(true);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick3()
    {
        scene_NewCharacter_Setting.WhatSelected = 3;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(true);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick4()
    {
        scene_NewCharacter_Setting.WhatSelected = 4;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(true);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick5()
    {
        scene_NewCharacter_Setting.WhatSelected = 5;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(true);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick6()
    {
        scene_NewCharacter_Setting.WhatSelected = 6;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(true);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick7()
    {
        scene_NewCharacter_Setting.WhatSelected = 7;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(true);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick8()
    {
        scene_NewCharacter_Setting.WhatSelected = 8;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(true);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick9()
    {
        scene_NewCharacter_Setting.WhatSelected = 9;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(true);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick10()
    {
        scene_NewCharacter_Setting.WhatSelected = 10;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(true);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick11()
    {
        scene_NewCharacter_Setting.WhatSelected = 11;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(true);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick12()
    {
        scene_NewCharacter_Setting.WhatSelected = 12;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(true);
        Female4_1.SetActive(false);
        Female4_2.SetActive(false);
    }
    void buttonClick13()
    {
        scene_NewCharacter_Setting.WhatSelected = 13;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(true);
        Female4_2.SetActive(false);
    }
    void buttonClick14()
    {
        scene_NewCharacter_Setting.WhatSelected = 14;
        Male1_1.SetActive(false);
        Male1_2.SetActive(false);
        Male2_1.SetActive(false);
        Male2_2.SetActive(false);
        Male3_1.SetActive(false);
        Male3_2.SetActive(false);
        Male4_1.SetActive(false);
        Male4_2.SetActive(false);
        Female1_1.SetActive(false);
        Female1_2.SetActive(false);
        Female3_1.SetActive(false);
        Female3_2.SetActive(false);
        Female4_1.SetActive(false);
        Female4_2.SetActive(true);
    }
}
