using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Trigger : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject MainNpcTalk;
    public GameObject TalkStart;

    private Button startBtn; //대화하기 버튼
    


    private GameObject CameraArm;
    private GameObject Me;
    private TPSCharacterController tps;



    private void Start()
    {
        Me = GameObject.Find("Me");
       
        tps = Me.GetComponent<TPSCharacterController>();
        CameraArm = Me.transform.Find("Camera Arm").gameObject;
        startBtn = MainNpcTalk.transform.Find("Talk0").GetComponentInChildren<Button>();
        startBtn.onClick.AddListener(CameraWork);
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {
           
            Dialog.SetActive(true);
            MainNpcTalk.SetActive(true);
            if(!TalkStart.Equals(null))
                TalkStart.SetActive(true);
        }
			
	}
	

   
    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Dialog.SetActive(false);
        MainNpcTalk.SetActive(false);
        if (!TalkStart.Equals(null))
            TalkStart.SetActive(false);
        
    }

    private void CameraWork()
    {
        
        StartCoroutine(MoveTo(CameraArm, this.transform.position + Vector3.down*2));
    }
    public void CameraReturn() 
    {
        StartCoroutine(MoveTo(CameraArm, Me.transform.position));
    }

    IEnumerator MoveTo(GameObject obj, Vector3 destination)
    {
        tps.moveSwitch = false;
        float count = 0;
        Vector3 wasPos = obj.transform.position;

        while (true)
        {
            count += Time.deltaTime*2;
            obj.transform.position = Vector3.Lerp(wasPos, destination, count);
            

            if (count >= 1)
            {
                tps.moveSwitch = true;
                obj.transform.position = destination;
                break;
            }
            yield return null;
        }
    }

}

