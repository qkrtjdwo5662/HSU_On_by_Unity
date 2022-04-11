using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.IO; //path사용을위해

public class TPSCharacterController : MonoBehaviour
{
    private Join join;

    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    [SerializeField]
    public float movingSpeed = 3.0f;

    [SerializeField]
    private GameObject character;

    [SerializeField]
    private CapsuleCollider hammer_head;

    [SerializeField]
    private GameObject hammer;

    Rigidbody rb;
    PhotonView PV;

    public Vector3 movingDirection;

    public Animator animator;
    public Button escButton;
    public Button attackButton;

    public SkinnedMeshRenderer characterModel;

    float time = 0.0f;

    [SerializeField]
    AudioSource audioSourceWalk;

    [SerializeField]
    AudioSource audioSourceRun;
    bool audioFlagWalk = false;
    bool audioFlagRun = false;
    public bool moveSwitch = true;


    public Scene_Character_Setting scs;

    public GameObject Bomb;

    public ChangeMask CM;

    public Texture HC01, HC11, HC21, HC31, HC41, HC51, HC61;
    public Texture HC02, HC12, HC22, HC32, HC42, HC52, HC62;
    public Texture HC03, HC13, HC23, HC33, HC43, HC53, HC63;
    public Texture HC04, HC14, HC24, HC34, HC44, HC54, HC64;
    public Texture HC05, HC15, HC25, HC35, HC45, HC55, HC65;
    public Texture HC06, HC16, HC26, HC36, HC46, HC56, HC66;
    public Texture HC07, HC17, HC27, HC37, HC47, HC57, HC67;
    public Texture HC08, HC18, HC28, HC38, HC48, HC58, HC68;
    public Texture HC09, HC19, HC29, HC39, HC49, HC59, HC69;
    public Texture HC10, HC20, HC30, HC40, HC50, HC60, HC70;
    // 머리색 끝

    // 상의 
    public Texture C01, C02, C03, C04, C05, C06, C07, C08, C09, C10;

    // 상의 끝

    // 하의
    public Texture P01, P02, P03, P04, P05, P06, P07, P08, P09, P10;

    public bool isBomb = false;


    private EventInstance e;

