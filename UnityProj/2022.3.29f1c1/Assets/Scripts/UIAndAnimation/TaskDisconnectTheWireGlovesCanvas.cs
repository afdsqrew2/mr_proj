using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisconnectTheWireGlovesCanvas : MonoBehaviour
{
    public float moveDuration = 2f; // �ƶ�����ʱ��
    public Vector3 moveDirection ; // �ƶ�����
    public float moveDistance; // �ƶ�����
    public Button PositiveButton;//

    public GameObject Positive;
    public GameObject Negative;
    public GameObject TaskwwybCanvas;

    public GameObject hong;
    public GameObject hei;
    public GameObject wwyb;
    int number = 2;
    private void Awake()
    {
        
        EventCenter.AddListener(EventTypeCare.WearLeftGlove, WearGlove);
        EventCenter.AddListener(EventTypeCare.WearRightGlove, WearGlove);
    }
    // Start is called before the first frame update
    void Start()
    {
        TaskwwybCanvas.SetActive(false);
        
        PositiveButton.onClick.AddListener(() => {
            
            // ����Ŀ��λ�� = ��ǰλ�� + ���� * ����
            Vector3 targetPosition = Positive.transform.position + moveDirection;

            // ִ���ƶ�
            Positive.transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // ��ӻ���Ч��

            wwyb.SetActive(true);
            TaskwwybCanvas.gameObject.SetActive(true);
            PositiveButton.gameObject.SetActive(false);
        });

    }

    // Update is called once per frame
    void WearGlove()
    {
        if(number<=1)
        {
            PositiveButton.gameObject.SetActive(true);
        }
        else
        {
            number--;
        }
    }
}
