using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{


    [SerializeField] private waypoint _waypointPath;
    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timetoWaypoint;
    private float _elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        _elapsedTime+= Time.deltaTime;
        float elapsedPercentage = _elapsedTime/ _timetoWaypoint;
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        if(elapsedPercentage>=1)
        {
            TargetNextWaypoint();
        }
        
    }
    
    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position,_targetWaypoint.position);
        _timetoWaypoint= distanceToWaypoint/_speed;
    }
}
