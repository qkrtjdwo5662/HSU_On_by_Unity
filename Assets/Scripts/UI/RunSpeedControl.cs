using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunSpeedControl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private TPSCharacterController controller;

    public void OnPointerDown(PointerEventData eventData)
    {
        controller.movingSpeed = 10f;
        Debug.Log("ButtonDown" + controller.movingSpeed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        controller.movingSpeed = 5f;
        Debug.Log("ButtonUp" + controller.movingSpeed);
    }

    // Start is called before the first frame update




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
