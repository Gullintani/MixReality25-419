using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go : MonoBehaviour
{
    public GameObject Car;
    // private Vector3 Speed;
    public GameObject SteeringWheel;
    public HandAnimator HandAnimator;
    // Start is called before the first frame update
    void Start()
    {
        // Speed = new Vector3(0f, 0f, -0.01f);

    }

    // Update is called once per frame
    void Update()
    {
        // Car.transform.Rotate(-(HandAnimator.angle - HandAnimator.preangle), -(HandAnimator.angle - HandAnimator.preangle), -(HandAnimator.angle - HandAnimator.preangle));
        // Car.transform.position += Speed;
    }
}
