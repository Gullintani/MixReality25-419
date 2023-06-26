using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColliderControl : MonoBehaviour
{
    public GameObject Thumb_0_Collider, Thumb_1_Collider, Thumb_2_Collider, Thumb_3_Collider, Thumb_4_Collider;
    public GameObject Index_0_Collider, Index_1_Collider, Index_2_Collider;
    public GameObject Middle_0_Collider, Middle_1_Collider, Middle_2_Collider;
    public GameObject Ring_0_Collider, Ring_1_Collider, Ring_2_Collider;
    public GameObject Pinky_0_Collider, Pinky_1_Collider, Pinky_2_Collider;
    // public GameObject Palm_0, Palm_1, Palm_2, Palm_3, Palm_4;

    public HandAnimator JointData;

    public GameObject SteeringWheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Thumb_0_Collider.transform.position = JointData.Thumb_0;
        Thumb_1_Collider.transform.position = JointData.Thumb_1;
        Thumb_2_Collider.transform.position = JointData.Thumb_2;
        Thumb_3_Collider.transform.position = JointData.Thumb_3;
        Thumb_4_Collider.transform.position = JointData.Thumb_4;

        Index_0_Collider.transform.position = JointData.Index_0;
        Index_1_Collider.transform.position = JointData.Index_1;
        Index_2_Collider.transform.position = JointData.Index_2;

        Middle_0_Collider.transform.position = JointData.Middle_0;
        Middle_1_Collider.transform.position = JointData.Middle_1;
        Middle_2_Collider.transform.position = JointData.Middle_2;

        Ring_0_Collider.transform.position = JointData.Ring_0;
        Ring_1_Collider.transform.position = JointData.Ring_1;
        Ring_2_Collider.transform.position = JointData.Ring_2;

        Pinky_0_Collider.transform.position = JointData.Pinky_0;
        Pinky_1_Collider.transform.position = JointData.Pinky_1;
        Pinky_2_Collider.transform.position = JointData.Pinky_2;

        // Quaternion sourceRotation = Index_2_Collider.transform.rotation;
        // Vector3 sourceEulerAngles = sourceRotation.eulerAngles;
        // Debug.Log(sourceEulerAngles);
        // Quaternion newRotation = Quaternion.Euler(0f, sourceEulerAngles.y, 0f);
        // SteeringWheel.transform.rotation = newRotation;
        Debug.Log(Thumb_0_Collider.transform.position);
    }
}
