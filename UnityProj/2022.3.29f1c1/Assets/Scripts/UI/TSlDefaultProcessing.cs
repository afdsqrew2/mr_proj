using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class TSlDefaultProcessing : MonoBehaviour
{
    public Button uiButton; // ��ק���UI Image������
    public bool isShow; // ��ק���UI Image������
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
        // ����Ƿ�����ҽ��봥����
        if (other.CompareTag("Player"))
        {
            uiButton.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ��ѡ��������뿪������ʱ����UI
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
