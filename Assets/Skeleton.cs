using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string burialDate;
    public string info;
    public Sprite[] images;
    public float x;
    public float y;
    public float z;
    public float rotation;

    public bool panelBool = false;
    public GameObject panel;
    public GameObject halo;



    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {

        if (panelBool)
        {
            panel.SetActive(true);
        }
        else { panel.SetActive(false); }

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


    

}
