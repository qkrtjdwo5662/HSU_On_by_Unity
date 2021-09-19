using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NextJoin : MonoBehaviourPunCallbacks
{
    public Button NextBtn;
    public Text connectionInfoText;
    private string gameVersion = "1";
    Text NickName;

    private void Start()
    {
        NickName = GameObject.Find("NickName").GetComponent<Text>();
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.GameVersion = gameVersion;

        PhotonNetwork.ConnectUsingSettings();

        NextBtn.interactable = false;
        NextBtn.onClick.AddListener(Connect);

       connectionInfoText.text = "서버에 접속중..";
    }

    public override void OnConnectedToMaster()
    {
        NextBtn.interactable = true;
        connectionInfoText.text = "온라인 : 환영합니다! " + NickName.text + "님!";
        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        // 룸 접속 버튼을 비활성화
        NextBtn.interactable = false;

        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도중...";

        //마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedLobby()//로비에 연결시 작동
    {
        Debug.Log("Joined Lobby");
        //PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000).ToString("0000");
        PhotonNetwork.NickName = NickName.text;
        //들어온사람 이름 랜덤으로 숫자붙여서 정해주기
    }

    public void Connect()
    {
        NextBtn.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "룸에 접속..";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {

            //마스터 서버로의 재접속 시도
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도중...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        connectionInfoText.text = "빈 방이 없음, 새로운 방 생성";
        Debug.Log("Creating Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });

    }

    public override void OnJoinedRoom()
    {
        //접속 상태 표시
        connectionInfoText.text = "방 참가 성공";
        Debug.Log("Join Room");
        PhotonNetwork.LoadLevel("Scene_Field");
        //LoadingSceneController.Instance.LoadScene("Scene_Field");

    }

}
