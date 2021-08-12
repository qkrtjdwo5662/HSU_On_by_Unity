using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeAvatar : MonoBehaviour
{
    public GameObject character;
    public Button btn;
    public Sprite img;
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
        //body_1.GetComponent<Image>().sprite = Resources.Load("avatar/body/GwaJam/body_1") as Sprite;
        body_1.GetComponent<Image>().sprite = img;
        Debug.Log("GwajamChange");
    }
}
