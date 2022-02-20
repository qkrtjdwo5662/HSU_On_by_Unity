using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTrigger : MonoBehaviour
{
    public PetAI petAI;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            petAI.getAnimator().SetBool("IsMove", true);
            petAI.getAnimator().SetBool("IsEat", false);
            
        }
    }

}
