using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LRButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private UI canvas;

    [SerializeField]
    private Transform character;



    private bool isClick;
    public enum BtnType { Left, Right, Next }
    public BtnType btnType;

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
        
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick) {
            switch (btnType)
            {
                case BtnType.Left:
                    
                    character.rotation = Quaternion.Euler(0, canvas.y+=2, 0);
                    
                    break;
                case BtnType.Right:
                    character.rotation = Quaternion.Euler(0, canvas.y-=2, 0);
                    
                    break;
                case BtnType.Next:
                    Debug.Log("NextButton is Click");
                    break;
            }
        }
    }
}
