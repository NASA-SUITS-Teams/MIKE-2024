using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtCamera : MonoBehaviour
{
    [SerializeField] private float distanceFromUser = 5f;
    [SerializeField] private float smoothTime = 5f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private Vector3 currentVelocity = Vector3.zero;
    private Transform cameraTransform;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.position - cameraTransform.position;
        //transform.forward = cameraTransform.position - transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, cameraTransform.position + cameraTransform.TransformDirection(new Vector3(0, 0, distanceFromUser) + offset), ref currentVelocity, smoothTime);
    }
}
