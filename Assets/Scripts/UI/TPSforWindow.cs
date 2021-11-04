using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TPSforWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    [SerializeField]
    public float movingSpeed = 2.5f;

    [SerializeField]
    private GameObject character;

    private bool isJump;
    private bool escCool = true, enterCool = true;

    float jumpStart = 0.0f, jumpFinish = 0.8f;
    float escStart = 0.0f, escFinish = 0.25f;
    float enterStart = 0.0f, enterFinish = 0.25f;

    bool SetMouseMod = true;
    float camTurnSpeed = 2.0f;

    private float xRotate = 0.0f; 

    PhotonView PV;
    public InputField input;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        animator = characterBody.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine && SetMouseMod)
        {
            Vector2 moveInput = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(cameraArm.forward * movingSpeed * Time.deltaTime, Space.World);
                animator.SetBool("isMove",true);
                moveInput += Vector2.up;
               
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(cameraArm.forward * -movingSpeed * Time.deltaTime, Space.World);
                animator.SetBool("isMove", true);
                moveInput += Vector2.down;

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(cameraArm.right * movingSpeed * Time.deltaTime, Space.World);
                animator.SetBool("isMove", true);
                moveInput += Vector2.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(cameraArm.right * -movingSpeed * Time.deltaTime, Space.World);
                animator.SetBool("isMove", true);
                moveInput += Vector2.left;

            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                movingSpeed = 5.0f;
                animator.SetBool("isRun",true);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
                animator.SetBool("isMove", false);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                movingSpeed = 2.5f;
                animator.SetBool("isRun", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (isJump == false)
                {
                    isJump = true;
                    animator.SetBool("isJump", true);
                    character.GetComponent<Rigidbody>().AddForce(0, 0.03f, 0);

                }
            }
            if (animator.GetBool("isMove")) {
                Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
                // 카메라의 오른쪽 방향
                Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
                // 이동 방향
                Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

                // 이동할 때 카메라가 보는 방향 바라보기
                characterBody.forward = lookForward;
                // 이동할 때 이동 방향 바라보기
                characterBody.forward = moveDir;

                // 이동
                transform.position += moveDir * Time.deltaTime * movingSpeed;
            }
            Vision();
        }

        
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //_ = (SetMouseMod == true) ? SetMouseMod = false : SetMouseMod = true;
            SetMouseMod = false;
            Cursor.visible = true;


        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            //_ = (SetMouseMod == true) ? SetMouseMod = false : SetMouseMod = true;
            SetMouseMod = true;
            Cursor.visible = false;

        }
        /*if (Input.GetKey(KeyCode.Escape) && escCool)
        {
            if (SetMouseMod == true)
            {
                SetMouseMod = false;
                Cursor.visible = true;
               
            }
            else {
                SetMouseMod = true;
                Cursor.visible = false;
               
            }

        }
        */
        

        if (Input.GetKey(KeyCode.Return) && enterCool)
        {
            
                //input.ActivateInputField();
                //Cursor.visible = false;
                //input.DeactivateInputField();
            
        }

        if (isJump == true)
        {
            if (jumpStart >= jumpFinish)
            {
                isJump = false;
                animator.SetBool("isJump", false);
                jumpStart = 0.0f;
            }
            jumpStart += Time.deltaTime;
        }
        if (enterCool == false)
        {
            if (enterStart >= enterFinish)
            {
                enterCool = true;
                enterStart = 0.0f;
            }
            enterStart += Time.deltaTime;
        }
        if (escCool == false)
        {
            if (escStart >= escFinish)
            {
                escCool = true;
                escStart = 0.0f;
            }
            escStart += Time.deltaTime;
        }

    }
    void Vision() 
    {
        float yRotateSize = Input.GetAxis("Mouse X") * camTurnSpeed;
        float yRotate = cameraArm.transform.eulerAngles.y + yRotateSize;    
        float xRotateSize = -Input.GetAxis("Mouse Y") * camTurnSpeed;
            
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -15, 80);
        cameraArm.transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        
    }

    
}
