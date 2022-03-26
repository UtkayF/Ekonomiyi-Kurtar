using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forCamera : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public float xOffSet = 1f;
    public float yOffSet = 1f;
    public float zOffSet = 1f;

    /*
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    */


    void LateUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffSet, target.position.y + yOffSet, target.position.z + zOffSet);
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed);

        /*
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
        */

    }

}
