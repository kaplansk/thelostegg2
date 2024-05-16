using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public Transform GetWaypoint (int waypointIndex)
    {
        return transform.GetChild(waypointIndex);

    }   

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex +1 ;
        
        if(nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }
        
        return nextWaypointIndex;
       
    }

    internal int GetNextWaypointIndex(Transform targetWaypoint)
    {
        throw new NotImplementedException();
    }
}
