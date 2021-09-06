using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Navigation 관련 기능을 사용할 때 필요.
using UnityEngine.AI;

public class TestAgentScript : MonoBehaviour
{
    // 목표 지점
    public List<Transform> wayPoints;

    public int nextIdx=0;

    private NavMeshAgent agent;

    private readonly int hashOffset = Animator.StringToHash("Offset");
    private readonly int hashWalkSpeed = Animator.StringToHash("WalkSpeed");

    private Animator animator;

    private void Awake()
	{
        animator = GetComponent<Animator>();

        animator.SetFloat(hashOffset, Random.Range(0.0f, 1.0f));
        animator.SetFloat(hashWalkSpeed, Random.Range(1.0f, 1.2f));
	}

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        var group = GameObject.Find("WayPointGroup");

        if (group != null)
		{
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);

            nextIdx = Random.Range(0, wayPoints.Count);
		}

       
        MoveWayPoint();
    }
    
    private void MoveWayPoint()
	{
        if (agent.isPathStale) return;

        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
	}

    void Update()
    {
       if(agent.velocity.sqrMagnitude >=0.2f * 0.2f
            && agent.remainingDistance <= 0.5f)
		{
            // nextIdx = ++nextIdx % wayPoints.Count;
            nextIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
		}            
    }
}
