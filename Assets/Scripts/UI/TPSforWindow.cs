using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float start = 0.0f, finish = 0.8f;

    PhotonView PV;

    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
       
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        animator = characterBody.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            Vector2 moveInput = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(cameraArm.forward * movingSpeed * Time.deltaTime);
                animator.SetBool("isMove",true);
                moveInput += Vector2.up;
               
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(cameraArm.forward * -movingSpeed * Time.deltaTime);
                animator.SetBool("isMove", true);
                moveInput += Vector2.down;

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(cameraArm.right * movingSpeed * Time.deltaTime);
                animator.SetBool("isMove", true);
                moveInput += Vector2.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(cameraArm.right * -movingSpeed * Time.deltaTime);
                animator.SetBool("isMove", true);
                moveInput += Vector2.left;

            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                movingSpeed = 5f;
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
                    character.GetComponent<Rigidbody>().AddForce(0, 0.02f, 0);

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

        }

        if (isJump == true)
        {
            if (start >= finish)
            {
                isJump = false;
                start = 0.0f;
            }
            start += Time.deltaTime;
        }

    }

  

}
