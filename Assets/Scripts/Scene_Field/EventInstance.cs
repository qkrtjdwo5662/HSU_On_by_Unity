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

    [SerializeField]
    private GameObject chicken;
    private GameObject[] chickens = new GameObject[10];
    private System.Random r = new System.Random();

    private GameObject Me;
    PhotonView PV;

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

    private void EventStart()
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
        PV = GetComponent<PhotonView>();
        Me = GameObject.Find("Me");
    }

    // Update is called once per frame
    void Update()
    {

        if (Clock.clock.text.Equals("09:16"))
        {
            if (!isEventStart) {
                EventStart();
            }
        }

        if (isEventStart)
        {
            TimeBoard.text = "남은시간 : " + (int)((timer -= Time.deltaTime))+"초";
            ScoreBoard.text = HashToString(hashtable);
            if (timer <= 0)
            {
                EventEnd();
                for (int i = 0; i < chickens.Length; i++)
                {
                    chickens[i] = null;
                }
            }

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
}
