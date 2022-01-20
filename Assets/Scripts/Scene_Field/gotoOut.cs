using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class gotoOut : MonoBehaviour
{
    // Start is called before the first frame update


    //public Image im;

    bool go = false;

    public float start = 0.0f;
    float finish = 2.1f;
    public bool fade = false;

    void Start()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Transform>().position = new Vector3(-3.786354f, 0f, -6.93599f);

        }

    }


    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {

    }
    private void Update()
    {

        /*
            if (fade == true)
            {
                if (start <= 1.0f)
                {
                    im.color += new Color(0, 0, 0, Time.deltaTime);
                }
                else if (start > 1.0f && start < 1.1f)
                {
                    //GetComponent<Transform>().position = new Vector3(-352f, 1.75f, 72f);
                }
                else if (start >= 1.1f && start <= finish)
                {
                    im.color -= new Color(0, 0, 0, Time.deltaTime);
                }
                else if (start > finish)
                {
                    start = 0.0f;
                    fade = false;
                }
                start += Time.deltaTime;
            }
        */
    }
}


