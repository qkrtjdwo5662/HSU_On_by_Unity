using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public float LimitTime;
    

    public Button NextButton;
    // Start is called before the first frame update
    void Start()
    {
        NextButton.onClick.AddListener(ButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClick() {
        /*for (int i = 100; i <= 255; i++) {
            NextButton.image.color += new Color(0,0,0,i);
        }*/

        LoadingSceneController.Instance.LoadScene("Scene1");
    }
}
