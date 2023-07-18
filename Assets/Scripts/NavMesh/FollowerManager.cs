using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerManager : MonoBehaviour
{
    [SerializeField] private List<FollowLeader> followers;
    [SerializeField] private bool shouldFollow;

    private void Start()
    {
        foreach (var follower in followers)
        {
            follower.follow = shouldFollow;
        }
    }
}
