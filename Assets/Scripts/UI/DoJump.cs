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
    float y1, y2;

    private GameObject Cha;



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        btn.onClick.AddListener(Jump);
        Cha = GameObject.Find("Character(Clone)");
        Character = Cha.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Jump() {
       

        if (isJump == false)
        {
            //isJump = true;
            Character.GetComponent<Rigidbody>().AddForce(0, 0.02f, 0);
            
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
