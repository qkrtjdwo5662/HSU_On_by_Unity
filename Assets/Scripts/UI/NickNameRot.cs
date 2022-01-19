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
    Join join;
    [SerializeField] string NickName;
    public GameObject TMP;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        join = GameObject.Find("Join").GetComponent<Join>();
        PV = GetComponent<PhotonView>();
        CameraArm = GameObject.Find("Camera Arm");
        if (PV.IsMine)
        {
            NickName = join.getStdId().Substring(0,2)+" "+join.getName();
            PV.RPC("set", RpcTarget.OthersBuffered, NickName);
            set(NickName);
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
