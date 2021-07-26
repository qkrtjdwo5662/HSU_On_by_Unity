using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;
    Vector3 cameraPositon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        cameraPositon.x = player.transform.position.x + offsetX;
        cameraPositon.y = player.transform.position.y + offsetY;
        cameraPositon.z = player.transform.position.z + offsetZ;

        transform.position = cameraPositon;
    }
}
