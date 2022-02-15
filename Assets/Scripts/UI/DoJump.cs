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
    float start = 0.0f;


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

        switch (movingButton)
        {
            case MovingButton.Jump:
                btn.onClick.AddListener(Jump);
                break;

        }
        if (CharacterObject = GameObject.Find("Me"))
        {
            CharacterTransform = CharacterObject.GetComponent<Transform>();
            controller = CharacterObject.GetComponent<TPSCharacterController>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        switch (movingButton)
        {
            case MovingButton.Jump:
                if (isJump == true)
                {
                    start += Time.deltaTime;
                    if (start >= 1.0f)
                    {
                        isJump = false;
                        controller.animator.SetBool("isJump", false);
                        start = 0.0f;
                    }
                }
                break;
            case MovingButton.Run:
                break;
        }
    }

    private void Jump()
    {


        if (isJump == false)
        {
            isJump = true;
            controller.animator.SetBool("isJump", true);
            CharacterTransform.GetComponent<Rigidbody>().AddForce((controller.movingDirection.x) * 0.02f, 0.03f, (controller.movingDirection.z)*0.02f);

        }
    }



/*
    private void OnCollisionEnter(Collision col)
    {
        
                if (col.gameObject.tag == "ground")
                {
                    isJump = false;    //Ground에 닿으면 isGround는 true
                }
        
    }
*/
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (movingButton)
        {
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
