using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour 
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
	// Update is called once per frame
	void Update () 
    {
        Vector3 desired = target.position + offset;
        //linear interpolation = lerp -> lags the camera following
        Vector3 position = Vector3.Lerp(transform.position, desired, smoothSpeed);
        transform.position = desired;
	}
}
