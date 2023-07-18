using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowLeader : MonoBehaviour
{
    public bool follow;
    private NavMeshAgent agent;
    [SerializeField] private NavMeshAgent leader;
    private Transform leaderPos;
    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        leaderPos = leader.gameObject.transform;
    }

    private void Update()
    {
        if (!follow)
        {
            return;
        }
        else
        {
            agent.destination = leaderPos.position;
            agent.stoppingDistance = 0.5f;
        }
    }
}
