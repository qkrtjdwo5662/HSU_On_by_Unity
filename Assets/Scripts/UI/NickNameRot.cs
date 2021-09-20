using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class NickNameRot : MonoBehaviour
{
    GameObject CameraArm;
    Text NickName;
    public GameObject TMP;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        CameraArm = GameObject.Find("Camera Arm");
        if (PV.IsMine)
        {
            NickName = GameObject.Find("NickName").GetComponent<Text>();
            PV.RPC("set", RpcTarget.OthersBuffered, NickName.text);
            set(NickName.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = CameraArm.transform.rotation;
    }
    [PunRPC]
    private void set(string msg)
    {
        TMP.GetComponent<TextMeshPro>().text = msg;
    }
}
