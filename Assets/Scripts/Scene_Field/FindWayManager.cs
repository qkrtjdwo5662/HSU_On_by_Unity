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
        navi.destiantion = new Vector3(x, y, z);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
