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

	public FindWayManager fm;

	public Animator ani;
	void Start()
	{
		nvAgent = GetComponent<NavMeshAgent>();
		tr = GetComponent<Transform>();
		ani.SetBool("isMove",true);
		//추적 Object에 적용된 NavMeshAgent 컴포넌트에 추적대상 설정         
		nvAgent.destination = destiantion;
	}
	// Update is called once per frame     
	void Update()
	{
		nvAgent.destination = destiantion;
	}
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

}
