using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{

    public int Speed;

    Rigidbody rb;
    PhotonView PV;

    Vector3 movement;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            //내꺼 아니면 카메라 없애기
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h,v);
    }
    void Run(float h, float v) {
        //Debug.Log("keyBoard");
        movement.Set(h, 0, v);
        movement = movement.normalized * Speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Update()
	{
        if (!PV.IsMine)
            return;//내 것만 작동하기
	}
}
