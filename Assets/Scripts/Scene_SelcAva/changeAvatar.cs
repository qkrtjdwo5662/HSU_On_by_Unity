using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeAvatar : MonoBehaviour
{
    public GameObject character;
    public Button btn;
    public Sprite body1;
    public Sprite body2;
    public Sprite body3;
    public Sprite body4;
    public Sprite body5;
    public Sprite leftarm1;
    public Sprite leftarm2;
    public Sprite leftarm3;
    public Sprite leftarm4;
    public Sprite leftarm5;
    public Sprite leftarm6;
    public Sprite rightarm1;
    public Sprite rightarm2;
    public Sprite rightarm3;
    public Sprite rightarm4;
    public Sprite rightarm5;
    public Sprite rightarm6;
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
        GameObject body_1 = GameObject.Find("body_1");
        GameObject body_2 = GameObject.Find("body_2");
        GameObject body_3 = GameObject.Find("body_3");
        GameObject body_4 = GameObject.Find("body_4");
        GameObject body_5 = GameObject.Find("body_5");
        GameObject leftarm_1 = GameObject.Find("leftArm_1");
        GameObject leftarm_2 = GameObject.Find("leftArm_2");
        GameObject leftarm_3 = GameObject.Find("leftArm_3");
        GameObject leftarm_4 = GameObject.Find("leftArm_4");
        GameObject leftarm_5 = GameObject.Find("leftArm_5");
        GameObject leftarm_6 = GameObject.Find("leftArm_6");
        GameObject rightarm_1 = GameObject.Find("rightArm_1");
        GameObject rightarm_2 = GameObject.Find("rightArm_2");
        GameObject rightarm_3 = GameObject.Find("rightArm_3");
        GameObject rightarm_4 = GameObject.Find("rightArm_4");
        GameObject rightarm_5 = GameObject.Find("rightArm_5");
        GameObject rightarm_6 = GameObject.Find("rightArm_6");


        //body_1.GetComponent<Image>().sprite = Resources.Load("Assets/Resources/avatar/body/GwaJam/body_1.png") as Sprite;
        body_1.GetComponent<SpriteRenderer>().sprite = body1;
        body_2.GetComponent<SpriteRenderer>().sprite = body2;
        body_3.GetComponent<SpriteRenderer>().sprite = body3;
        body_4.GetComponent<SpriteRenderer>().sprite = body4;
        body_5.GetComponent<SpriteRenderer>().sprite = body5;
        leftarm_1.GetComponent<SpriteRenderer>().sprite = leftarm1;
        leftarm_2.GetComponent<SpriteRenderer>().sprite = leftarm2;
        leftarm_3.GetComponent<SpriteRenderer>().sprite = leftarm3;
        leftarm_4.GetComponent<SpriteRenderer>().sprite = leftarm4;
        leftarm_5.GetComponent<SpriteRenderer>().sprite = leftarm5;
        leftarm_6.GetComponent<SpriteRenderer>().sprite = leftarm6;
        rightarm_1.GetComponent<SpriteRenderer>().sprite = rightarm1;
        rightarm_2.GetComponent<SpriteRenderer>().sprite = rightarm2;
        rightarm_3.GetComponent<SpriteRenderer>().sprite = rightarm3;
        rightarm_4.GetComponent<SpriteRenderer>().sprite = rightarm4;
        rightarm_5.GetComponent<SpriteRenderer>().sprite = rightarm5;
        rightarm_6.GetComponent<SpriteRenderer>().sprite = rightarm6;
        Debug.Log("GwajamChange");
    }
}
