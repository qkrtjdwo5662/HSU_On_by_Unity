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

    private GameObject CameraArm;
    private GameObject Me;
    private TPSCharacterController tps;

    //public List<string> NPC = new List<string>() { "NPC1", "NPC2" };
    //public string NPC = "";

    private void Start()
    {
        StartCoroutine(FindMe());
    }

    //NPC1 Talk
    public Text NPC1_Text;
    public Button NPC1_Btn;
    public string NPC1_Text_First = "";
    public string NPC1_Text_Next = "";
    public Button NPC1_X_Btn;
    public int NPC1_Btn_Count = 0;
    //NPC1_Text_First = "여기가 바로 가상 한성대학교?";
    //NPC1_Text.text = NPC1_Text_First.ToString();
    public void NPC1_Talk()
    {
        
        //NPC1_Btn.onClick.AddListener(NPC1_Btn_Count++);
        if (NPC1_Btn_Count >= 1)
        {
            NPC1_Text_Next = "너도 신기하지 않니?";
            NPC1_Text.text = NPC1_Text_Next.ToString();

        }
        else if (NPC1_Btn_Count == 0)
        {
            NPC1_Text.text = "여기가 바로 가상 한성대학교?";
            NPC1_Btn_Count++;
        }
        NPC1_X_Btn.onClick.AddListener(() => {
            NPC1_Btn_Count = 0;
            NPC1_Text_Next = "여기가 바로 가상 한성대학교?";
            NPC1_Text.text = NPC1_Text_Next.ToString();
        });
    }
    //NPC1 Talk 끝

    //NPC2 Talk
    public Text NPC2_Text;
    public Button NPC2_Btn;   
    public Button NPC2_X_Btn;
    public string NPC2_Text_Next = "";
    public int NPC2_Btn_Count = 0;
    
    public void NPC2_Talk()
    {
        
        //NPC2_Btn.onClick.AddListener(NPC2_Btn_Count++);
        if (NPC2_Btn_Count >= 1)
        {
            NPC2_Text_Next = "아직까진 날이 춥구나.. (덜덜)";
            NPC2_Text.text = NPC2_Text_Next.ToString();

        }
        else if(NPC2_Btn_Count == 0)
        {
            NPC2_Text.text = "멋 좀 내려고 한 껏 차려입고 왔는데";
            NPC2_Btn_Count++;
        }
        NPC2_X_Btn.onClick.AddListener(() => {
            NPC2_Btn_Count = 0;
            NPC2_Text_Next = "멋 좀 내려고 한 껏 차려입고 왔는데";
            NPC2_Text.text = NPC2_Text_Next.ToString();
        });
    }
    //NPC2 Talk 끝

    //NPC3 Talk
    public Text NPC3_Text;
    public Button NPC3_Btn;
    public Button NPC3_X_Btn;
    public string NPC3_Text_Next = "";
    public int NPC3_Btn_Count = 0;

    public void NPC3_Talk()
    {
        switch (NPC3_Btn_Count)
        {
            case 0:
                NPC3_Text.text = "저기요 혹시 길 좀 물어봐도 될까요?";
                NPC3_Btn_Count++;
                break;
            case 1:
                NPC3_Text_Next = "상상파크가 어디에 있나요?";
                NPC3_Text.text = NPC3_Text_Next.ToString();
                NPC3_Btn_Count++;
                break;
            case 2:
                NPC3_Text_Next = "아~ 연구관 1층이요? 감사합니다!";
                NPC3_Text.text = NPC3_Text_Next.ToString();
                NPC3_Btn_Count++;
                break;
        }
        //NPC2_Btn.onClick.AddListener(NPC2_Btn_Count++);
        /*if (NPC2_Btn_Count >= 1)
        {
            NPC2_Text_Next = "아직까진 날이 춥구나.. (덜덜)";
            NPC2_Text.text = NPC2_Text_Next.ToString();

        }
        else if (NPC2_Btn_Count == 0)
        {
            NPC2_Text.text = "멋 좀 내려고 한 껏 차려입고 왔는데";
            NPC2_Btn_Count++;
        }*/
        NPC3_X_Btn.onClick.AddListener(() => {
            NPC3_Btn_Count = 0;
            NPC3_Text_Next = "저기요 혹시 길 좀 물어봐도 될까요?";
            NPC3_Text.text = NPC3_Text_Next.ToString();
        });
    }
    //NPC3 Talk 끝

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
