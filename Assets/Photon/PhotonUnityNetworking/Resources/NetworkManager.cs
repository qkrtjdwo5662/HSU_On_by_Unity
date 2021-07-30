using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
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
		PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions { MaxPlayers = 4 }, null);
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
