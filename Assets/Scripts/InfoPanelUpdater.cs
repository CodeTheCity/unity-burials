using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelUpdater : MonoBehaviour {

    private rotate[] rots;
    public GameObject p1;
    public GameObject p2;
    public bool miniDisplay = true;

    public TextMeshProUGUI skName;
    public TextMeshProUGUI age;
    public TextMeshProUGUI burialDate;
    public TextMeshProUGUI sex;
    public TextMeshProUGUI info;

    public static int threeDModelNumber = 0;

    public GameObject[] threeDModelsBig;
    public GameObject[] threeDModelsSmall;




    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        foreach (GameObject model in threeDModelsSmall)
        {
            model.SetActive(false);
        }
        print("CATCH ERROR" + threeDModelNumber);
        threeDModelsSmall[threeDModelNumber].SetActive(true);
    }
    public void ResetRot()
    {
        rots = FindObjectsOfType<rotate>();
        foreach (rotate rot in rots)
        {
            rot.ResetPosition();
        }
    }

    public void miniOff()
    {
        ResetRot();
        miniDisplay = true;
        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(false);
        foreach (GameObject model in threeDModelsSmall)
        {
            model.SetActive(false);
        }
        print("CATCH ERROR" + threeDModelNumber);
        threeDModelsSmall[threeDModelNumber].SetActive(true);
    }

    public void ToggleMini()
    {
        ResetRot();
        if (miniDisplay)
        {
            miniDisplay = false;
            p1.gameObject.SetActive(false);
            p2.gameObject.SetActive(true);
            foreach (GameObject model in threeDModelsBig)
            {
                model.SetActive(false);
            }
            print("CATCH ERROR" + threeDModelNumber);
            threeDModelsBig[threeDModelNumber].SetActive(true);
        }
        else
        {
            miniDisplay = true;
            p1.gameObject.SetActive(true);
            p2.gameObject.SetActive(false);
            foreach (GameObject model in threeDModelsSmall)
            {
                model.SetActive(false);
            }
            print("CATCH ERROR" + threeDModelNumber);
            threeDModelsSmall[threeDModelNumber].SetActive(true);
        }
    
    }

    public void UpdatePanel(string skellyName, string skellyAge, string skellyBurialDate, string skellySex, string skellyInfo)
        {

        skName.text = skellyName;
        age.text = skellyAge;
        burialDate.text = skellyBurialDate;
        sex.text = skellySex;
        info.text = skellyInfo;

        foreach (GameObject model in threeDModelsSmall)
        {
            model.SetActive(false);
        }
        print("CATCH ERROR" + threeDModelNumber);
        threeDModelsSmall[threeDModelNumber].SetActive(true);

    }

}
