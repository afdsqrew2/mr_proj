using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class TSlDefaultProcessing : MonoBehaviour
{
    public Button uiButton; // 拖拽你的UI Image到这里
    public bool isShow; // 拖拽你的UI Image到这里
    public TaskStatusCar LocalTaskStatus = TaskStatusCar.One;
    private void Awake()
    {
        EventCenter.AddListener(EventTypeCare.SoftwareSelfTest, SoftwareSelfTest);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.SoftwareSelfTest);
       
    }
    private void Start()
    {
        uiButton.gameObject.SetActive(isShow);
        if (LocalTaskStatus == GameManager.instance.taskStatus)
        {
            gameObject.SetActive(true);
        }
        else 
        {
            gameObject.SetActive(false);
        }
        EventCenter.Broadcast(EventTypeCare.SoftwareSelfTest);

        //
    }
    private void OnTriggerEnter(Collider other)
    {
        // 检查是否是玩家进入触发器
        if (other.CompareTag("Player"))
        {
            uiButton.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 可选：当玩家离开触发器时隐藏UI
        if (other.CompareTag("Player"))
        {
            uiButton.gameObject.SetActive(false);

        }
    }
    void SoftwareSelfTest()
    {
        gameObject.SetActive(isShow);
        if (LocalTaskStatus!=GameManager.instance.taskStatus)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
