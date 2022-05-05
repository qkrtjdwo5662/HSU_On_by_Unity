using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventInstance : MonoBehaviour
{
    public GameObject winnerPanel;
    public Text winnerBanner;

    public GameObject ScorePanel;
    public Text ScoreBoard;
    public Text TimeBoard;
    public float timer = 120f;
    public float event2Timer = 5.0f;
    public string currentBomb;
    public int currentBombIndex;

    public GameObject chatBox;
    public GameObject chatBtn_off;
    public GameObject chatBtn_on;

    public GameObject AttackButton;
    public Clock Clock;

    private Hashtable hashtable = new Hashtable();
    public ArrayList list = new ArrayList();

    //private List<string> list = new List<string>();


    private bool isEventStart = false;
    private bool isEvent2Start = false;
    
    private GameObject[] chickens = new GameObject[20];
    private System.Random r = new System.Random();

    private GameObject Me;
    PhotonView PV;


    public bool attend = false;

    public bool listFlag = false;




    public Button developButton;


    private Join join;



    [PunRPC]
    public void addAttender(string msg)
    {
        
        list.Add(msg);
        Debug.Log("I'm Attender");
    }


    [PunRPC]
    private void addRanker(string msg, int score)
    {
        if (hashtable.ContainsKey(msg))
        {
            hashtable[msg] = (int)hashtable[msg] + score;
        }
        else
        {
            hashtable.Add(msg, score);
        }
    }

    public void hitchicken(string playerName, int score)
    {
        PV.RPC("addRanker", RpcTarget.AllBuffered, playerName, score);
    }
    [PunRPC]
     void EventStart()
    {
        Me.GetComponent<TPSCharacterController>().ActivateHammerRPC();
        chatBox.SetActive(false);
        chatBtn_off.SetActive(false);
        chatBtn_on.SetActive(true);

        AttackButton.SetActive(true);
        ScorePanel.SetActive(true);
        isEventStart = true;

    }

    private void EventEnd()
    {
        Me.GetComponent<TPSCharacterController>().DeactivateHammerRPC();

        ScorePanel.SetActive(false);
        isEventStart = false;
        AttackButton.SetActive(false);

        string winner = "";
        int winnerScore = 0;
        foreach (DictionaryEntry d in hashtable)
        {
            if (winnerScore < (int)d.Value)
            {
                winnerScore = (int)d.Value;
                winner = d.Key.ToString();
            }
        }
        winnerPanel.SetActive(true);
        winnerBanner.text = string.Format("우승!     {0}      {1}점", winner, winnerScore);
        join.AddMoney(winner);
        hashtable = new Hashtable();

    }
    [PunRPC]
    private void Event2Start() {
        
        if (attend == true)
        {
            PV.RPC("addAttender", RpcTarget.AllBuffered, PhotonNetwork.NickName);
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            ScorePanel.SetActive(true);
            chatBox.SetActive(false);
            chatBtn_off.SetActive(false);
            chatBtn_on.SetActive(true);
            isEvent2Start = true;

        }
        if (PhotonNetwork.IsMasterClient)
        {
            
            currentBombIndex = Random.Range(0, list.Count);
            Debug.Log(currentBombIndex);

            if (list.Count >= 1)
            {
                orderBombRPC(list[currentBombIndex].ToString());
                Debug.Log(list[currentBombIndex]);
            }
            else if (list.Count == 0) {
                isEvent2Start = false;

            }
        }

    }

    public void orderBombRPC(string name) {
        PV.RPC("orderBomb",RpcTarget.All,name);
    }

    [PunRPC]
    public void orderBomb(string nickname) {
        Me.GetComponent<TPSCharacterController>().WearBombRPC(nickname);
        currentBomb = nickname;
        currentBombIndex = list.IndexOf(currentBomb);
        timer = 5.0f;
    }

    [PunRPC]
    private void Event2End(string winner) {
        Me.GetComponent<TPSCharacterController>().TakeOffBombRPC(PhotonNetwork.NickName);
        winnerPanel.SetActive(true);
        winnerBanner.text = "우승! " + winner + "\n 상금 600원이 지급됩니다!";
        ScorePanel.SetActive(false);
        isEvent2Start = false;
        join.AddMoney(winner);

    }

    [PunRPC]
    private void Event2Lose(string name) {
        if (name == PhotonNetwork.NickName)
        {
            winnerPanel.SetActive(true);
            winnerBanner.text = "아쉽지만, 다음기회에!";
            ScorePanel.SetActive(false);
            isEvent2Start = false;
            Me.GetComponent<TPSCharacterController>().TakeOffBomb(name);
            Me.GetComponent<Transform>().position = new Vector3(87.61545f, 12.72846f, 2f);
        }
    }


    private string HashToString(Hashtable hashtable)
    {
        string result = "";

        foreach (DictionaryEntry d in hashtable)
        {
            result += string.Format("{0} : {1}점\n", d.Key, d.Value);
        }

        return result;
    }

    void Start()
    {
        developButton.onClick.AddListener( ()=> {
            PV.RPC("Event2Start", RpcTarget.AllBuffered);
        });
        PV = GetComponent<PhotonView>();
        StartCoroutine(FindMe());
        StartCoroutine(FindJoin());
    }


    IEnumerator FindMe() {
        while (true) {
            Me = GameObject.Find("Me");
            if (Me != null) {
                break;
            }
            yield return null;
        }
    }
    IEnumerator FindJoin()
    {
        while (true)
        {
            join = GameObject.Find("Join").GetComponent<Join>();
            if (Me != null)
            {
                break;
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (Clock.clock.text.Equals("16:00"))
        {
            if (!isEventStart) {
                EventStart();
                //PV.RPC("EventStart",RpcTarget.AllBuffered);
            }
        }

        if (isEventStart)
        {
            TimeBoard.text = "남은시간 : " + (int)((timer -= Time.deltaTime))+"초";
            ScoreBoard.text = HashToString(hashtable);

            if (PhotonNetwork.IsMasterClient) 
            {
                SpawnChicken();
            }
            if (timer <= 0)
            {
                EventEnd();
                for (int i = 0; i < chickens.Length; i++)
                {
                    PhotonNetwork.Destroy(chickens[i]);
                }
            }
        }
        if (Clock.clock.text.Equals("18:00"))
        {
            if (!isEvent2Start)
            {
                Event2Start();
                //PV.RPC("EventStart",RpcTarget.AllBuffered);
            }
        }

        if (isEvent2Start)
        {
            TimeBoard.text = "남은시간 : " + (int)((event2Timer -= Time.deltaTime)) + "초";
            ScoreBoard.text = "\n"+"현재 폭탄 :" + currentBomb;
            if (PhotonNetwork.IsMasterClient)
            {
                if (event2Timer < 0)
                {
                    listFlag = true;
                    ManagementList();
                }
                
            }
        }


    }

    void ManagementList() {

        if (listFlag)
        {
            listFlag = false;
            if (list.Count == 1)
            {
                string winner = list[0].ToString();
                PV.RPC("Event2End", RpcTarget.All, winner);
                Me.GetComponent<TPSCharacterController>().TakeOffBombRPC(PhotonNetwork.NickName);
                Debug.Log("우승자는 : " + winner);
                list.RemoveAt(currentBombIndex);
            }
            else
            {
                PV.RPC("Event2Lose", RpcTarget.All, list[currentBombIndex]);
                list.RemoveAt(currentBombIndex);
                currentBombIndex = Random.Range(0, list.Count);
                PV.RPC("orderBomb", RpcTarget.All, list[currentBombIndex]);
                Debug.Log(list[currentBombIndex]);
            }
        }
    }


    void SpawnChicken()
    {
        for (int i = 0; i < chickens.Length; i++)
        {
            if (chickens[i] == (null))
            {
                int x = r.Next(-105, -64);
                int z = r.Next(60, 81);
                chickens[i] = PhotonNetwork.Instantiate("Prefabs/Chicken", new Vector3(x, 1, z), Quaternion.identity, 0);
            }
        }
    }
}
