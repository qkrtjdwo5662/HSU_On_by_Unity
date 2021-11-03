using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunSpeedControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private TPSCharacterController controller;

    private GameObject Character;
    public void OnPointerDown(PointerEventData eventData)
    {
        controller.movingSpeed = 5.0f;
       
        Debug.Log("ButtonDown" + controller.movingSpeed);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        controller.movingSpeed = 2.5f;
        
        
    }

    // Start is called before the first frame update


    void Awake() 
    {
        

    }

    void Start()
    {
        /*
        if (Character = GameObject.Find("Boy(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Girl(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Boy2(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Girl2(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Boy3(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Girl3(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Boy4(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Girl4(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Boy5(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Girl5(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Bono(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Ghost(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        if (Character = GameObject.Find("Dora(Clone)"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }
        */
        //Character = GameObject.Find("Character(Clone)");
        //controller = Character.GetComponent<TPSCharacterController>();
        if (Character = GameObject.Find("Male1"))
        {
            controller = Character.GetComponent<TPSCharacterController>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
