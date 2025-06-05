
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
public enum GantryState
{
    Check_in,//�����
    CheckOver,//"��ȫ���"����
    CheckEndAndOver,//���żܵĿ��ۼ�����
}
public class TSLRemoteControlCanvas : MonoBehaviour
{

    public Button Up;
    public Button Down;
    public Button Check;
    public Button SafetyLocks;
    public GameObject Tip;
    public bool CheckBool=true;

    
    public GantryState gantryState;
    private Vector3 originalPos1; // ����longmenjia��ʼλ��
    private Vector3 originalPos2; // ����2������ʼλ��
    private Sequence currentSequence; // ��ǰ��������
    public float moveDistance = 2f; // ÿ���ƶ�����
    public float moveDuration = 1f; // �ƶ�����ʱ��
    public float maxHeight = 5f; // ���߶�����
    public float minHeight = 0f; // ��С�߶�����
    public int CantileverNumber = 4;
    private void Awake()
    {
        EventCenter.AddListener(EventTypeCare.TheCantileverIsFullyRotated, TheCantileverIsFullyRotated);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.TheCantileverIsFullyRotated);
    }
    private void Start()
    {
        Tip.SetActive(false);
        // �����ʼλ��
        originalPos1 = GameManager.instance.TaskTwoBracket.transform.position;
        originalPos2 = GameManager.instance.TaskTwoCar.transform.position;
        GameManager.instance.TaskTwoBracketOneButton.gameObject.SetActive(false);
        GameManager.instance.TaskTwoBracketTwoButton.gameObject.SetActive(false);
        GameManager.instance.TaskTwoBracketThreeButton.gameObject.SetActive(false);
        GameManager.instance.TaskTwoBracketFourButton.gameObject.SetActive(false);
        Up.onClick.AddListener(delegate {
            
            if (GameManager.instance.taskStatus != TaskStatusCar.Two)
            {
                return;
            }
            if(gantryState== GantryState.CheckOver)
            {
                // ֹͣ��ǰ����
                if (currentSequence != null && currentSequence.IsActive())
                {
                    currentSequence.Kill();
                }

                // �����µĶ�������
                currentSequence = DOTween.Sequence();

                if (GameManager.instance.TaskTwoBracket.transform.position.y + moveDistance <= maxHeight)
                {
                    // ����1�����ƶ�
                    currentSequence.Join(GameManager.instance.TaskTwoBracket.transform.DOMoveY(GameManager.instance.TaskTwoBracket.transform.position.y + moveDistance, moveDuration)
                        .SetEase(Ease.OutQuad));
                }
                
            }
            else
            {
                if (GameManager.instance.TaskTwoBracket.transform.position.y + moveDistance <= maxHeight)
                {
                    currentSequence.Join(GameManager.instance.TaskTwoBracket.transform.DOMoveY(GameManager.instance.TaskTwoBracket.transform.position.y + moveDistance, moveDuration)
                   .SetEase(Ease.OutQuad));
                    currentSequence.Join(GameManager.instance.TaskTwoCar.transform.DOMoveY(GameManager.instance.TaskTwoCar.transform.position.y + moveDistance, moveDuration)
                       .SetEase(Ease.OutQuad));
                    
                }
                EventCenter.Broadcast(EventTypeCare.ShakeCare);
            }
        });
        Down.onClick.AddListener(delegate {
            if (GameManager.instance.taskStatus != TaskStatusCar.Two)
            {
                return;
            }
            if (gantryState == GantryState.CheckOver)
            {
                // ֹͣ��ǰ����
                if (currentSequence != null && currentSequence.IsActive())
                {
                    currentSequence.Kill();
                }

                // �����µĶ�������
                currentSequence = DOTween.Sequence();

                if (GameManager.instance.TaskTwoBracket.transform.position.y - moveDistance >= minHeight)
                {
                    ;
                    // ����1�����ƶ�
                    currentSequence.Join(GameManager.instance.TaskTwoBracket.transform.DOMoveY(GameManager.instance.TaskTwoBracket.transform.position.y - moveDistance, moveDuration)
                        .SetEase(Ease.OutQuad));
                }
                
            }
            else 
            {
                if (GameManager.instance.TaskTwoBracket.transform.position.y - moveDistance >= minHeight)//����
                {
                    currentSequence.Join(GameManager.instance.TaskTwoBracket.transform.DOMoveY(GameManager.instance.TaskTwoBracket.transform.position.y - moveDistance, moveDuration)
                   .SetEase(Ease.OutQuad));
                    currentSequence.Join(GameManager.instance.TaskTwoCar.transform.DOMoveY(GameManager.instance.TaskTwoCar.transform.position.y - moveDistance, moveDuration)
                       .SetEase(Ease.OutQuad));
                }
                EventCenter.Broadcast(EventTypeCare.Can_tShakeCare);

            }
        });
        Check.onClick.AddListener(delegate {
            
            if (GameManager.instance.taskStatus != TaskStatusCar.Two)
            {
                return;
            }
            if (GameManager.instance.ShakeCarOver)
            {
                return;
            }
            if(CheckBool)
            {
                CheckBool = !CheckBool;
            }
            else
            {
                return;
            }
            GameManager.instance.TaskTwoBracketOneButton.gameObject.SetActive(true);
            GameManager.instance.TaskTwoBracketTwoButton.gameObject.SetActive(true);
            GameManager.instance.TaskTwoBracketThreeButton.gameObject.SetActive(true);
            GameManager.instance.TaskTwoBracketFourButton.gameObject.SetActive(true);
            Tip.SetActive(true);
            ResetPositions();
            gantryState = GantryState.CheckOver;
            EventCenter.Broadcast(EventTypeCare.SoftwareSelfTest);
            EventCenter.Broadcast(EventTypeCare.TheSecurityCheckIsComplete);
        });
        SafetyLocks.onClick.AddListener(delegate {
            if(GameManager.instance.ShakeCarOver) 
                EventCenter.Broadcast(EventTypeCare.TaskTwo); });
    }
    public void ResetPositions()
    {
        
        // ֹͣ��ǰ����
        if (currentSequence != null && currentSequence.IsActive())
        {
            currentSequence.Kill();
        }

        GameManager.instance.TaskTwoBracket.transform.position = originalPos1;
        GameManager.instance.TaskTwoCar.transform.position = originalPos2;
    }
    void TheCantileverIsFullyRotated()
    {
        if (CantileverNumber == 1)
            EventCenter.Broadcast(EventTypeCare.TheCantileverIsFullyRotatedInformation);
        else
            CantileverNumber--;
    }
}
