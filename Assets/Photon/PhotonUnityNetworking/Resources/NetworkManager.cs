using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
	/*[Header("DisconnectedPanel")]
	public InputField NickNameInput;
	//닉네임 필드, 접속 버튼

	[Header("LobbyPanel")]
	public Text WelcomeText;*/

	string networkState;

	private void Start()
	{
		Debug.Log("Connecting to Master");
		PhotonNetwork.ConnectUsingSettings(); // 설정 포톤 서버에 따라 마스터 서버에 연결
	}
	public override void OnConnectedToMaster()
	{
		Debug.Log("Connecting to Master");
		PhotonNetwork.JoinLobby(); // 마스터 서버 연결시 로비로 연결
	}
	public override void OnJoinedLobby()//로비 연결시 작동
	{
		//LobbyPanel.SetActive(true);
		//Choose_Chanel_Panel.SetActive(false);
		//PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
		//WelcomeText.text = PhotonNetwork.LocalPlayer.NickName + "님 환영합니다";
		PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 5}, null);
	}
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
