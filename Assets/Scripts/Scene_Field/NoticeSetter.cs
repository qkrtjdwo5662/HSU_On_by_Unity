using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeSetter : MonoBehaviour
{
    public Text headLine;
    public Text notice;
    public Text noticeDate;

    public noticeSaver ns;
    // Start is called before the first frame update
    void Start()
    {
        ns = GameObject.Find("noticeSaver").GetComponent<noticeSaver>();
        headLine.text = ns.headLine;
        notice.text = ns.notice;
        noticeDate.text = ns.noticeDate;
    }

    // Update is called once per frame
    
}
