using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelControl : MonoBehaviour
{   
    public Quaternion originalRotation;
    public float rotationSpeed = 0.5f;
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
        Debug.Log(transform.rotation);
    }
}
