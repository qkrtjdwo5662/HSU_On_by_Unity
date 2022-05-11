using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWayManager : MonoBehaviour
{
    public GameObject bugi;
    public SangSangBugiNavigator navi;
    public Vector3 destination;
    public Button btn;
    public Panel pl;



    public void GotoDestination(float x, float y, float z) 
    {
        bugi.SetActive(true);
        bugi.transform.position = GameObject.Find("Me").GetComponent<Transform>().position;
        navi.destiantion = new Vector3(x, y, z);
        navi.StartGuide();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
