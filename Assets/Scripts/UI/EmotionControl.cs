using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class EmotionControl : MonoBehaviour
{
    public Button DoEmotion;
    public Button conversation;
    public Button dance;
    public Button yes;
    public Button no;
    public Button victory;
    public Button lose;
    public GameObject EmotionPanel;
    public ChangeMask CM;

    public Animator animator;
    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = gameObject.GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            DoEmotion = GameObject.Find("EmotionButton").GetComponent<Button>();
            conversation = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("conversation").GetComponent<Button>();
            dance = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("dance").GetComponent<Button>();
            yes = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("yes").GetComponent<Button>();
            no = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("no").GetComponent<Button>();
            victory = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("victory").GetComponent<Button>();
            lose = GameObject.Find("UI").transform.Find("EmotionPanel").transform.Find("lose").GetComponent<Button>();
            EmotionPanel = GameObject.Find("UI").transform.Find("EmotionPanel").gameObject;

            DoEmotion.onClick.AddListener(EmotionOn);
            conversation.onClick.AddListener(DoConversation);
            dance.onClick.AddListener(DoDance);
            yes.onClick.AddListener(DoYes);
            no.onClick.AddListener(DoNo);
            victory.onClick.AddListener(DoVictoy);
            lose.onClick.AddListener(DoLose);
            CM.AddListenerStart();

        }
        else if (!PV.IsMine) {
            Destroy(this);
            
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void EmotionOn() 
    {
        EmotionPanel.SetActive(true);
    }
    void DoConversation()
    {
        animator.SetBool("conversation", true);
        animator.SetBool("dance", false);
        animator.SetBool("victory", false);
        animator.SetBool("lose", false);
        animator.SetBool("yes", false);
        animator.SetBool("no", false);
        EmotionPanel.SetActive(false);
    }

    void DoDance()
    {
        animator.SetBool("dance", true);
        animator.SetBool("conversation", false);
        animator.SetBool("victory", false);
        animator.SetBool("lose", false);
        animator.SetBool("yes", false);
        animator.SetBool("no", false);
        EmotionPanel.SetActive(false);
    }

    void DoYes()
    {
        animator.SetBool("yes", true);
        animator.SetBool("conversation", false);
        animator.SetBool("dance", false);
        animator.SetBool("victory", false);
        animator.SetBool("lose", false);
        animator.SetBool("no", false);
        EmotionPanel.SetActive(false);
    }
    void DoNo()
    {
        animator.SetBool("no", true);
        animator.SetBool("conversation", false);
        animator.SetBool("dance", false);
        animator.SetBool("victory", false);
        animator.SetBool("lose", false);
        animator.SetBool("yes", false);
        EmotionPanel.SetActive(false);
    }

    void DoVictoy()
    {
        animator.SetBool("victory", true);
        animator.SetBool("conversation", false);
        animator.SetBool("dance", false);
        animator.SetBool("lose", false);
        animator.SetBool("yes", false);
        animator.SetBool("no", false);
        EmotionPanel.SetActive(false);
    }

    void DoLose()
    {
        animator.SetBool("lose", true);
        animator.SetBool("conversation", false);
        animator.SetBool("dance", false);
        animator.SetBool("victory", false);
        animator.SetBool("yes", false);
        animator.SetBool("no", false);
        EmotionPanel.SetActive(false);

    }

}
