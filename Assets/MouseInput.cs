using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Skeleton"))
                {
                    hit.transform.gameObject.GetComponent<Skeleton>().panelBool = true;
                    print("hit: " + hit.transform.name);
                }
            }
        }


        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
            if (Physics.Raycast(ray2, out hit2))
            {
                if (hit2.transform.CompareTag("Skeleton"))
                {
                    hit2.transform.gameObject.GetComponent<Skeleton>().halo.SetActive(true);
                }

            }

        }
    }

