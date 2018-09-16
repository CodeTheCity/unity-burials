using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    public Camera cam;
    private float objectScale =0.15f;
    private Vector3 initialScale;
    // Use this for initialization
    void Start () {
        initialScale = transform.localScale;
        if (cam == null)
            cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        if (UIControl.threeD)
        {
            Vector3 direction = transform.position - Camera.main.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        //Plane plane = new Plane(cam.transform.forward, cam.transform.position);
        //float dist = plane.GetDistanceToPoint(transform.position);
        //transform.localScale = initialScale * dist * objectScale;

    }


}
