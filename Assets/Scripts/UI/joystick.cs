using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class joystick : MonoBehaviourPunCallbacks, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField]
    float CaremaSpeed = 50;

    [SerializeField]
    private float leverRange;

    [SerializeField]
    private TPSCharacterController controller;

    [SerializeField]
    private GameObject canvas;

    private GameObject Character;

    public enum JoystickType { Move, Rotate }
    public JoystickType joystickType;
    private Vector2 inputDirection;
    private Vector2 before;
    private bool isInput;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //PV = GetComponent<PhotonView>();
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        switch (joystickType)
        {
            case JoystickType.Move:
                ControlJoystickLever(eventData);
                break;
            case JoystickType.Rotate:
                ControlCamera(eventData);
                break;
        }
        //ControlJoystickLever(eventData);
        //Debug.Log("Begin");
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        switch (joystickType)
        {
            case JoystickType.Move:
                ControlJoystickLever(eventData);
                break;
            case JoystickType.Rotate:
                ControlCamera(eventData);
                break;
        }
        //ControlJoystickLever(eventData);
        //Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        switch (joystickType)
        {
            case JoystickType.Move:
                controller.Move(Vector2.zero);
                break;
            case JoystickType.Rotate:
                controller.LookAround(Vector2.zero);
                break;
        }
        //Debug.Log("End");
    }

    private void ControlJoystickLever(PointerEventData eventData) {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }


    private void ControlCamera(PointerEventData eventData)
    {
        
        var inputPos = eventData.position - before;
        //var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputPos;
        inputDirection = inputPos / (leverRange / CaremaSpeed);
        before = eventData.position;
    }

    private void InputControlVector() {
        //controller.Move(inputDirection);

        switch (joystickType) {
            case JoystickType.Move:
                controller.Move(inputDirection);
                break;
            case JoystickType.Rotate:
                controller.LookAround(inputDirection);

                break;
        }

        //Debug.Log(inputDirection.x + "/" + inputDirection.y);
    }
    

    

    // Start is called before the first frame update
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
        else if (Character = GameObject.Find("Male2(Clone)"))
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
        //Character = GameObject.Find("Character(Clone)");
        //controller = Character.GetComponent<TPSCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        /*if (!PV.IsMine)
        {
            //canvas.SetActive(false);
            //Destroy(canvas);
        }
        else {
            if (isInput)
            {
                InputControlVector();
            }
        }*/
        if (isInput)
        {
            InputControlVector();
        }


    }
}
