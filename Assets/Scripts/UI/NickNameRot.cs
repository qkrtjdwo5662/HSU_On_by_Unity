using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNameRot : MonoBehaviour
{
    GameObject CameraArm;
    // Start is called before the first frame update
    void Start()
    {
        CameraArm = GameObject.Find("Camera Arm");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = CameraArm.transform.rotation;
    }
}
