using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class  ChatManager : MonoBehaviourPunCallbacks
{
    //public List<string> chatList = new List<string>( );
    public List<string> playerNicknameList = new List<string>();
    public Button sendBtn;
    public Text chatLog;
    public Text chattingList;
    public InputField input;
    string chatters;
    private ScrollRect scroll_rect = null;

    public Text NickName_input;

    private Join join;

    PhotonView PV;
    bool cool = true;
    public float time;
    bool focuseFlag = false;


    public GameObject AllButton;
    public GameObject PrivateButton;

    public GameObject target;
    public Button targetSearch;
    public Text chatList;



    [SerializeField]
    public GameObject CM;

    Speech sp;
    // Start is called before the first frame update
    void Start()
    {
        join = GameObject.Find("Join").GetComponent<Join>();

        PV = GetComponent<PhotonView>();
        PhotonNetwork.IsMessageQueueRunning = true;
        scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
        sp = GameObject.Find("speechObject").GetComponent<Speech>();

        targetSearch.onClick.AddListener(GetPlayerList);
        sendBtn.onClick.AddListener(SendButtonOnclicked);
    }

    void GetPlayerList() 
    {
        chatList.text = "";
        Player[] players = PhotonNetwork.PlayerList;
        for (int i=0; i<players.Length; i++) 
        {
            chatList.text += players[i].NickName+ "\n";
        }
    
    }

    
    public void SendButtonOnclicked()
	{
        if (AllButton.activeInHierarchy)
        {
            if (input.text.Equals("")) { Debug.Log("Empty"); return; }
            string all_msg = string.Format("[일반] {0} : {1}", PhotonNetwork.NickName, input.text);
            PV.RPC("ReceiveMsg", RpcTarget.OthersBuffered, all_msg, "All");
            sp.speechRun(input.text);
            ReceiveMsg(all_msg, "All");
            //input.ActivateInputField();
            input.text = "";
        }
        else if (PrivateButton.activeInHierarchy) 
        {
            string targetName = target.GetComponent<Text>().text;
            if (input.text.Equals("")) { Debug.Log("Empty"); return; }
            string private_msg_send = string.Format("[귓속말] {0}님이 : {1}", PhotonNetwork.NickName, input.text);
            PV.RPC("ReceiveMsg", RpcTarget.OthersBuffered, private_msg_send, targetName); // 지정 유저에게 귓속말
            string private_msg_receive = string.Format("[귓속말] {0}님에게 : {1}", PhotonNetwork.NickName, input.text);
            //sp.speechRun(input.text);
            ReceiveMsg(private_msg_receive, targetName);//자신이 보낸 귓속말
            input.text = "";
        }
	}

  

    /*public void FindNickName()
	{
        if(playerNicknameList.Exists(x=> x.Equals(NickName_input)))
		{
            Debug.Log("귓속말 상대 존재");
            var a = playerNicknameList.Find(x => x.Equals(NickName_input));
		}
        else { Debug.Log("귓속말 상대 설정 실패"); }
    }*/

    /*void Update()
	{
        //chatterUpdate();
        if (Input.GetKey(KeyCode.Return)) {
            if (cool)
            {
                if (focuseFlag == true)
                {
                    focuseFlag = false;
                    SendButtonOnclicked();
                    Debug.Log("send");
                    input.DeactivateInputField();
                }
                else if (focuseFlag == false)
                {
                    focuseFlag = true;
                    input.ActivateInputField();
                    Debug.Log("input focuse: " + input.isFocused);

                }

                cool = false;
                
            }
        }

        if (cool == false) {

            if (time >= 0.5f)
            {
                time = 0.0f;
                cool = true;
            }
            time += Time.deltaTime;
        }
        
    }*/



    [PunRPC]
    public void ReceiveMsg(string msg, string target)
	{
        if (target.Equals("All") || target.Equals(join.getStdId().Substring(0, 2) + " " + join.getName())) 
        {
            chatLog.text += "\n" + msg;
        }
        
        //scroll_rect.verticalNormalizedPosition = 0.0f;
	}
}
