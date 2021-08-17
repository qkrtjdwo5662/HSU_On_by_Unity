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


    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Jump() {
        /*for (int i = 0; i < 10; i++)
        {
            Character.position += new Vector3(0, 0.1f, 0);
        }*/


        Character.position += new Vector3(0, 1, 0);
    }
}
