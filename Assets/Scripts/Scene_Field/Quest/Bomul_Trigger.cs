using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomul_Trigger : MonoBehaviour
{
    public GameObject Bomul;
    public GameObject BomulSub;
  
    
   

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Bomul.SetActive(true);
            BomulSub.SetActive(true);
            
            
          
            
        }
    }

   
    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Bomul.SetActive(false);
        BomulSub.SetActive(false);
    }
}

