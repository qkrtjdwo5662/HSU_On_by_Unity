using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crash_Object : MonoBehaviour
{
    public GameObject Image;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Image.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Image.SetActive(false);
    }
}

