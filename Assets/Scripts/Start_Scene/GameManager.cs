using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    GameObject Me;


    [PunRPC]
    void StartOtEvent() { 
        
        
    }

    void Awake()
    {
        
    }
    void Start()
    {
        Me = GameObject.Find("Me");

    }
}
