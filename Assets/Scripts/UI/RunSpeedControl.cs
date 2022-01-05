using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//-------------------------------------안씀-----------------------------------------//
public class RunSpeedControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private TPSCharacterController controller;

    private GameObject Character;
    public void OnPointerDown(PointerEventData eventData)
    {
        controller.movingSpeed = 6.0f;
       
        Debug.Log("ButtonDown" + controller.movingSpeed);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        controller.movingSpeed = 3.0f;
        
        
    }

    // Start is called before the first frame update


    void Awake() 
    {
        

    }

    void Start()
    {
        
        if (Character = GameObject.Find("Male1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male1_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if(Character = GameObject.Find("Male2(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male2_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male3(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male3_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male4(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Male4_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female1_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female3(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female3_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female4(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        else if (Character = GameObject.Find("Female4_1(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
