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


    
    Scene_newCharacter_Setting ui;
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
	{
        GameObject avatar;
        if (avatar = GameObject.Find("Setting"))
        {
            ui = avatar.GetComponent<Scene_newCharacter_Setting>();
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
            if (ui.WhatSelected == 0)
            {
                CreateControllerBoy1();
            }
            if (ui.WhatSelected == 1)
			{
                CreateControllerBoy1();
            }
			else if (ui.WhatSelected == 2)
			{
                CreateControllerBoy1_1();
            }
            else if (ui.WhatSelected == 3)
            {
                CreateControllerBoy2();
            }      

            else if (ui.WhatSelected == 4)
            {
                CreateControllerBoy2_1();
            }

            else if (ui.WhatSelected == 5)
            {
                CreateControllerBoy3();
            }

            else if (ui.WhatSelected == 6)
            {
                CreateControllerBoy3_1();
            }

            else if (ui.WhatSelected == 7)
            {
                CreateControllerBoy4();
            }

            else if (ui.WhatSelected == 8)
            {
                CreateControllerBoy4_1();
            }
            else if (ui.WhatSelected == 9)
            {
                CreateControllergirl1();
            }

            else if (ui.WhatSelected == 10)
            {
                CreateControllergirl1_1();
            }

            else if (ui.WhatSelected == 11)
            {
                CreateControllergirl3();
            }

            else if (ui.WhatSelected == 12)
            {
                CreateControllergirl3_1();
            }

            else if (ui.WhatSelected == 13)
            {
                CreateControllergirl4();
            }
            else if (ui.WhatSelected == 14)
            {
                CreateControllergirl4_1();
            }
            Destroy(avatar);
		}



	}
	[PunRPC]
    static void CreateControllerBoy1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male1"), new Vector3 (83f,3f,18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy1_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male1_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerBoy2()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male2"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerBoy2_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male2_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerBoy3()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male3"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy3_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male3_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerBoy4()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male4"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy4_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Male4_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllergirl1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllergirl1_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female1_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllergirl3()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female3"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllergirl3_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female3_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllergirl4()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female4"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllergirl4_1()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Female4_1"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    void Update()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        
        throw new System.NotImplementedException();
    }

    
  

}
