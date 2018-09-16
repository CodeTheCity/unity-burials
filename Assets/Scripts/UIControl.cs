using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject fullPanel;
    public bool menuOn = false;
    public TextMeshProUGUI SKname;
    public TextMeshProUGUI dobMaxText;
    public TextMeshProUGUI dobMinText;
    public TextMeshProUGUI layerMin;
    public TextMeshProUGUI layerMax;
    public Slider layerSliderMin;
    public Slider layerSliderMax;
    public Slider dobSliderMin;
    public Slider dobSliderMax;
    public Toggle threeDPanels;
    public static bool threeD = true;
    
    private Skeleton[] skeletons;



    // Use this for initialization
    void Start () {
        MenuToggle();
        SKname.text = "";

        layerSliderMin.value = 1;
        layerSliderMax.value = 4;
        dobSliderMin.value = 10;
        dobSliderMax.value = 20;
        skeletons = FindObjectsOfType<Skeleton>();

    }
	
	// Update is called once per frame
	void Update () {

        if (menuPanel.activeSelf)
        {
            if (threeDPanels.isOn)
            {
                threeD = true;
            }
            else
            {
                threeD = false;
            }
        }

        dobMaxText.text = dobSliderMax.value.ToString();
        dobMinText.text = dobSliderMin.value.ToString();
        layerMin.text = layerSliderMin.value.ToString();
        layerMax.text = layerSliderMax.value.ToString();
        layerSliderMin.value = Mathf.Clamp(layerSliderMin.value, 1, layerSliderMax.value);
        layerSliderMax.value = Mathf.Clamp(layerSliderMax.value, layerSliderMin.value, 4);
        dobSliderMin.value = Mathf.Clamp(dobSliderMin.value, 10, dobSliderMax.value);
        dobSliderMax.value = Mathf.Clamp(dobSliderMax.value, dobSliderMin.value, 20);

        foreach (Skeleton sk in skeletons)
        {
            if (sk.burialDate > dobSliderMax.value || sk.burialDate < dobSliderMin.value)
            {
                sk.gameObject.SetActive(false);
            }
            else
            {
                sk.gameObject.SetActive(true);
            }
        }
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

    public void OnMouseUp()
    {

    }

    public void CloseFullPanel()
    {
        fullPanel.SetActive(false);
    }
}
