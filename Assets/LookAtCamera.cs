using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = transform.position - Camera.main.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;

    }


}
