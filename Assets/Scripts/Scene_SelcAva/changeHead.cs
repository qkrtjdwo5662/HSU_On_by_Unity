using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeHead : MonoBehaviour
{
    public GameObject character;
    public Button btn;
    public Sprite head1;
    public Sprite head2;
    public Sprite head3;
    public Sprite head4;
    public Sprite head5;
    
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
        GameObject head_1 = GameObject.Find("head_1");
        GameObject head_2 = GameObject.Find("head_2");
        GameObject head_3 = GameObject.Find("head_3");
        GameObject head_4 = GameObject.Find("head_4");
        GameObject head_5 = GameObject.Find("head_5");




        //body_1.GetComponent<Image>().sprite = Resources.Load("Assets/Resources/avatar/body/GwaJam/body_1.png") as Sprite;
        head_1.GetComponent<SpriteRenderer>().sprite = head1;
        head_2.GetComponent<SpriteRenderer>().sprite = head2;
        head_3.GetComponent<SpriteRenderer>().sprite = head3;
        head_4.GetComponent<SpriteRenderer>().sprite = head4;
        head_5.GetComponent<SpriteRenderer>().sprite = head5;


        //Debug.Log("GwajamChange");
    }
}
