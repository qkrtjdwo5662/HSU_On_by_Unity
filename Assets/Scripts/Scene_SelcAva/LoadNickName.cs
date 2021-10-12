using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadNickName : MonoBehaviour
{
    Text NickName;
    public GameObject TMP;
    // Start is called before the first frame update
    void Start()
    {
        NickName = GameObject.Find("NickName").GetComponent<Text>();
        TMP.GetComponent<TextMeshPro>().text = NickName.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
