using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAI : MonoBehaviour
{

  //  private Collider me;
    private Transform me;
    float distance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("Me").GetComponent<Transform>();

        
        //x z 거리계산
     }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(me.position, this.transform.position); //캐싱, 불필요한 distance계산의 중복을 막는다
        if (distance >= 2f && distance < 10f)
        {
            this.transform.LookAt(me.position);//날 바라보고
            this.transform.Translate(Vector3.forward * Time.deltaTime * 2f);//날 따라와
            
        }
        else if (distance >= 10f)
        {
            this.transform.position = me.position + new Vector3(1,0,0);
        }
        //Update는 실시간 퍼포먼스에 큰 영향을 주기 때문에 Update()안에서는 불필요한 연산을 최대한 피하자 
    }

    
}
