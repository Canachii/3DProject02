using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Vector3 pos;

    private void Update()
    {
        pos.x = Mathf.Cos(Time.time * 360 * Mathf.Deg2Rad);
        pos.z = Mathf.Sin(Time.time * 360 * Mathf.Deg2Rad);
        transform.position = pos;

        // Mathf.Cos() 삼각함수 코사인 값을 계산하는 기능
        // Mathf.Sin() 삼각함수 사인 값을 계산하는 기능
        // Mathf.Deg2Rad : 각도(Degree) -> 라디안(Radian)
        // 라디안은 한 원 위의 점이 원점을 중심으로 반지름의 길이만큼 한 방향으로 움직였을 때 대응하는
        // 각의 크기 (약 57.3도)
    }
}