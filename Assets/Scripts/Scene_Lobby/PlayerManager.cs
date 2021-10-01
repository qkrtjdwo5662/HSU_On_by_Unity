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
                CreateControllerBoy2();
            }      

            else if (ui.WhatisSex == 4)
            {
                CreateControllerGirl2();
            }

            else if (ui.WhatisSex == 5)
            {
                CreateControllerBoy3();
            }

            else if (ui.WhatisSex == 6)
            {
                CreateControllerGirl3();
            }

            else if (ui.WhatisSex == 7)
            {
                CreateControllerBoy4();
            }

            else if (ui.WhatisSex == 8)
            {
                CreateControllerGirl4();
            }
            else if (ui.WhatisSex == 9)
            {
                CreateControllerBoy5();
            }

            else if (ui.WhatisSex == 10)
            {
                CreateControllerGirl5();
            }

            else if (ui.WhatisSex == 11)
            {
                CreateControllerBono();
            }

            else if (ui.WhatisSex == 12)
            {
                CreateControllerGhost();
            }

            else if (ui.WhatisSex == 13)
            {
                CreateControllerDora();
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

    static void CreateControllerBoy2()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boy2"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerGirl2()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Girl2"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy3()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boy3"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerGirl3()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Girl3"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy4()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boy4"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerGirl4()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Girl4"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBoy5()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Boy5"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerGirl5()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Girl5"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }

    static void CreateControllerBono()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Bono"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerGhost()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Ghost"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }
    static void CreateControllerDora()//플레이어 컨트롤러 만들기
    {

        Debug.Log("Instantiated Controller");
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Character"), Vector3.zero, Quaternion.identity,0, new object[] { PV.ViewID });
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Dora"), new Vector3(83f, 3f, 18f), Quaternion.identity, 0);
    }




    void Update()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        
        throw new System.NotImplementedException();
    }

    
  

}
