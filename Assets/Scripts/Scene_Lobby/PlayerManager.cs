using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;//path사용위해

public class PlayerManager : MonoBehaviour, IPunObservable
{
    static PhotonView PV;//포톤뷰 선언
    [SerializeField]
    GameObject character;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        
        CreateController();
        

    }
    [PunRPC]
    static void CreateController()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity, 0);
    }
        void Update()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        
        throw new System.NotImplementedException();
    }

    
  

}
