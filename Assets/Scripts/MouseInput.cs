using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour {

    private UIControl uic;
    public GameObject panel;




    // Use this for initialization
    void Start () {
        uic = FindObjectOfType<UIControl>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Skeleton"))
                    {
                        
                            panel.SetActive(true);
                        hit.transform.gameObject.GetComponent<Skeleton>().PopulateFullPanel();
                            print("hit: " + hit.transform.name);
                        
                    }
                    else if (!hit.transform.CompareTag("Panel"))
                    {
                        ClosePanel();
                    }
                }
                else
                {
                    ClosePanel();
                }
            }

        }
    }

    public void ClosePanel()
    {
        if (panel.activeSelf == true)
        {
            FindObjectOfType<InfoPanelUpdater>().miniOff();
            panel.SetActive(false);
            uic.menuOn = false;
            uic.menuPanel.SetActive(false);
        }
    }
    }

