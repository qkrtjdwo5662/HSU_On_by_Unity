using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crash_Object : MonoBehaviour
{
    private Button btn;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {

    }
}

