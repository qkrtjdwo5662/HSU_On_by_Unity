using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No_Role_NPC_Trigger : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject MainNpcTalk;
    public GameObject TalkStart;

    //NPC List
    public GameObject NPC;
    //NPC List 끝
    
    
    private Button startBtn; //대화하기 버튼

    //NPC1 Talk
    public Text NPC1_Text;
    public Button NPC1_Btn;
    public string NPC1_Text_Next="";
    public Button NPC1_X_Btn;
    public int NPC1_Btn_Count = 0;
    //NPC1 Talk 끝
    private GameObject CameraArm;
    private GameObject Me;
    private TPSCharacterController tps;

    //public List<string> NPC = new List<string>() { "NPC1", "NPC2" };
    //public string NPC = "";

    private void Start()
    {
        StartCoroutine(FindMe());
        NPC1_Text.text = "여기가 바로 가상 한성대학교?";
    }
    /*public void Update()
    {
        NPC_Talk();
    }*/
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {

            Dialog.SetActive(true);
            MainNpcTalk.SetActive(true);
            if (!TalkStart.Equals(null))
                TalkStart.SetActive(true);
            //FadeIn();

        }

    }



    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {

            Dialog.SetActive(false);
            MainNpcTalk.SetActive(false);
            if (!TalkStart.Equals(null))
                TalkStart.SetActive(false);
            if (Dialog.activeInHierarchy)
                CameraReturn();
            //FadeOut();
        }
    }
    public void NPC_Talk()
    {        
        ++NPC1_Btn_Count;
        if (NPC1_Btn_Count >= 1)
        {
            NPC1_Text_Next = "너도 신기하지 않니?";
            NPC1_Text.text = NPC1_Text_Next.ToString();

        }
        /*else if (NPC1_Btn_Count == 0)
        {
            //NPC1_Text.text = "여기가 바로 가상 한성대학교?";

            
        }*/        
        NPC1_X_Btn.onClick.AddListener(() => {
            NPC1_Btn_Count = 0;
            NPC1_Text_Next = "여기가 바로 가상 한성대학교?"; 
            NPC1_Text.text = NPC1_Text_Next.ToString();
        });
        
    }
    private void CameraWork()
    {

        StartCoroutine(MoveTo(CameraArm, this.transform.position + Vector3.down * 0));
    }
    public void CameraReturn()
    {
        StartCoroutine(MoveTo(CameraArm, Me.transform.position));
    }
    
    IEnumerator MoveTo(GameObject obj, Vector3 destination)
    {
        tps.moveSwitch = false;
        float count = 0;
        Vector3 wasPos = obj.transform.position;

        while (true)
        {
            count += Time.deltaTime * 4;
            obj.transform.position = Vector3.Lerp(wasPos, destination, count);


            if (count >= 1)
            {
                tps.moveSwitch = true;
                obj.transform.position = destination;
                break;
            }
            yield return null;
        }

    }
    IEnumerator FindMe()
    {


        while (true)
        {
            Me = GameObject.Find("Me");

            if (Me != null)
            {
                tps = Me.GetComponent<TPSCharacterController>();
                CameraArm = Me.transform.Find("Camera Arm").gameObject;
                startBtn = MainNpcTalk.transform.Find("Talk0").GetComponentInChildren<Button>();
                startBtn.onClick.AddListener(CameraWork);
                break;
            }
            yield return null;
        }
    }
}
