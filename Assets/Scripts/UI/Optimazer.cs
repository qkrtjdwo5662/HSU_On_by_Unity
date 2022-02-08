using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optimazer : MonoBehaviour
{
    public Button ExitButton;
    
    public Slider VolumeSlider;
    private AudioSource AS;

    public Dropdown ShadowSet;
    public Light dl;

    public Dropdown AntiAliasingSet;


    // Start is called before the first frame update
    void Start()
    {

        ExitButton.onClick.AddListener(() => { Application.Quit(); });
        AS = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        VolumeSlider.onValueChanged.AddListener(delegate {
            SetVolume();
        });

        ShadowSet.ClearOptions();
        ShadowSet.options.Add(new Dropdown.OptionData("None"));
        ShadowSet.options.Add(new Dropdown.OptionData("Hard"));
        ShadowSet.options.Add(new Dropdown.OptionData("Soft"));
        ShadowSet.value = 1;
        ShadowSet.onValueChanged.AddListener(delegate {
            DropFunc();
        });

        AntiAliasingSet.ClearOptions();
        AntiAliasingSet.options.Add(new Dropdown.OptionData("Off"));
        AntiAliasingSet.options.Add(new Dropdown.OptionData("2x"));
        AntiAliasingSet.options.Add(new Dropdown.OptionData("4x"));
        AntiAliasingSet.options.Add(new Dropdown.OptionData("8x"));


        AntiAliasingSet.value = 0;
        AntiAliasingSet.onValueChanged.AddListener(delegate {
            SetAntiAliasing();
        });
    }
    void DropFunc() 
    {
        if (ShadowSet.value == 0)
        {
            dl.shadows = LightShadows.None;
        }
        else if (ShadowSet.value == 1)
        {
            dl.shadows = LightShadows.Hard;
        }
        else if (ShadowSet.value == 2)
        {
            dl.shadows = LightShadows.Soft;
        }
    }
    void SetVolume() 
    {
        AS.volume = VolumeSlider.value * 0.125f;
    }

    void SetAntiAliasing() {
        if (AntiAliasingSet.value == 0)
        {
            QualitySettings.antiAliasing = 0;
        }
        else if (AntiAliasingSet.value == 1)
        {
            QualitySettings.antiAliasing = 2;
        }
        else if (AntiAliasingSet.value == 2)
        {
            QualitySettings.antiAliasing = 4;
        }
        else if (AntiAliasingSet.value == 3)
        {
            QualitySettings.antiAliasing = 8;
        }

    }
}
