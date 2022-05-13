using System.Collections;
using System.Collections.Generic;
using TMPro;
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

	public GameObject SpeechDialog;
	public TextMeshPro text;
	private GameObject CameraArm;


	[SerializeField]
	private GameObject Me;
	[SerializeField]
	private Animator ani;
	void Start()
	{
		Me = GameObject.Find("Me");
		tr = GetComponent<Transform>();
		ani.SetBool("isMove", false);
		CameraArm = GameObject.Find("Camera Arm");

		//추적 Object에 적용된 NavMeshAgent 컴포넌트에 추적대상 설정         
	}


	public void StartGuide(Transform t)
	{

		Debug.Log(t.position);
		ani.SetBool("isMove", true);
		moveSwitch = true;
		isArrive = false;
		destination = t.position;
		nvAgent.destination = destination;

	}


	// Update is called once per frame     
	void Update()
	{
		if (SpeechDialog.activeInHierarchy)
		{
			SpeechDialog.transform.rotation = CameraArm.transform.rotation;
		}
		if (Vector3.Distance(this.transform.position, Me.transform.position) >= 7.5f)
        {
            moveSwitch = false;
            nvAgent.isStopped = true;
            this.transform.LookAt(Me.transform);
			ani.SetBool("isMove", false);
			SpeechDialog.SetActive(true);
			text.text = "내가 너무 빠르구나? 기다리고 있을게!";
		}
		if (isArrive) {
			this.transform.LookAt(Me.transform);
			SpeechDialog.SetActive(true);
			text.text = "도착했어! 이곳이 목적지야!";
		}
	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
        {
            if (!isArrive)
            {
                nvAgent.isStopped = false;
				ani.SetBool("isMove", true);
				SpeechDialog.SetActive(false);

			}
		}
        if (other.tag == "Destination")
        {
			Debug.Log("@@@@@@@@@");
            nvAgent.isStopped = true;
            isArrive = true;
            ani.SetBool("isMove", false);
			this.transform.LookAt(Me.transform);

		}
	}
	private void OnTriggerExit(Collider other)
	{



	}
}
