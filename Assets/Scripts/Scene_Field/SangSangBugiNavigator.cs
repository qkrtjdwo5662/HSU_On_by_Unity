using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SangSangBugiNavigator : MonoBehaviour
{
	// 추적할 대상 Object
	public Vector3 destiantion;
	// 추적할 Object
	private Transform tr;
	// 추적 Object에 적용된 NavMeshAgent 컴포넌트
	private NavMeshAgent nvAgent;
	// Use this for initialization
	public bool moveSwitch = false;
	public bool isArrive = false;
	public GameObject Me;


	public FindWayManager fm;



	public Animator ani;
	void Start()
	{
		Me = GameObject.Find("Me");
		nvAgent = GetComponent<NavMeshAgent>();
		tr = GetComponent<Transform>();
		ani.SetBool("isMove",false);
		//추적 Object에 적용된 NavMeshAgent 컴포넌트에 추적대상 설정         
		nvAgent.destination = destiantion;
	}


	public void StartGuide() {
		ani.SetBool("isMove", true);
		moveSwitch = true;
		isArrive = false;
	}


	// Update is called once per frame     
	void Update()
	{
		if (moveSwitch)
		{
			nvAgent.destination = destiantion;
		}
	//	if (Vector3.Distance(this.transform.position, Me.trnasform.position >= 2.5f)) {
		//	moveSwitch = false;
			//this.transform.LookAt(Me);
		//}
	}
    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player")
		{
			if(isArrive) {
				//음성 출
			}
			else if (!isArrive)
			{
				moveSwitch = true;
			}
		}
		else if (other.tag == "Flag") {
			moveSwitch = false;
			isArrive = true;
			ani.SetBool("isMove",false);
		}
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

}
