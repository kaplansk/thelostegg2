using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachinePath;

public class MovePLatform : MonoBehaviour
{
    [SerializeField] private waypoint _waypointPath;
    [SerializeField] private float _speed;

    private int _targetWaypointIndex;
    private Transform _previousWaypoint;
    private Transform _targetWaypoint;
    private float _timetoWaypoint;
    private float _elapsedTime;

    private bool _shouldMove = false; // Platformun hareket edip etmeyeceðini kontrol eder

    void Start()
    {
        TargetNextWaypoint();
    }

    void Update()
    {
        if (_shouldMove)
        {
            _elapsedTime += Time.deltaTime;
            float elapsedPercentage = _elapsedTime / _timetoWaypoint;
            transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);

            if (elapsedPercentage >= 1.0f) // Hedef waypoint'e ulaþýldýðýnda bir sonrakini hedefle
            {
                TargetNextWaypoint();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _shouldMove = true; // Karakter platforma çarptýðýnda hareket etmeye baþla
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timetoWaypoint = distanceToWaypoint / _speed;
    }
}
