using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePants : MonoBehaviour
{
    public GameObject character;
    public Button btn;
    
    public Sprite leftleg1;
    public Sprite leftleg2;
    public Sprite leftleg3;
    public Sprite leftleg4;
    public Sprite leftleg5;
    public Sprite leftled6;
    public Sprite rightleg1;
    public Sprite rightleg2;
    public Sprite rightleg3;
    public Sprite rightleg4;
    public Sprite rightleg5;
    public Sprite rightleg6;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(changeAva);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void changeAva()
    {
        
        GameObject leftleg_1 = GameObject.Find("leftLeg_1");
        GameObject leftleg_2 = GameObject.Find("leftLeg_2");
        GameObject leftleg_3 = GameObject.Find("leftLeg_3");
        GameObject leftleg_4 = GameObject.Find("leftLeg_4");

        GameObject rightleg_1 = GameObject.Find("rightLeg_1");
        GameObject rightleg_2 = GameObject.Find("rightLeg_2");
        GameObject rightleg_3 = GameObject.Find("rightLeg_3");
        GameObject rightleg_4 = GameObject.Find("rightLeg_4");



        //body_1.GetComponent<Image>().sprite = Resources.Load("Assets/Resources/avatar/body/GwaJam/body_1.png") as Sprite;

        leftleg_1.GetComponent<SpriteRenderer>().sprite = leftleg1;
        leftleg_2.GetComponent<SpriteRenderer>().sprite = leftleg2;
        leftleg_3.GetComponent<SpriteRenderer>().sprite = leftleg3;
        leftleg_4.GetComponent<SpriteRenderer>().sprite = leftleg4;

        rightleg_1.GetComponent<SpriteRenderer>().sprite = rightleg1;
        rightleg_2.GetComponent<SpriteRenderer>().sprite = rightleg2;
        rightleg_3.GetComponent<SpriteRenderer>().sprite = rightleg3;
        rightleg_4.GetComponent<SpriteRenderer>().sprite = rightleg4;

    }
}
