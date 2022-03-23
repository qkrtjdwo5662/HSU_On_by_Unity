using Photon.Pun;
using System.Collections;
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

    public GameObject chatBox;
    public GameObject chatBtn_off;
    public GameObject chatBtn_on;

    public GameObject AttackButton;
    public Clock Clock;
    private Hashtable hashtable = new Hashtable();
    private bool isEventStart = false;
    private bool isEvent2Start = false;
    
    private GameObject[] chickens = new GameObject[20];
    private System.Random r = new System.Random();

    private GameObject Me;
    PhotonView PV;


    public bool attend = false;

    public Button developButton;

    [PunRPC]
    public void addAttender(string msg)
    {
        hashtable.Add(msg, 1);
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
        hashtable = new Hashtable();

    }
    private void Event2Start() {
        isEvent2Start = true;

        if (attend == true)
        {
            PV.RPC("addAttender", RpcTarget.AllBuffered, PhotonNetwork.NickName);
            
        }
        





    }
    private void Event2End() { 
    
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
            PV.RPC("EventStart", RpcTarget.AllBuffered);
        });
        PV = GetComponent<PhotonView>();
        StartCoroutine(FindMe());
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
