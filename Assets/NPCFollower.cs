using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollower : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 offset = new Vector3(0, -2, 0);
    public float followSpeed = 2f;

    void LateUpdate()
    {
        if (playerCamera != null)
        {
            Vector3 targetPosition = playerCamera.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
    }
}
