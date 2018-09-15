using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    //UIControl uic;

    // Use this for initialization
    void Start () {
        //uic = FindObjectOfType<UIControl>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Skeleton"))
                {
                    hit.transform.gameObject.GetComponent<Skeleton>().panel.SetActive(true);
                    print("hit: " + hit.transform.name);
                }
                else if (!hit.transform.CompareTag("Panel"))
                {
                    ClosePanels();
                }
            }
            else
            {
                ClosePanels();
            }
        }


    }

    void ClosePanels()
    {
        Skeleton[] skeletons = FindObjectsOfType<Skeleton>();
        foreach (Skeleton sk in skeletons)
        {
            sk.panel.SetActive(false);
        }

        //uic.menuOn = false;
        //uic.menuPanel.SetActive(false);
    }
    }

