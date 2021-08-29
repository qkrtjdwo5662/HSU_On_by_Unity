using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;//path사용위해

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;//포톤뷰 선언
    GameObject character;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)//내 포톤 네트워크이면
        {
            CreateController();//플레이어 컨트롤러 붙여준다. 
        }
        else {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), new Vector3(-108f, 0.1f, 80f), Quaternion.identity, 0, new object[] { PV.ViewID });
        }
    }
    void CreateController()//플레이어 컨트롤러 만들기
    {
       
        Debug.Log("Instantiated Controller");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), new Vector3(-108f,0.1f,80f), Quaternion.identity,0,new object[] { PV.ViewID });
    }
}
