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
    Join join;
    private string gameVersion = "1";
    

    private void Start()
    {
        join = GameObject.Find("Join").GetComponent<Join>();
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.GameVersion = gameVersion;

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("First Login");

        }
        else if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinLobby();
            Debug.Log("Already Login");
        }

        NextBtn.interactable = false;
        NextBtn.onClick.AddListener(Connect);

       connectionInfoText.text = "서버에 접속중..";
    }
    private void Update()
    {
        if (PhotonNetwork.IsConnected && join.isQueryEnd)
        {

            NextBtn.interactable = true;
        }
        else
        {
            join.GetUserInformationFromFireBase();
            
            connectionInfoText.text = "온라인 : 데이터베이스와 통신 중...";

        }
    }

    public override void OnConnectedToMaster()
    {
        connectionInfoText.text = connectionInfoText.text = "온라인 : 환영합니다! " + join.getStdId().Substring(0, 2) + " " + join.getName() + "님!";

        PhotonNetwork.JoinLobby();//마스터 서버 연결시 로비로 연결
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        // 룸 접속 버튼을 비활성화
        

        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n 접속 재시도 중...";

        //마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }
    

    public override void OnJoinedLobby()//로비에 연결시 작동
    {
        Debug.Log("Joined Lobby");
        //PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000).ToString("0000");
        PhotonNetwork.NickName = join.getStdId().Substring(0, 2) + " " + join.getName();
        //들어온사람 이름 랜덤으로 숫자붙여서 정해주기
    }

    public void Connect()
    {
        NextBtn.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            //룸 접속 실행
            connectionInfoText.text = "온라인 : 채널에 접속 중..";
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

        connectionInfoText.text = "온라인 : 활성화된 채널 없음. 새로운 채널 생성";
        Debug.Log("Creating Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 0 });

    }

    public override void OnJoinedRoom()
    {
        //접속 상태 표시
        connectionInfoText.text = "온라인 : 채널 생성 성공";
        Debug.Log("Join Room");
        PhotonNetwork.LoadLevel("Scene_Field");
        //LoadingSceneController.Instance.LoadScene("Scene_Field");

    }

}
