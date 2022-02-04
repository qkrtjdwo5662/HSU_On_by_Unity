using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public ChickenAI chickenAI;
    private EventInstance e;

    private void Start()
    {
        e = GameObject.Find("EventManager").GetComponent<EventInstance>();
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            chickenAI.getAnimator().SetBool("Walk", false);
            chickenAI.getAnimator().SetBool("TurnHead", false);
            chickenAI.getAnimator().SetBool("Eat", false);
            chickenAI.getAnimator().SetBool("Run", true);
            chickenAI.getTransform().LookAt(2 * chickenAI.getTransform().position - other.gameObject.transform.position);
            chickenAI.setTime(0.0f);
        }
        else if (other.tag == "hammer") {
            e.hitchicken(other.GetComponent<PhotonView>().Owner.NickName,1);
            //Debug.Log(other.GetComponent<PhotonView>().Owner.NickName);
            var set = chickenAI.getTransform().gameObject.GetComponent<ParticleSystem>().emission;
            set.enabled = true;
            chickenAI.dead = true;
            chickenAI.setTime(0.0f);
            
            
        }
    }
}
