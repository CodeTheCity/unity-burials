using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour
{
    public float rotSpeed = 100;
    public float scaleSpeed = 100;
    Rigidbody rb;

    private Quaternion initRot;
    private Vector3 initScale;
    private bool reseting = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initRot = transform.localRotation;
        initScale = transform.localScale;

    }

    private void Update()
    {
        float x = transform.localScale.x + Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * scaleSpeed;
        x = Mathf.Clamp(x, initScale.x, 2*initScale.x);
        transform.localScale = new Vector3(x,x,x);

        if (reseting)
        {
            rb.angularVelocity = Vector3.zero;
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, initRot, rotSpeed * 5 * Time.deltaTime);
            float lerpSize = Mathf.MoveTowards(transform.localScale.x, initScale.x, scaleSpeed * Time.deltaTime);
            transform.localScale = new Vector3(lerpSize, lerpSize, lerpSize);
            if (transform.localScale.x == initScale.x && transform.localRotation.x == initRot.x)
            {
                reseting = false;
            }
        }

    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rb.angularVelocity = new Vector3(rotX, -rotY, 0);

    }

    public void ResetPosition()
    {
        reseting = true;
    }
}