    // Start is called before the first frame update
    void Awake()
    {
        rb = characterBody.GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            this.name = "Me";
        }
        else if (!PV.IsMine)
        {
            this.name = "OtherPlayer";
            
        }
    }

    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
        escButton = GameObject.Find("UI").transform.Find("Menu_Set").gameObject.transform.Find("Image").gameObject.transform.Find("Reset_Button").gameObject.GetComponent<Button>();
        escButton.onClick.AddListener(escAction);
        attackButton = GameObject.Find("Canvas").transform.Find("AttackButton").GetComponent<Button>();
        attackButton.onClick.AddListener(AttackAction);
        e = GameObject.Find("EnvironmentManager").GetComponent<EventInstance>();
        join = GameObject.Find("Join").GetComponent<Join>();
        join.PVID = PV.ViewID;
        audioSourceWalk.mute = false;
        audioSourceWalk.loop = true;
        audioSourceRun.mute = false;
        audioSourceRun.loop = true;

        scs = GameObject.Find("ItemManager").GetComponent<Scene_Character_Setting>();

        if (PV.IsMine)
        {
            CallChangeMyAvatar(scs.hairColor, scs.top, scs.bottom);
        }//ChangeMyAvatar(scs.hairColor, scs.top, scs.bottom);
    }

    private void escAction()
    {
        transform.position = new Vector3(83f, 3f, 21f);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("attack1"))
        {
            moveSwitch = false;
            time += Time.deltaTime;
            if (time >= 0.3f && time <= 0.4f)
            {
                hammer_head.enabled = true;
            }
            else if (time >= 0.8f && time <= 0.9f)
            {
                hammer_head.enabled = false;
            }
            else if (time >= 1.0f)
            {

                animator.SetBool("attack1", false);
                moveSwitch = true;
                time = 0.0f;
            }
        }
    }

    void PlayAudioWalk() 
    {
        audioFlagRun = false;
        if (!audioFlagWalk && !animator.GetBool("isRun") && !animator.GetBool("isJump"))
        {
            audioSourceRun.Stop();
            audioSourceWalk.Play();
        }
        
        audioFlagWalk = true;
    }
    void PlayAudioRun()
    {
        audioFlagWalk = false;
        if (!audioFlagRun && animator.GetBool("isRun") && !animator.GetBool("isJump"))
        {
            audioSourceWalk.Stop();
            audioSourceRun.Play();
        }
        audioFlagRun = true;
    }
    public void Move(Vector2 inputDirection)
    {
        if (!PV.IsMine)
            return;
        // 이동 방향 구하기 1
        //Debug.DrawRay(cameraArm.position, cameraArm.forward, Color.red);

        // 이동 방향 구하기 2
        //Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);

        // 이동 방향키 입력 값 가져오기
        Vector2 moveInput = inputDirection;
        // 이동 방향키 입력 판정 : 이동 방향 벡터가 0보다 크면 입력이 발생하고 있는 중
        bool isMove = moveInput.magnitude != 0;
        bool isRun = movingSpeed >= 5;
        // 입력이 발생하는 중이라면 이동 애니메이션 재생
        animator.SetBool("isMove", isMove);
        animator.SetBool("isRun", isRun);
        if (isMove && moveSwitch)
        {
            if (animator.GetBool("conversation") || animator.GetBool("dance") || animator.GetBool("lose") || animator.GetBool("victory") || animator.GetBool("yes") || animator.GetBool("no")) {
                CM.AlloffMaskRPC();
                animator.SetBool("conversation", false);
                animator.SetBool("dance", false);
                animator.SetBool("victory", false);
                animator.SetBool("lose", false);
                animator.SetBool("yes", false);
                animator.SetBool("no", false);
            }
            time = 0.0f;
            animator.SetBool("attack1", false);




            
            // 카메라가 바라보는 방향
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            // 카메라의 오른쪽 방향
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // 이동 방향
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            movingDirection = moveDir.normalized;
            // 이동할 때 카메라가 보는 방향 바라보기
            characterBody.forward = lookForward;
            // 이동할 때 이동 방향 바라보기
            characterBody.forward = moveDir;
            if (!isRun) PlayAudioWalk();
            else PlayAudioRun();
            // 이동
            transform.position += moveDir.normalized * Time.deltaTime * movingSpeed;
            
            

        }
        else if (!isMove || !moveSwitch)
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isMove", false);
            movingDirection = Vector3.zero;
            audioFlagRun = false;
            audioFlagWalk = false;
            audioSourceWalk.Stop();
            audioSourceRun.Stop();
        }
        
    }

    public void LookAround(Vector3 inputDirection)
    {
        // 마우스 이동 값 검출
        Vector2 mouseDelta = inputDirection;
        // 카메라의 원래 각도를 오일러 각으로 저장
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        // 카메라의 피치 값 계산
        float x = camAngle.x - mouseDelta.y;

        // 카메라 피치 값을 위쪽으로 60도 아래쪽으로 25도 이상 움직이지 못하게 제한
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 60f);
        }
        else
        {
            x = Mathf.Clamp(x, 345f, 361f);
        }

        // 카메라 암 회전 시키기
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
    private void AttackAction()
    {
        if (!animator.GetBool("attack1")) 
        {
            animator.SetBool("attack1", true);

        }
    }

    public void ActivateHammerRPC()
    {
        PV.RPC("ActivateHammer", RpcTarget.AllBuffered);
    }
    public void DeactivateHammerRPC()
    {
        PV.RPC("DeactivateHammer", RpcTarget.AllBuffered);

    }
    [PunRPC]
    public void ActivateHammer()
    {
        hammer.SetActive(true);
    }
    [PunRPC]
    public void DeactivateHammer()
    {
        hammer.SetActive(false);
    }


    public void CallChangeMyAvatar(string hair, string top, string bottom) 
    {
        PV.RPC("ChangeMyAvatar",RpcTarget.AllBuffered, hair, top, bottom);
    }

    public Texture getHairColor(string hair)
    {
        switch (hair)
        {
            case "HC01":
                return HC01;
            case "HC02":
                return HC02;
            case "HC03":
                return HC03;
            case "HC04":
                return HC04;
            case "HC05":
                return HC05;
            case "HC06":
                return HC06;
            case "HC07":
                return HC07;
            case "HC08":
                return HC08;
            case "HC09":
                return HC09;
            case "HC10":
                return HC10;
            case "HC11":
                return HC11;
            case "HC12":
                return HC12;
            case "HC13":
                return HC13;
            case "HC14":
                return HC14;
            case "HC15":
                return HC15;
            case "HC16":
                return HC16;
            case "HC17":
                return HC17;
            case "HC18":
                return HC18;
            case "HC19":
                return HC19;
            case "HC20":
                return HC20;
            case "HC21":
                return HC21;
            case "HC22":
                return HC22;
            case "HC23":
                return HC23;
            case "HC24":
                return HC24;
            case "HC25":
                return HC25;
            case "HC26":
                return HC26;
            case "HC27":
                return HC27;
            case "HC28":
                return HC28;
            case "HC29":
                return HC29;
            case "HC30":
                return HC30;
            case "HC31":
                return HC31;
            case "HC32":
                return HC32;
            case "HC33":
                return HC33;
            case "HC34":
                return HC34;
            case "HC35":
                return HC35;
            case "HC36":
                return HC36;
            case "HC37":
                return HC37;
            case "HC38":
                return HC38;
            case "HC39":
                return HC39;
            case "HC40":
                return HC40;
            case "HC41":
                return HC41;
            case "HC42":
                return HC42;
            case "HC43":
                return HC43;
            case "HC44":
                return HC44;
            case "HC45":
                return HC45;
            case "HC46":
                return HC46;
            case "HC47":
                return HC47;
            case "HC48":
                return HC48;
            case "HC49":
                return HC49;
            case "HC50":
                return HC50;
            case "HC51":
                return HC51;
            case "HC52":
                return HC52;
            case "HC53":
                return HC53;
            case "HC54":
                return HC54;
            case "HC55":
                return HC55;
            case "HC56":
                return HC56;
            case "HC57":
                return HC57;
            case "HC58":
                return HC58;
            case "HC59":
                return HC59;
            case "HC60":
                return HC60;
            case "HC61":
                return HC61;
            case "HC62":
                return HC62;
            case "HC63":
                return HC63;
            case "HC64":
                return HC64;
            case "HC65":
                return HC65;
            case "HC66":
                return HC66;
            case "HC67":
                return HC67;
            case "HC68":
                return HC68;
            case "HC69":
                return HC69;
            case "HC70":
                return HC70;
            default:
                return null;
        }

    }
    public Texture getTop(string top)
    {
        switch (top)
        {
            case "C01":
                return C01;
            case "C02":
                return C02;
            case "C03":
                return C03;
            case "C04":
                return C04;
            case "C05":
                return C05;
            case "C06":
                return C06;
            case "C07":
                return C07;
            case "C08":
                return C08;
            case "C09":
                return C09;
            case "C10":
                return C10;
            default:
                return null;
        }
    }
    public Texture getBottom(string bottom)
    {
        switch (bottom)
        {
            case "P01":
                return P01;
            case "P02":
                return P02;
            case "P03":
                return P03;
            case "P04":
                return P04;
            case "P05":
                return P05;
            case "P06":
                return P06;
            case "P07":
                return P07;
            case "P08":
                return P08;
            case "P09":
                return P09;
            case "P10":
                return P10;
            default:
                return null;
        }
    }

    [PunRPC]
    public void ChangeMyAvatar(string hair, string top, string bottom)
    {
        Debug.Log(hair+top+bottom);
        if (!(hair==null))
            characterModel.materials[2].SetTexture("_MainTex",getHairColor(hair));
        if (!(top == null))
            characterModel.materials[0].SetTexture("_MainTex", getTop(top));
        if (!(bottom == null))
            characterModel.materials[1].SetTexture("_MainTex", getBottom(bottom));
    }
    public void WearBombRPC(string nickname) {
        PV.RPC("WearBomb", RpcTarget.AllBuffered, nickname);
    }
    
    public void TakeOffBombRPC(string nickname) {
        PV.RPC("TakeOffBomb", RpcTarget.AllBuffered, nickname);
    }



    [PunRPC]
    public void WearBomb(string nickname) {
        if (PV.Owner.NickName == nickname) {
            Bomb.SetActive(true);
            isBomb = true;
            e.event2Timer = 5.0f;
        }

    }
   
    [PunRPC]
    public void TakeOffBomb(string nickname)
    {
        if (PV.Owner.NickName == nickname)
        {
            Bomb.SetActive(false);
            isBomb = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player" && isBomb)
        {
            Debug.Log("폭탄 옮기기");
            PV.RPC("TakeOffBomb", RpcTarget.AllBuffered, PhotonNetwork.NickName);
            other.gameObject.GetComponent<TPSCharacterController>().WearBombRPC(
                other.gameObject.GetComponent<PhotonView>().Owner.NickName
                );
            //e.orderBomb(other.name);

        }
    }


}
