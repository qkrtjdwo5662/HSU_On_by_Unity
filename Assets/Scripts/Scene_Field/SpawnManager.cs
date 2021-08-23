using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    //다른곳에서 쓰기 쉽게 정적 클래스 선언
    [SerializeField] Spawnpoint[] spawnpoints;

    void Awake()
    {
        Instance = this;
        spawnpoints = GetComponentsInChildren<Spawnpoint>();
    }

    public Transform GetSpawnpoint()
    {
        return spawnpoints[Random.Range(0, spawnpoints.Length)].transform;
        //랜덤하게 스폰 지점 정해주기.
    }
}