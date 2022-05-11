using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SangSangBugiNavigator : MonoBehaviour
{
	// 추적할 대상 Object
	// 추적할 Object
	private Transform tr;
	// 추적 Object에 적용된 NavMeshAgent 컴포넌트
	public NavMeshAgent nvAgent;

	private Vector3 destination;
	// Use this for initialization
	public bool moveSwitch = false;
	public bool isArrive = false;

	[SerializeField]
	private GameObject Me;
	[SerializeField]
	private Animator ani;
	void Start()
	{
		Me = GameObject.Find("Me");
		tr = GetComponent<Transform>();
		//ani.SetBool("isMove", false);
		//추적 Object에 적용된 NavMeshAgent 컴포넌트에 추적대상 설정         
	}


	public void StartGuide(Transform t)
	{

		Debug.Log(t.position);
		//ani.SetBool("isMove", true);
		moveSwitch = true;
		isArrive = false;
		destination = t.position;
		nvAgent.destination = destination;

	}


	// Update is called once per frame     
	void Update()
	{
        if (Vector3.Distance(this.transform.position, Me.transform.position) >= 7.5f)
        {
            moveSwitch = false;
            nvAgent.isStopped = true;
            this.transform.LookAt(Me.transform);
			//ani.SetBool("isMove", false);

		}
	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            if (isArrive)
            {
                //음성 출
            }
            else if (!isArrive)
            {
                Debug.Log("@@@@@@");
                nvAgent.isStopped = false;
				//ani.SetBool("isMove", true);

			}
		}
        else if (other.tag == "Flag")
        {
            nvAgent.isStopped = true;
            isArrive = true;
            //ani.SetBool("isMove", false);
        }
    }
	private void OnTriggerExit(Collider other)
	{



	}
}
