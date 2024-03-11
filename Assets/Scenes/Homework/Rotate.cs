using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1.0f;
    public bool clockwise = true;
    
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