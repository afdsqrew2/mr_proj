using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisconnectThePowerCord_AfterShieldes : MonoBehaviour
{
    public float moveDuration = 2f; // �ƶ�����ʱ��
    public Vector3 moveDirection = Vector3.forward; // �ƶ�����
    public float moveDistance; // �ƶ�����
    public Button PositiveButton;
    public Button NegativeButton;
    public GameObject Positive;
    public GameObject Negative;
    // Start is called before the first frame update
    void Start()
    {
        PositiveButton.onClick.AddListener(() => {
            EventCenter.Broadcast(EventTypeCare.TaskOne);
            // ����Ŀ��λ�� = ��ǰλ�� + ���� * ����
            Vector3 targetPosition = Positive. transform.position + moveDirection.normalized * moveDistance;

            // ִ���ƶ�
            Positive. transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // ��ӻ���Ч��
            PositiveButton.gameObject.SetActive(false);

        });
        NegativeButton.onClick.AddListener(() => {

            EventCenter.Broadcast(EventTypeCare.TaskOne);
            // ����Ŀ��λ�� = ��ǰλ�� + ���� * ����
            Vector3 targetPosition = Negative. transform.position + moveDirection.normalized * moveDistance;

            // ִ���ƶ�
           
            Negative.transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // ��ӻ���Ч��
            NegativeButton.gameObject.SetActive(false);
        });
    }
    /*
      // ����Ŀ��λ�� = ��ǰλ�� + ���� * ����
        Vector3 targetPosition = transform.position + moveDirection.normalized * moveDistance;
        
        // ִ���ƶ�
        transform.DOMove(targetPosition, moveDuration)
            .SetEase(Ease.OutQuad); // ��ӻ���Ч��
     */
    // Update is called once per frame
    void Update()
    {
        
    }
}
