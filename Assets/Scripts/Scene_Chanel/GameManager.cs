using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {

        public override void OnLeftRoom()
        {
            LoadingSceneController.Instance.LoadScene("Scene(choose chanel");
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

    }
}


