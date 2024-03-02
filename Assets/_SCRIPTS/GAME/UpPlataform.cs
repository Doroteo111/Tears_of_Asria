using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPlataform : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float _checkDistance = 0.05f;
    private Transform _targetWaypoints;
    private int _currentWayPointIndex = 0;

    private void Start()
    {
        _targetWaypoints = _waypoints[0];
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetWaypoints.position,
                                                speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,_targetWaypoints.position)< _checkDistance)
        {
            _targetWaypoints = GetNextWaypoints();
        }
    }

    private Transform GetNextWaypoints()
    {
        _currentWayPointIndex++;
        if(_currentWayPointIndex >= _waypoints.Length)
        {
            _currentWayPointIndex = 0;
        }
        return _waypoints[_currentWayPointIndex];
    }

    
}
