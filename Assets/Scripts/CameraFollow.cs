using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    
    
    void Update()
    {
        Vector3 newPos = new Vector3(Target.position.x, transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * FollowSpeed);
    }
}
