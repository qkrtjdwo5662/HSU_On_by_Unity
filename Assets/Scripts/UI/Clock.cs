using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    public Text clock;


    //called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = DateTime.Now.ToString("yyyy.MM.dd\nHH:mm:ss tt");
    }
}
