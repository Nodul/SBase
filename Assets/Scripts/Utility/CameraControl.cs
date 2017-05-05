using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //private Camera camera; // temporarily not needed
    private GameObject camGO; // for easier movement handling of a rotated camera
    public float MoveSpeed;
    private float MoveThreshold = 0.5f;

    void Start()
    {
        //camera = this.GetComponent<Camera>();
        camGO = GameObject.Find("CameraGO");
    }

    // Update is called once per frame
    void Update()
    {
        float axisRawHorizontal = Input.GetAxisRaw("Horizontal");
        float axisRawVertical = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(axisRawHorizontal) >= MoveThreshold)
        {
            camGO.transform.Translate(new Vector3(axisRawHorizontal * MoveSpeed, 0, 0));
        }
        if (Mathf.Abs(axisRawVertical) >= MoveThreshold)
        {
            camGO.transform.Translate(new Vector3(0, 0, axisRawVertical * MoveSpeed));
        }

    }
}
