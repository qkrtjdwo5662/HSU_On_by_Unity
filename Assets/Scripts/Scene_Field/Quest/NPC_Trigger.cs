using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject MainNpcTalk;
    
   

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {
           
            Dialog.SetActive(true);
            MainNpcTalk.SetActive(true);
        }
			
	}
	

   
    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Dialog.SetActive(false);
        MainNpcTalk.SetActive(false);
    }
}

