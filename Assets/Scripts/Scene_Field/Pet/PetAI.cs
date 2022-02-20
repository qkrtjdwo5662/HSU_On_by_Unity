using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetAI : MonoBehaviour
{

    //  private Collider me;
    private Transform me;
    private Animator ani;
    private int action;
    private Animator meAni;
    float distance = 0.0f;

    public Animator getAnimator()
    {
        return ani;
    }

    // Start is called before the first frame update
    void Start()
    {
        me = GameObject.Find("Me").GetComponent<Transform>();
        ani = GetComponent<Animator>();
        meAni = GameObject.Find("Me").GetComponent<Animator>();
        
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
            ani.SetBool("IsEat", false);
            ani.SetBool("IsMove", true);
            
           
            
        }
        else if (distance >= 10f)
        {
            this.transform.position = me.position + new Vector3(1,0,0);// 너무 멀어지면 내옆으로 순간이동 펫이 사물에 걸리면 순간이동 못하는 버그있
        }
        else if (distance < 2)
        {
            ani.SetBool("IsMove", false); //가까워지면 움직임 x
            DoSomething();
            
        }
        /*
        else if (meAni.GetBool("IsJump"))
        {
            ani.SetBool("IsJump", true);
        }
        */
        //Update는 실시간 퍼포먼스에 큰 영향을 주기 때문에 Update()안에서는 불필요한 연산을 최대한 피하자 
    }


   private void DoSomething()
    {
        action = Random.Range(0, 2);

        switch (action)
        {

            case 0:
                ani.SetBool("IsEat",true);
                break;
            case 1:
                ani.SetBool("IsEat", false);
                break;

                

        }
   

    }
    
}
