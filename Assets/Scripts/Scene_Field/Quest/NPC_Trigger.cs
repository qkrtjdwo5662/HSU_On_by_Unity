using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject NpcTalk;
    public GameObject YesAfter;
    public GameObject NpcTalkSub;
    
    public Button YES_Button;
    //public Image Talk0;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NpcTalk.SetActive(true);
            NpcTalkSub.SetActive(false);
           
            YesAfter.SetActive(true);
            
        }
    }

    public void YesButtonClick()
    {
        
           //Talk0.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        NpcTalk.SetActive(false);
        NpcTalkSub.SetActive(false);
        YesAfter.SetActive(false);
    }
}

