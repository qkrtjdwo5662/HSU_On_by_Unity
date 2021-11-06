using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hidden4 : MonoBehaviour
{
    
    public GameObject Test1;
    public GameObject Test2;
    
    public Text ScriptTxt;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "0";
    }
    public void CountPlus()
    {
        count += 1;
        ScriptTxt.text = count.ToString();
        if(count == 5)
        {
            Test1.SetActive(false);
            Test2.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
