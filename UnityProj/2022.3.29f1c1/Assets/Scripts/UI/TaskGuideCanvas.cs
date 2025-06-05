using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class TaskGuideCanvas : MonoBehaviour
{
    public GameObject TaskOne;
    public GameObject TaskTwo;
    public GameObject TaskThree;
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.AddListener(EventTypeCare.SoftwareSelfTest, SoftwareSelfTest);
        TaskOne.SetActive(true);
        TaskTwo.SetActive(false);
        TaskThree.SetActive(false);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.SoftwareSelfTest);
        
    }

    void SoftwareSelfTest()
    {
        if (GameManager.instance.taskStatus== TaskStatusCar.One)
        {
            TaskOne.SetActive(true);
            TaskTwo.SetActive(false);
            TaskThree.SetActive(false);
        }
        else if (GameManager.instance.taskStatus == TaskStatusCar.Two)
        {
            TaskOne.SetActive(false);
            TaskTwo.SetActive(true);
            TaskThree.SetActive(false);
        }
        else if (GameManager.instance.taskStatus == TaskStatusCar.Three)
        {
            TaskOne.SetActive(false);
            TaskTwo.SetActive(false);
            TaskThree.SetActive(true);
        }
    }
}
