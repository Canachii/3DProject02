using UnityEngine;

public class GoForward : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.0f;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_currentWaypoint < waypoints.Length)
        {
            var target = waypoints[_currentWaypoint].position;
            var moveDirection = target - transform.position;
            var velocity = moveDirection.normalized * speed;
            transform.position += velocity * Time.deltaTime;
            if (moveDirection.magnitude < 0.01f)
            {
                _currentWaypoint++;
            }
            
            if (_currentWaypoint == waypoints.Length)
            {
                _currentWaypoint = 0;
            }
        }
    }
}