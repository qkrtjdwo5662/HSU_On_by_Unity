using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject NpcTalk;
    public Image Talk1;
    public GameObject NpcTalkSub;
    public Button YES_Button;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NpcTalk.SetActive(true);
            NpcTalkSub.SetActive(false);
            Talk1.gameObject.SetActive(true);
        }
    }

    public void YesButtonClick()
    {
        Talk1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        //NpcTalk.SetActive(false);
        //NpcTalkSub.SetActive(false);
    }
}

