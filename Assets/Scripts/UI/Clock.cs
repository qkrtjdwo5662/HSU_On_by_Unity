using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    public Text clock;
    string NightSwitch;
    public GameObject onlyNight;
    public GameObject dictionalLight;
    public Material nightSkyBox;
    

    //called before the first frame update
    void Start()
    {
        NightSwitch = DateTime.Now.ToString("HH");
        if (int.Parse(NightSwitch) >= 18 || int.Parse(NightSwitch) <= 6) {
            dictionalLight.SetActive(false);
            RenderSettings.skybox = nightSkyBox;
            onlyNight.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        clock.text = DateTime.Now.ToString("HH:mm");
    }
}
