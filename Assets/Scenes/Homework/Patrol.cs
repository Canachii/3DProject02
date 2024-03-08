using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public enum Direction
    {
        Horizontal, Vertical
    }
    
    public Direction direction = Direction.Horizontal;
    public bool reverse = false;
    public float speed = 1.0f;
    public float range = 1.0f;
    private float _time = 0.0f;
    private Vector3 _transform;
    private Vector3 _v;

    private void Start()
    {
        _transform = transform.position;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _v = _transform;
        switch (direction)
        {
            case Direction.Horizontal:
                _v.x += Mathf.Cos(_time * speed) * range * (reverse ? -1 : 1);
                break;
            case Direction.Vertical:
                _v.z += Mathf.Cos(_time * speed) * range * (reverse ? -1 : 1);
                break;
        }
    }

    private void FixedUpdate()
    {
        transform.position = _v;
    }
}