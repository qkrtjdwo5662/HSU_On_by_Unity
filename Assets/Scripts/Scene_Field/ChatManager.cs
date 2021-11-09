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
    private ScrollRect scroll_rect;
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
        //scroll_rect = GameObject.FindObjectOfType<ScrollRect>();
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
        string msg = string.Format("[{0}] : {1}", PhotonNetwork.NickName, input.text);
        PV.RPC("ReceiveMsg", RpcTarget.OthersBuffered, msg);
        sp.speechRun(input.text);
        ReceiveMsg(msg);
        //input.ActivateInputField();
        input.text = "";
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
    /*void chatterUpdate()
    {
        chatters = "Player List\n";
        foreach(Player p in PhotonNetwork.PlayerList)
		{
            chatters += p.NickName + "\n";
		}
        chattingList.text = chatters;
    }*/
    [PunRPC]

    public void ReceiveMsg(string msg)
	{
        chatLog.text += "\n" + msg;
        //scroll_rect.verticalNormalizedPosition = 0.0f;
	}
}
