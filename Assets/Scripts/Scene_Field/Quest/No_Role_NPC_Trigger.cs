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

    public GameObject NPC; // NPC


    private Button startBtn; //대화하기 버튼

    private GameObject CameraArm;
    private GameObject Me;
    private TPSCharacterController tps;

    public enum No_Role { NPC1_Talk, NPC2_Talk, NPC3_Talk, NPC4_Talk, NPC5_Talk, NPC6_Talk, NPC7_Talk, NPC8_Talk, NPC9_Talk, NPC10_Talk, NPC11_Talk, NPC12_Talk, NPC13_Talk, NPC14_Talk, NPC15_Talk
    , NPC16_Talk, NPC17_Talk, NPC18_Talk, NPC19_Talk, NPC20_Talk, NPC32_Talk }; // NPC 대화 열거형
    public No_Role NR;
    private void Start()
    {
        StartCoroutine(FindMe());
    }

    //NPC Talk
    public Text NPC_Text;
    public Button NPC_Btn;
    public string NPC_Text_Next = "";
    public Button NPC_X_Btn;
    public int NPC_Btn_Count = 0;

    public void NPC_Talk()
    {
        if (NR == No_Role.NPC1_Talk)
        {
            //NPC1_Btn.onClick.AddListener(NPC1_Btn_Count++);
            if (NPC_Btn_Count >= 1)
            {
                NPC_Text_Next = "너도 신기하지 않니?";
                NPC_Text.text = NPC_Text_Next.ToString();

            }
            else if (NPC_Btn_Count == 0)
            {
                NPC_Text.text = "여기가 바로 가상 한성대학교?";
                NPC_Btn_Count++;
            }
            NPC_X_Btn.onClick.AddListener(() =>
            {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "여기가 바로 가상 한성대학교?";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC2_Talk)
        {
            if (NPC_Btn_Count >= 1)
            {
                NPC_Text_Next = "아직까진 날이 춥구나.. (덜덜)";
                NPC_Text.text = NPC_Text_Next.ToString();

            }
            else if (NPC_Btn_Count == 0)
            {
                NPC_Text.text = "멋 좀 내려고 한 껏 차려입고 왔는데";
                NPC_Btn_Count++;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "멋 좀 내려고 한 껏 차려입고 왔는데";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC3_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "저기요 혹시 길 좀 물어봐도 될까요?";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "상상파크가 어디에 있나요?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
                case 2:
                    NPC_Text_Next = "아~ 연구관 1층이요? 감사합니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }

            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "저기요 혹시 길 좀 물어봐도 될까요?";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC4_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕? 만나서 반가워!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "나는 인사하는 NPC야!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕? 만나서 반가워!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC5_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "..나를 .. 따라서.. 신나게 춤을 ..";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "춰보자..(헉헉)";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "..나를 .. 따라서.. 신나게 춤을 ..";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC6_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "오예~ 한성대학교 메타버스 최고~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "코딩하는 쿼카 화이팅!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "오예~ 한성대학교 메타버스 최고~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC7_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "너도 춤에 관심있니??";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "그럼 날 따라해봐~~!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "너도 춤에 관심있니??";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC8_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "타닥..타닥타닥";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "나 코딩중이니까 방해하지 말아줄래?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "타닥..타닥타닥";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC9_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "우와 그라찌에 커피 완전 싸다~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "생과일 주스도 있네 뭐 마시지?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "우와 그라찌에 커피 완전 싸다~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC10_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "그라찌에에서 한번 주문해봐!!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "특별한 일이 일어날지도..?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "그라찌에에서 한번 주문해봐!!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC11_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "흐아암~ 배고픈데";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "배달은 언제오지...";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "흐아암~ 배고픈데";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC12_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "미션은 잘 해결하고 있어?";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "돌아다녀보면서 상상프렌즈를 만나봐~!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
                case 2:
                    NPC_Text_Next = "나는 아까 꼬꼬랑 친해졌어 ^_^";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "미션은 잘 해결하고 있어?";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC13_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "우와.. ROTC 멋있다";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "나도 입단할 수 있을까?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "우와.. ROTC 멋있다";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC14_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕하세요~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "저희는 이스터에그 NPC 개발자 NPC 입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
                case 2:
                    NPC_Text_Next = "저는 코딩하는 쿼카 팀장 황윤규입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕하세요~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC15_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕하세요~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "저는 컨텐츠 개발을 맡고 있는 심우호입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕하세요~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC16_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕하세요~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "저는 그래픽 디자인 개발을 맡고 있는 전희연입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕하세요~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC17_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕하세요~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "저는 데이터베이스 운영을 맡고 있는 박성재입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕하세요~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC18_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "안녕하세요~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "저는 프로그래밍 개발을 맡고 있는 임수빈입니다!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "안녕하세요~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC19_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "학군단 홍보라..";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "어떻게 하면 효율적으로 홍보할 수 있을까?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "학군단 홍보라..";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC20_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "나랑.. 같이..";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "학식 먹을 사람..?";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "나랑.. 같이..";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
        else if (NR == No_Role.NPC32_Talk)
        {
            switch (NPC_Btn_Count)
            {
                case 0:
                    NPC_Text.text = "상상부기 안녕~!";
                    NPC_Btn_Count++;
                    break;
                case 1:
                    NPC_Text_Next = "한성냥이도 안녕!!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
                case 2:
                    NPC_Text_Next = "꼬꼬랑 상찌도 안녕~~~!";
                    NPC_Text.text = NPC_Text_Next.ToString();
                    NPC_Btn_Count++;
                    break;
            }
            NPC_X_Btn.onClick.AddListener(() => {
                NPC_Btn_Count = 0;
                NPC_Text_Next = "상상부기 안녕~!";
                NPC_Text.text = NPC_Text_Next.ToString();
            });
        }
    }

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