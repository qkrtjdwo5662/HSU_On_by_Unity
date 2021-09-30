using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    
    public int Camcontrol =1;
    public float start = 0.0f;
    private float finish = 5.0f;
    public Image im;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finish <= start) {
            Camcontrol = (Camcontrol%5+1);
            
            start = 0.0f;
        }
        if (start <= 1.0f) {
            im.color -= new Color(0, 0, 0, Time.deltaTime);
        }
        else if (start >= finish-1.0f)
        {
            im.color += new Color(0, 0, 0, Time.deltaTime);
        }
        start += Time.deltaTime;
        
        switch (Camcontrol) {
            case 1:
                cam1.SetActive(true);
                cam2.SetActive(false);
                cam3.SetActive(false);
                cam4.SetActive(false);
                cam5.SetActive(false);
                cam1.transform.position += new Vector3(0.01f, 0, 0);
                break;
            case 2: cam1.SetActive(false);
                cam2.SetActive(true);
                cam3.SetActive(false);
                cam4.SetActive(false);
                cam5.SetActive(false);
                cam2.transform.position += new Vector3(0.001f, 0, 0);
                break;
            case 3: cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(true);
                cam4.SetActive(false);
                cam5.SetActive(false);
                cam3.transform.position += new Vector3(-0.001f, 0, 0);
                break;
            case 4: cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(false);
                cam4.SetActive(true);
                cam5.SetActive(false);
                cam4.transform.position += new Vector3(0.001f, 0, 0);
                break;
            case 5: cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(false);
                cam4.SetActive(false);
                cam5.SetActive(true);
                cam5.transform.position += new Vector3(0.001f, 0, 0);
                break;
        }
    }

    
}
