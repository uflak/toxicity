using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 CameraOffSet;
    public Vector3 TargetedPosition;
    private Vector3 velocity = Vector3.zero;

    public float SmoothTime = 0.3f;


    void LateUpdate()
    {
    
        TargetedPosition = targetObject.transform.position + CameraOffSet;
        TargetedPosition.y = 0;
        transform.position = Vector3.SmoothDamp(transform.position, TargetedPosition, ref velocity, SmoothTime);
    }
}
