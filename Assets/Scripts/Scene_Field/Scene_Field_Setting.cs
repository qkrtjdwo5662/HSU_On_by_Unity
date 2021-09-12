using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Field_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
        GameObject avatar = GameObject.Find("Avatar");
        if (avatar == null) {
            return;
        }
        GameObject head_1 = GameObject.Find("head_1");
        GameObject head_2 = GameObject.Find("head_2");
        GameObject head_3 = GameObject.Find("head_3");
        GameObject head_4 = GameObject.Find("head_4");
        GameObject head_5 = GameObject.Find("head_5");
        GameObject body_1 = GameObject.Find("body_1");
        GameObject body_2 = GameObject.Find("body_2");
        GameObject body_3 = GameObject.Find("body_3");
        GameObject body_4 = GameObject.Find("body_4");
        GameObject body_5 = GameObject.Find("body_5");
        GameObject leftArm_1 = GameObject.Find("leftArm_1");
        GameObject leftArm_2 = GameObject.Find("leftArm_2");
        GameObject leftArm_3 = GameObject.Find("leftArm_3");
        GameObject leftArm_4 = GameObject.Find("leftArm_4");
        GameObject leftArm_5 = GameObject.Find("leftArm_5");
        GameObject leftArm_6 = GameObject.Find("leftArm_6");
        GameObject rightArm_1 = GameObject.Find("rightArm_1");
        GameObject rightArm_2 = GameObject.Find("rightArm_2");
        GameObject rightArm_3 = GameObject.Find("rightArm_3");
        GameObject rightArm_4 = GameObject.Find("rightArm_4");
        GameObject rightArm_5 = GameObject.Find("rightArm_5");
        GameObject rightArm_6 = GameObject.Find("rightArm_6");

        GameObject head1 = GameObject.Find("head1");
        GameObject head2 = GameObject.Find("head2");
        GameObject head3 = GameObject.Find("head3");
        GameObject head4 = GameObject.Find("head4");
        GameObject head5 = GameObject.Find("head5");
        GameObject body1 = GameObject.Find("body1");
        GameObject body2 = GameObject.Find("body2");
        GameObject body3 = GameObject.Find("body3");
        GameObject body4 = GameObject.Find("body4");
        GameObject body5 = GameObject.Find("body5");
        GameObject leftArm1 = GameObject.Find("leftArm1");
        GameObject leftArm2 = GameObject.Find("leftArm2");
        GameObject leftArm3 = GameObject.Find("leftArm3");
        GameObject leftArm4 = GameObject.Find("leftArm4");
        GameObject leftArm5 = GameObject.Find("leftArm5");
        GameObject leftArm6 = GameObject.Find("leftArm6");
        GameObject rightArm1 = GameObject.Find("rightArm1");
        GameObject rightArm2 = GameObject.Find("rightArm2");
        GameObject rightArm3 = GameObject.Find("rightArm3");
        GameObject rightArm4 = GameObject.Find("rightArm4");
        GameObject rightArm5 = GameObject.Find("rightArm5");
        GameObject rightArm6 = GameObject.Find("rightArm6");

        head1.GetComponent<SpriteRenderer>().sprite = head_1.GetComponent<SpriteRenderer>().sprite;
        head2.GetComponent<SpriteRenderer>().sprite = head_2.GetComponent<SpriteRenderer>().sprite;
        head3.GetComponent<SpriteRenderer>().sprite = head_3.GetComponent<SpriteRenderer>().sprite;
        head4.GetComponent<SpriteRenderer>().sprite = head_4.GetComponent<SpriteRenderer>().sprite;
        head5.GetComponent<SpriteRenderer>().sprite = head_5.GetComponent<SpriteRenderer>().sprite;
        body1.GetComponent<SpriteRenderer>().sprite = body_1.GetComponent<SpriteRenderer>().sprite;
        body2.GetComponent<SpriteRenderer>().sprite = body_2.GetComponent<SpriteRenderer>().sprite;
        body3.GetComponent<SpriteRenderer>().sprite = body_3.GetComponent<SpriteRenderer>().sprite;
        body4.GetComponent<SpriteRenderer>().sprite = body_4.GetComponent<SpriteRenderer>().sprite;
        body5.GetComponent<SpriteRenderer>().sprite = body_5.GetComponent<SpriteRenderer>().sprite;
        leftArm1.GetComponent<SpriteRenderer>().sprite = leftArm_1.GetComponent<SpriteRenderer>().sprite;
        leftArm2.GetComponent<SpriteRenderer>().sprite = leftArm_2.GetComponent<SpriteRenderer>().sprite;
        leftArm3.GetComponent<SpriteRenderer>().sprite = leftArm_3.GetComponent<SpriteRenderer>().sprite;
        leftArm4.GetComponent<SpriteRenderer>().sprite = leftArm_4.GetComponent<SpriteRenderer>().sprite;
        leftArm5.GetComponent<SpriteRenderer>().sprite = leftArm_5.GetComponent<SpriteRenderer>().sprite;
        leftArm6.GetComponent<SpriteRenderer>().sprite = leftArm_6.GetComponent<SpriteRenderer>().sprite;
        rightArm1.GetComponent<SpriteRenderer>().sprite = rightArm_1.GetComponent<SpriteRenderer>().sprite;
        rightArm2.GetComponent<SpriteRenderer>().sprite = rightArm_2.GetComponent<SpriteRenderer>().sprite;
        rightArm3.GetComponent<SpriteRenderer>().sprite = rightArm_3.GetComponent<SpriteRenderer>().sprite;
        rightArm4.GetComponent<SpriteRenderer>().sprite = rightArm_4.GetComponent<SpriteRenderer>().sprite;
        rightArm5.GetComponent<SpriteRenderer>().sprite = rightArm_5.GetComponent<SpriteRenderer>().sprite;
        rightArm6.GetComponent<SpriteRenderer>().sprite = rightArm_6.GetComponent<SpriteRenderer>().sprite;

        //Destroy(avatar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
