using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 offset;
    
   
    /// Functions
    
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        Vector3 targetPos = playerTransform.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
