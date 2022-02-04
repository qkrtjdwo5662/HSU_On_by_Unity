using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class  ChatManager : MonoBehaviourPunCallbacks
{
    public List<string> chatList = new List<string>( );
    public List<string> playerNicknameList = new List<string>();
    public Button sendBtn;
    public Text chatLog;
    public Text chattingList;
    public InputField input;
    string chatters;
    private ScrollRect scroll_rect = null;

    public Text NickName_input;

    PhotonView PV;
    bool cool = true;
    public float time;
    bool focuseFlag = false;


    [SerializeField]
    public GameObject CM;

    Speech sp;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
        sp = GameObject.Find("speechObject").GetComponent<Speech>();

        sendBtn.onClick.AddListener(SendButtonOnclicked);
    }
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        //sendBtn = GameObject.Find("ChatLog");
        /*PV.ViewID = 0;
        if (PV.IsMine)
        {
            PV.ViewID = 9;
        }*/
        

    }

    
    public void SendButtonOnclicked()
	{
        if(input.text.Equals("")) { Debug.Log("Empty"); return; }
        string all_msg = string.Format("[일반] {0} : {1}", PhotonNetwork.NickName, input.text);
        PV.RPC("ReceiveMsg", RpcTarget.OthersBuffered, all_msg) ;
        sp.speechRun(input.text);
        ReceiveMsg(all_msg);
        //input.ActivateInputField();
        input.text = "";
	}

    public void SendPrivate()
    {
        if (input.text.Equals("")) { Debug.Log("Empty"); return; }
        string private_msg_send = string.Format("[귓속말] {0}님이 : {1}", PhotonNetwork.NickName, input.text);
        PV.RPC("ReceiveMsg", RpcTarget.OthersBuffered, private_msg_send); // 지정 유저에게 귓속말
        string private_msg_receive = string.Format("[귓속말] {0}님에게 : {1}", PhotonNetwork.NickName, input.text);
        sp.speechRun(input.text);
        ReceiveMsg(private_msg_receive);//자신이 보낸 귓속말
        input.text = ""; //input.text 빈칸
    }

    public void FindNickName()
	{
        if(playerNicknameList.Exists(x=> x.Equals(NickName_input)))
		{
            Debug.Log("귓속말 상대 존재");
            var a = playerNicknameList.Find(x => x.Equals(NickName_input));
		}
        else { Debug.Log("귓속말 상대 설정 실패"); }
    }

    void Update()
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
        
    }

    void chatterUpdate()
    {
        chatters = "Player List\n";
        foreach (Player p in PhotonNetwork.PlayerList)
        {
            playerNicknameList.Add(p.NickName);
        }
        chattingList.text = chatters;
    }


    [PunRPC]
    public void ReceiveMsg(string msg)
	{
        chatLog.text += "\n" + msg;
        //scroll_rect.verticalNormalizedPosition = 0.0f;
	}
}
