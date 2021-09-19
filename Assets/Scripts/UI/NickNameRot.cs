using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NickNameRot : MonoBehaviour
{
    GameObject CameraArm;
    Text NickName;
    public GameObject TMP;
    // Start is called before the first frame update
    void Start()
    {
        CameraArm = GameObject.Find("Camera Arm");
        NickName = GameObject.Find("NickName").GetComponent<Text>();
        TMP.GetComponent<TextMeshPro>().text = NickName.text;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = CameraArm.transform.rotation;
    }
}
