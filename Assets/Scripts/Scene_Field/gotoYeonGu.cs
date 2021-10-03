using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class gotoYeonGu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character;
    int cheak = 0;
    public Image im;
    private PhotonView PV;

    public float start = 0.0f;
    float finish = 2.1f;
    public bool fade = false;
    void Start()
    {
        if (Character = GameObject.Find("Boy(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Girl(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Boy2(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Girl2(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;

        }
        else if (Character = GameObject.Find("Boy3(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Girl3(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Boy4(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Girl4(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Boy5(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Girl5(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Bono(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Ghost(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
        else if (Character = GameObject.Find("Dora(Clone)"))
        {
            if (PV.IsMine)
                cheak = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            fade = true;
        }

    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {

    }
    private void Update()
    {

        if (fade == true)
        {
            if (start <= 1.0f)
            {
                im.color += new Color(0, 0, 0, Time.deltaTime);
            }
            else if (start > 1.0f && start < 1.1f)
            {
                Character.GetComponent<Transform>().position = new Vector3(-77.9f, 9.75f, 3.03f);
            }
            else if (start >= 1.1f && start <= finish)
            {
                im.color -= new Color(0, 0, 0, Time.deltaTime);
            }
            else if (start > finish)
            {
                start = 0.0f;
                fade = false;
            }
            start += Time.deltaTime;
        }

    }
}

