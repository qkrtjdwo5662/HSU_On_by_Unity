using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash_Jinli : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scene_Jinli1");
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {

    }
}

