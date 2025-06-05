using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskWearGlovesCanvas : MonoBehaviour
{
    public GameObject ZuoZi;
    public Button LeftHand;
    public GameObject LeftHandModle; 

    public Button RightHand;
    public GameObject RightHandModle;
    public GameObject TaskDisconnectTheWireGlovesCanvas;
    int unmber=0;
    private void Awake()
    {
        EventCenter.AddListener(EventTypeCare.TaskThree, TaskThree);
        
    }
    void Start()
    {
        ZuoZi.SetActive(true);
        LeftHandModle.SetActive(true);
        RightHandModle.SetActive(true);
        LeftHand.gameObject.SetActive(true);
        RightHandModle.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void TaskThree()
    {
        
        LeftHand.onClick.AddListener(delegate {
            LeftHandModle.SetActive(false);
            LeftHand.gameObject.SetActive(false);
            EventCenter.Broadcast(EventTypeCare.WearLeftGlove);
            TaskDisconnectTheWireGlovesCanvas1();
        });
        RightHand.onClick.AddListener(delegate {
            RightHandModle.SetActive(false);
            RightHand.gameObject.SetActive(false);
            EventCenter.Broadcast(EventTypeCare.WearRightGlove);
            TaskDisconnectTheWireGlovesCanvas1();
        });
    }
    void TaskDisconnectTheWireGlovesCanvas1()
    {
        unmber++;
        if (unmber>=2)
        
        TaskDisconnectTheWireGlovesCanvas.SetActive(true);
    }
}
