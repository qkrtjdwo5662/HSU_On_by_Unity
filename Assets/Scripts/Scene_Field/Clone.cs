using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clone : MonoBehaviour
{
    private NavMeshAgent agent;
    //순찰을 위한 네비게이션 메쉬 에이전트
    PhotonView PV;
    //위치 동기화 PV
    void Awake()
    {
        PV = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        agent.autoBraking = false;
        //순찰 계속함
        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        Transform Patrolpoint = SpawnManager.Instance.GetSpawnpoint();
        //스폰 포인트로 썼던 위치들을 순찰 포인트로 씀
        agent.destination = Patrolpoint.position;
        //네비게이션 다음 목적지를 랜덤 순찰포인트로
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
        //근처에가면 다음 목적지로
    }
}
