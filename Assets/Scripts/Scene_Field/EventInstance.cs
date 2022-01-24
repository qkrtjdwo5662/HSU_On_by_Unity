using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstance : MonoBehaviour
{
    public Clock clock;
    private Hashtable hashtable = new Hashtable();



    [PunRPC]
    private void addRanker(string msg, int score) {
        if (hashtable.ContainsKey(msg))
        {
            hashtable[msg] = (int)hashtable[msg] + score;
        }
        else 
        {
            hashtable.Add(msg,score);
        }
    }


    private void EventStart() { 
    
    
    }

    private void EventEnd() { 
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
