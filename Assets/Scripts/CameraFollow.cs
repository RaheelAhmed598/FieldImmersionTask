using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	// taking player as gameobject and camera follow player
    public Transform target;
	
    public Vector3 offset;

	//Linearly interpolates between camera and player.
    public float lerpValue;


    void LateUpdate()
    {
        Vector3 desPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
    }
}
