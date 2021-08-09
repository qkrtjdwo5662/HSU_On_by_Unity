using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI; // text와 inputfield사용

public class NetworkManager : MonoBehaviourPunCallbacks
{
	[Header("DisconnectPanel")]
	public InputField NickNameInput;
	public Button ConnectBtn;
	//닉네임 필드, 접속 버튼

	[Header("LobbyPanel")]
	public Text WelcomeText;
	public Button BackBtn;
	public Button SelectChanelBtn;
	public Button QuickBtn;
	//환영인사text
	//뒤로가기, 채널선택버튼, 빠른입장, 뒤로가기 버튼

	[Header("ChanelPanel")]
	public Button chanel1;
	public Button chanel2;
	public Button chanel3;
	public Button chanel4;
	//채널 1,2,3,4 버튼


	string networkState;

	void Awake() => Screen.SetResolution(2220, 1080, false);

	public void OnEnable()
	{
		PhotonNetwork.AutomaticallySyncScene = true;
		Connect();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
		PhotonNetwork.JoinLobby();

	}
	private void Connect()
	{
		Debug.Log("Connecting to Master");
		PhotonNetwork.GameVersion = "1.0";
		PhotonNetwork.ConnectUsingSettings();//클라이언트 게임 버전 및 pun2 설정파일
	}


	

	public override void OnJoinedLobby()//로비 연결시 작동
	{
		//LobbyPanel.SetActive(true);
		//ChanelPanel.SetActive(false);

		Debug.Log("joined Lobby");
		

		PhotonNetwork.CreateRoom("chanel1");
		PhotonNetwork.CreateRoom("chanel2");
		PhotonNetwork.CreateRoom("chanel3");
		PhotonNetwork.CreateRoom("chanel4");//채널 1,2,3,4 방만들기

		PhotonNetwork.JoinRandomRoom();//무작위 방 참여

		PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 5}, null);
	}
	
	

	public void Test(Text text)
	{
		PhotonNetwork.NickName = NickNameInput.text;
		WelcomeText.text = PhotonNetwork.NickName + "님 환영합니다";
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("채널입장 성공");
	}
	//방(채널)참가 성공시 

	//public override void OnLeftRoom()

	void Update()
	{
		string curNetworkState = PhotonNetwork.NetworkClientState.ToString();
		if (networkState != curNetworkState)
		{
			networkState = curNetworkState;
			print(networkState);
		}
	}
}

