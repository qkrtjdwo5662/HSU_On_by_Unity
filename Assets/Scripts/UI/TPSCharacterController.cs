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


    private Scene_Character_Setting scs;

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

        join = GameObject.Find("Join").GetComponent<Join>();
        join.PVID = PV.ViewID;
        audioSourceWalk.mute = false;
        audioSourceWalk.loop = true;
        audioSourceRun.mute = false;
        audioSourceRun.loop = true;

        

        PhotonNetwork.Instantiate(Path.Combine("Prefabs",scs.pet),(this.gameObject.GetComponent<Transform>().position+ new Vector3(2,0,2)),Quaternion.identity,0);

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

    void PlayAudioWalk() {

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
            time = 0.0f;
            animator.SetBool("conversation", false);
            animator.SetBool("dance", false);
            animator.SetBool("victory", false);
            animator.SetBool("lose", false);
            animator.SetBool("yes", false);
            animator.SetBool("no", false);
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


    public void CallChangeMyAvatar(Texture hair, Texture top, Texture bottom) 
    {
        PV.RPC("ChangeMyAvatar",RpcTarget.AllBuffered, hair, top, bottom);
    }

    [PunRPC]
    public void ChangeMyAvatar(Texture hair, Texture top, Texture bottom)
    {
        characterModel.materials[2].SetTexture("_MainTex",hair);
        characterModel.materials[0].SetTexture("_MainTex", top);
        characterModel.materials[1].SetTexture("_MainTex", bottom);
    }
}
