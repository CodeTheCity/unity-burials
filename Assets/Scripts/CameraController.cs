using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float rotSpeed = 20;
    public float panSpeed = 100;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            rb.angularVelocity = new Vector3(rb.angularVelocity.x, -rotY, rb.angularVelocity.z);
            Camera.main.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(rotX, Camera.main.gameObject.GetComponent<Rigidbody>().angularVelocity.y, Camera.main.gameObject.GetComponent<Rigidbody>().angularVelocity.z);

        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, scroll * panSpeed);
        // transform.position += Vector3.forward * Time.deltaTime * scroll *panSpeed;
        if (Input.GetMouseButton(2))
        {
            float axisZ = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            float axisX = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            rb.velocity = new Vector3(axisX, rb.velocity.y, axisZ);
        }
    }
}