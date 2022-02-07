using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAI : MonoBehaviour
{

  //  private Collider me;
    private Transform me;

    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("Me").GetComponent<Transform>();

        
        //x z 거리계산
     }

    // Update is called once per frame
    void Update()
    {
      
        if (Vector3.Distance(me.position, this.transform.position) >= 2f)
        {
            this.transform.LookAt(me.position);//날 바라보고
            this.transform.Translate(Vector3.forward * Time.deltaTime * 2f);//날 따라와
            
        }
        else
       
        
        if (Vector3.Distance(me.position, this.transform.position) >= 10f)
        {
            this.transform.position = me.position+ new Vector3(1,0,0);
        }
        
    }

    
}
