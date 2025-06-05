using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TSLScreenManager : MonoBehaviour
{
    public Button CarStartsButton;
    public Button CarSafeButton;
    public Button CarImagetsButton;
    public GameObject CarStationObj;
    public GameObject CarImageObj;
    public CarStation _CarStation;
    public GameObject TSLHoodControlCanvas;
    public GameObject TSLDoorControlCanvasOther;
    public enum CarStation
    {
        firing,//Æô¶¯
        stop//Ï¨»ð
    }
    void Start()
    {
        TSLHoodControlCanvas.SetActive(false);
        TSLDoorControlCanvasOther.SetActive(false);
        CarStartsButton.gameObject.SetActive(true);
        CarSafeButton.gameObject.SetActive(false);
        CarImagetsButton.gameObject.SetActive(false);
        _CarStation =CarStation.firing;
        if (CarImagetsButton == null)
        {
            CarImagetsButton = transform.Find("CarEndUnit/CarStartsButton"). GetComponent<Button>();
        }
        if (CarStationObj == null)
        {
            CarStationObj = transform.Find("CarStation").gameObject;
        }
        CarStartsButton.onClick.AddListener(delegate {

            CarStartsButton.gameObject.SetActive(false);
            CarSafeButton.gameObject.SetActive(true);
        });
        CarSafeButton.onClick.AddListener(delegate {
            CarSafeButton.gameObject.SetActive(false);
            CarImagetsButton.gameObject.SetActive(true);
            CarImageObj.gameObject.SetActive(true);
        });
        CarImagetsButton.onClick.AddListener(delegate {
            if(_CarStation!= CarStation.firing)
            {
                CarStationObj.transform.GetChild(0).gameObject.SetActive(true);
                CarStationObj.transform.GetChild(1).gameObject.SetActive(false);
                //EventCenter.Broadcast(EventTypeCare.AnimationClears);
                
            }
            else
            {
                CarStationObj.transform.GetChild(0).gameObject.SetActive(false);
                CarStationObj.transform.GetChild(1).gameObject.SetActive(true);
                TSLHoodControlCanvas.SetActive(true);
                TSLDoorControlCanvasOther.SetActive(true);
                //EventCenter.Broadcast(EventTypeCare.AnimationClears);
            }
        });
        CarStationObj.transform.GetChild(0).gameObject.SetActive(true);
        CarStationObj.transform.GetChild(1).gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
