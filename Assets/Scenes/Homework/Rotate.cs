using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1.0f;
    public bool clockwise = true;
    private Vector3 _pos;
    
    private void Start()
    {
        _pos = transform.position;
    }
    
    private void Update()
    {
        if (clockwise)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, -speed * Time.deltaTime);
        }
    }
}