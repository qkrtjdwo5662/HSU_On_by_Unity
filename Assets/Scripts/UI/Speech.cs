using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
    public GameObject CameraArm;
    //public Button send;
    //public InputField input;
    public GameObject tm;
    public GameObject dialog;
    public float start = 0.0f;
    private float finish = 2.0f;
    public int cheak = 0;

    PhotonView PV;
    
    // Start is called before the first frame update
    void Start()
    {
        //send = GameObject.Find("Send").GetComponent<Button>();
        //input = GameObject.Find("InputField").GetComponent<InputField>();
        PV = GetComponent<PhotonView>();
        CameraArm = GameObject.Find("Camera Arm");
        
        //send.onClick.AddListener(speechRun);
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = CameraArm.transform.rotation;
        if (cheak == 1)
        {
            
            start += Time.deltaTime;
            if (start >= 2.0f)
            {
                dialog.SetActive(false);
                start = 0.0f;
                cheak = 0;
            }
        }
    }


    public void speechRun(string msg) 
    {
        if (PV.IsMine) {
            PV.RPC("gotoTM", RpcTarget.Others, msg);
            gotoTM(msg);
            
        }
        
    }
    [PunRPC]
    void gotoTM(string text) 
    {
        Debug.Log(text);
        dialog.SetActive(true);
        tm.GetComponent<TextMeshPro>().text = text;
        cheak = 1;
    }
}
