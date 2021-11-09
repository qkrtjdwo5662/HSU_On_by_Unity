using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitAction : MonoBehaviour
{
    public Button button;
    public Slider slider;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ExitGame);
        AS = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float a = slider.value;
        AS.volume = a * 0.125f;
    }

    void ExitGame() {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    void volume() { 
    
    }

}
