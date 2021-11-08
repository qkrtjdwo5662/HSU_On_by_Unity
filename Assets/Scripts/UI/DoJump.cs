using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoJump : MonoBehaviour
{
    [SerializeField]
    private Transform Character;
    [SerializeField]
    private Button btn;
    private bool isJump;
    float start = 0.0f, finish = 0.8f;


    private GameObject Cha;
    private TPSCharacterController controller;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        btn.onClick.AddListener(Jump);
        
        if (Cha = GameObject.Find("Male1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male1_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male2(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male2_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male3(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male3_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male4(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Male4_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female1_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female3(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female3_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female4(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }
        if (Cha = GameObject.Find("Female4_1(Clone)"))
        {
            Character = Cha.GetComponent<Transform>();
            controller = Cha.GetComponent<TPSCharacterController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isJump == true) {
            if (start >= finish) {
                isJump = false;
                controller.animator.SetBool("isJump", false);
                start = 0.0f;
            }

            start += Time.deltaTime;
        } 
    }

    private void Jump() {
       

        if (isJump == false)
        {
            isJump = true;
            controller.animator.SetBool("isJump", true);
            Character.GetComponent<Rigidbody>().AddForce(0, 0.03f, 0);
            
        }
    }
    



    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            isJump = false;    //Ground에 닿으면 isGround는 true
        }

    }
    
}
