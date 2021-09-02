using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindChat : MonoBehaviour
{
    private GameObject ChatManager;
    private ChatManager script;

    [SerializeField] 
    private Button sendBtn;
    [SerializeField]
    private Text chatLog;
    [SerializeField]
    private Text chattingList;
    [SerializeField]
    private InputField input;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        ChatManager = GameObject.Find("ChatManager");
        script = ChatManager.GetComponent<ChatManager>();

        script.sendBtn = sendBtn;
        script.chatLog = chatLog;
        script.chattingList = chattingList;
        script.input = input;
        script.CM = ChatManager;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
