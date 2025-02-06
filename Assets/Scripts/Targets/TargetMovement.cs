using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Transform Target;
    public Transform Position1;
    public Transform Position2;
    public float movementSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float PingPongValue = Mathf.PingPong(Time.time * movementSpeed, 1.0f);
        Vector3 newPosition = Vector3.Lerp(Position1.position, Position2.position, PingPongValue);
        Target.position = newPosition;
    }
}
