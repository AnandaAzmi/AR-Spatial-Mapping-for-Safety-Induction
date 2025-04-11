using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollower : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 offset = new Vector3(0, 0, 2);
    public float followSpeed = 2f;

    void LateUpdate()
    {
        if (playerCamera != null)
        {
            Vector3 rotatedOffset = playerCamera.rotation * offset;
            Vector3 targetPosition = playerCamera.position + rotatedOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
            Vector3 lookDirection = playerCamera.position - transform.position;
            lookDirection.y = 0; // Optional: biar nggak miring kalau kamera naik turun
            if (lookDirection.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * followSpeed);
            }
        }
    }
}
