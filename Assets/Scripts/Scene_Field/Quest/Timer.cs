using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject Test1;
    public GameObject Test3;
    public float LimitTime = 60;
    public Text text_Timer;
    // Start is called before the first frame update

    public void DoTimerOffset()
    {
        LimitTime = 60;
    }
    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "남은 시간: " + Mathf.Round(LimitTime);
        if (LimitTime <= 0)
        {
            Test1.SetActive(false);
            Test3.SetActive(true);
        }
    }


}