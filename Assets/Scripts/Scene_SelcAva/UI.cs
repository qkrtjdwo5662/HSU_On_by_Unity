using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Transform character;

    public float y;
    //public Button btnLeft, btnRight, btnNext;
    private bool isClick;

    public enum BtnType { Left, Right, Next }
    public BtnType btnType;

    //Animator animator;
    void Start()
    {
        
       //animator = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            
        }
    }

   /* void BtnLeftDown() 
    {
        y -= 10;
        character.rotation = Quaternion.Euler(0, y, 0);
        Debug.Log("left");
    }
    void BtnRightDown()
    {
        y += 10;
        character.rotation = Quaternion.Euler(0, y, 0);
        Debug.Log("Right");
    }
    void BtnNextDown()
    {
        Debug.Log("Next");
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        
        switch (btnType)
        {
            case BtnType.Left:
                
                character.transform.rotation = Quaternion.Euler(0, y-=10 , 0);
                Debug.Log("left " + y);
                break;
            case BtnType.Right:
                
                character.transform.rotation = Quaternion.Euler(0, y+=10 , 0);
                Debug.Log("Right " + y);
                break;
            case BtnType.Next:
                Debug.Log("Next");
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       /* switch (btnType)
        {
            case BtnType.Left:
                y -= 10;
                character.rotation = Quaternion.Euler(0, y, 0);
                Debug.Log("left");
                break;
            case BtnType.Right:
                y += 10;
                character.rotation = Quaternion.Euler(0, y, 0);
                Debug.Log("Right");
                break;
            case BtnType.Next:
                Debug.Log("Next");
                break;
        }*/
    }
}
