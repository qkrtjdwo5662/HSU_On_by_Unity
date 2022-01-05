using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoJump : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private Transform CharacterTransform;
    [SerializeField]
    private Button btn;
    private bool isJump;
    float start = 0.0f, finish = 0.8f;


    private GameObject CharacterObject;
    private TPSCharacterController controller;

    public enum MovingButton { Jump, Run };
    public MovingButton movingButton;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        switch (movingButton) {
            case MovingButton.Jump:
                btn.onClick.AddListener(Jump);
                break;

        }

        
        
        if (CharacterObject = GameObject.Find("Male1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male1_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male2(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male2_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male3(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male3_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male4(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Male4_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female1_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female3(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female3_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female4(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }
        else if (CharacterObject = GameObject.Find("Female4_1(Clone)"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (movingButton) {
            case MovingButton.Jump:
                if (isJump == true)
                {
                    if (start >= finish)
                    {
                        isJump = false;
                        controller.animator.SetBool("isJump", false);
                        start = 0.0f;
                    }

                    start += Time.deltaTime;
                }
                break;
            case MovingButton.Run:
                break;
        }
        

        /*
        if (isJump == true) {
            if (start >= finish) {
                isJump = false;
                controller.animator.SetBool("isJump", false);
                start = 0.0f;
            }

            start += Time.deltaTime;
        } */
    }

    private void Jump() {
       

        if (isJump == false)
        {
            isJump = true;
            controller.animator.SetBool("isJump", true);
            CharacterTransform.GetComponent<Rigidbody>().AddForce(0, 0.03f, 0);
            
        }
    }
    



    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            isJump = false;    //Ground에 닿으면 isGround는 true
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (movingButton) {
            case MovingButton.Run:
                controller.movingSpeed = 6.0f;
                Debug.Log("RunButtonDown" + controller.movingSpeed);
                break;

        }
        /*
        controller.movingSpeed = 6.0f;
        Debug.Log("ButtonDown" + controller.movingSpeed);
        */
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        switch (movingButton)
        {
            case MovingButton.Run:
                controller.movingSpeed = 3.0f;
                Debug.Log("RunButtonUp" + controller.movingSpeed);
                break;

        }
        


    }

}
