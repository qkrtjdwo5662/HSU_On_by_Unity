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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        var group = GameObject.Find("WayPointGroup");

        if (group != null)
		{
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
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
            nextIdx = ++nextIdx % wayPoints.Count;
            MoveWayPoint();
		}            
    }
}
