using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skeleton : MonoBehaviour {

    
    public GameObject headObject;
    public GameObject chestObject;
    public GameObject pelvisObject;
    public GameObject lArmObject;
    public GameObject rArmObject;
    public GameObject lLegObject;
    public GameObject rLegObject;
    private GameObject[] skeletonObjects;


    // csv input parts of skeleton
   

    public bool head;
    public bool chest;
    public bool pelvis;
    public bool lArm;
    public bool rArm;
    public bool lLeg;
    public bool rLeg;
    private bool[] skeletonBools;

    // csv input SK Data

    public bool male;
    public int age;
    public int burialDate;
    public string info;
    public Sprite[] images;
    public float x;
    public float y;
    public float z;
    public float rotation;

    public GameObject halo;

    UIControl uic;
    InfoPanelUpdater ipu;

    public int threeDModelNumber = 0;


    // Use this for initialization
    void Start () {

        uic = FindObjectOfType<UIControl>();
        
        
    }
	
	// Update is called once per frame
	void Update () {



        skeletonObjects = new GameObject[] { headObject, chestObject, pelvisObject, lArmObject, rArmObject, lLegObject, rLegObject };
        skeletonBools = new bool[] { head, chest, pelvis, lArm, rArm, lLeg, rLeg };
        for (int i = 0; i < skeletonObjects.Length; i++)
        {
            if (!skeletonBools[i])
            {
                skeletonObjects[i].SetActive(false);
            }
            else
            {
                skeletonObjects[i].SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        halo.SetActive(false);
        uic.SKname.text = "";
    }
    void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            halo.SetActive(true);
            uic.SKname.text = this.gameObject.name;
        }
    }



    public void PopulateFullPanel()
    {
        ipu = FindObjectOfType<InfoPanelUpdater>();
        string mySex = "Male";
        if (!male)
        {
            mySex = "Female";
        }
        InfoPanelUpdater.threeDModelNumber = threeDModelNumber;
        ipu.UpdatePanel(transform.name, age.ToString(), burialDate.ToString(), mySex, info);
    }

}
