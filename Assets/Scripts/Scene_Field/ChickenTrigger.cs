using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public ChickenAI chickenAI;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            chickenAI.getAnimator().SetBool("Walk", false);
            chickenAI.getAnimator().SetBool("TurnHead", false);
            chickenAI.getAnimator().SetBool("Eat", false);
            chickenAI.getAnimator().SetBool("Run", true);
            chickenAI.getTranskform().LookAt(2*chickenAI.getTranskform().position - other.gameObject.transform.position);
            chickenAI.setTime(0.0f);
            
        }
    }
}
