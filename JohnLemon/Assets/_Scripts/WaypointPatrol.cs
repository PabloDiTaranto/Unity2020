using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public Transform[] waypoints;

    private int _currentWaypointIndex;
    
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            _navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
        }
    }
}
