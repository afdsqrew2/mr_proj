using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisconnectThePowerCord_AfterShieldes : MonoBehaviour
{
    public float moveDuration = 2f; // 移动持续时间
    public Vector3 moveDirection = Vector3.forward; // 移动方向
    public float moveDistance; // 移动距离
    public Button PositiveButton;
    public Button NegativeButton;
    public GameObject Positive;
    public GameObject Negative;
    // Start is called before the first frame update
    void Start()
    {
        PositiveButton.onClick.AddListener(() => {
            EventCenter.Broadcast(EventTypeCare.TaskOne);
            // 计算目标位置 = 当前位置 + 方向 * 距离
            Vector3 targetPosition = Positive. transform.position + moveDirection.normalized * moveDistance;

            // 执行移动
            Positive. transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // 添加缓动效果
            PositiveButton.gameObject.SetActive(false);

        });
        NegativeButton.onClick.AddListener(() => {

            EventCenter.Broadcast(EventTypeCare.TaskOne);
            // 计算目标位置 = 当前位置 + 方向 * 距离
            Vector3 targetPosition = Negative. transform.position + moveDirection.normalized * moveDistance;

            // 执行移动
           
            Negative.transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // 添加缓动效果
            NegativeButton.gameObject.SetActive(false);
        });
    }
    /*
      // 计算目标位置 = 当前位置 + 方向 * 距离
        Vector3 targetPosition = transform.position + moveDirection.normalized * moveDistance;
        
        // 执行移动
        transform.DOMove(targetPosition, moveDuration)
            .SetEase(Ease.OutQuad); // 添加缓动效果
     */
    // Update is called once per frame
    void Update()
    {
        
    }
}
