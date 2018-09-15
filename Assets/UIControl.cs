using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public GameObject menuPanel;
    public bool menuOn = false;
    public Text SKname;
    public Slider layerSlider;
    public Slider dateOfBurial;

    // Use this for initialization
    void Start () {
        MenuToggle();
        SKname.text = "";
	}
	
	// Update is called once per frame
	void Update () {



		
	}

    public void MenuToggle()
    {
        if (menuOn)
        {
            menuOn = false;
            menuPanel.SetActive(false);
        }
        else
        {
            menuOn = true;
            menuPanel.SetActive(true);
        }
    }
}
