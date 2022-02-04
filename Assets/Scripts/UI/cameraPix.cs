using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cameraPix : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;

    PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine) {
            Destroy(cam);
        }
    }
}
