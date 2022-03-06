using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatchaAnimation : MonoBehaviour
{
    public Image LoadingBar;
    float currentValue;
    public float speed;
    public GameObject GatchaPanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
            
        }
        else
        {
            GatchaPanel.SetActive(false);
            currentValue = 0;
        }



        LoadingBar.fillAmount = currentValue / 100;

    }

}
