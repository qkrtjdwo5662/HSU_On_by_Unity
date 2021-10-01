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


    
    UI ui;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
	{
        GameObject avatar;
        if (avatar = GameObject.Find("Avatar"))
        {
            ui = avatar.GetComponent<UI>();
        }
        else
            Debug.Log("avatar is Null");
        
        if (ui == null)
		{
			PhotonNetwork.Instantiate(Path.Combine("Prefabs", "character"), Vector3.zero, Quaternion.identity, 0);
            Debug.Log("UI is Null");
            
		}
		else
		{
			if (ui.WhatisSex == 1)
			{
				CreateControllerBoy();
			}
			else if (ui.WhatisSex == 2)
			{
				CreateControllerGirl();
			}
            else if (ui.WhatisSex == 3)
            {
                CreateControllerBoxer();
            }
            Destroy(avatar);
		}



	}
	[PunRPC]
    static void CreateControllerBoy()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boy"), new Vector3 (83f,3f,18f), Quaternion.identity, 0);
    }
    static void CreateControllerGirl()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Girl"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerBoxer()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boxer"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    void Update()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        
        throw new System.NotImplementedException();
    }

    
  

}
