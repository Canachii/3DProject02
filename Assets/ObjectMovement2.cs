using System;
using UnityEngine;

public class ObjectMovement2 : MonoBehaviour
{
    public float speed = 1.0f;
    public float length = 1.0f;
    
    private float run_time = 0.0f;
    private float PosY = 0.0f;

    private void Update()
    {
        run_time += Time.deltaTime * speed;
        PosY = Mathf.Sin(run_time) * length;
        // Debug.Log(run_time);
        Debug.Log(PosY);
        transform.position = new Vector3(0, PosY);
    }
}