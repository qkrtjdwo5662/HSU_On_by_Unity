using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject NpcTalk;
    public GameObject NpcTalkSub;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NpcTalk.SetActive(true);
            NpcTalkSub.SetActive(false);
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        //NpcTalk.SetActive(false);
        //NpcTalkSub.SetActive(false);
    }
}

