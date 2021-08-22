using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class  ChatManager : MonoBehaviourPunCallbacks
{
    public List<string> chatList = new List<string>( );
    public Button sendBtn;
    public Text chatLog;
    public Text chattingList;
    public InputField input;
    string chatters;
   
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        //scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
    }
    public void SendButtonOnclicked()
	{
        if(input.text.Equals("")) { Debug.Log("Empty"); return; }
        string msg = string.Format("[{0}] {1}", PhotonNetwork.NickName, input.text);
        photonView.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg);
        ReceiveMsg(msg);
        input.ActivateInputField();
        input.text = "";
	}
    void Update()
	{
        chatterUpdate();
        if (Input.GetKeyDown(KeyCode.Return) && !input.isFocused) SendButtonOnclicked();
	}
    void chatterUpdate()
    {
        chatters = "Player List\n";
        foreach(Player p in PhotonNetwork.PlayerList)
		{
            chatters += p.NickName + "\n";
		}
        chattingList.text = chatters;
    }
    [PunRPC]

    public void ReceiveMsg(string msg)
	{
        chatLog.text += "\n" + msg;
       // scroll_rect.verticalNormalizedPosition = 0.0f;
	}
}
