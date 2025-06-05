using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisconnectTheWireGlovesCanvas : MonoBehaviour
{
    public float moveDuration = 2f; // 移动持续时间
    public Vector3 moveDirection ; // 移动方向
    public float moveDistance; // 移动距离
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
            
            // 计算目标位置 = 当前位置 + 方向 * 距离
            Vector3 targetPosition = Positive.transform.position + moveDirection;

            // 执行移动
            Positive.transform.DOMove(targetPosition, moveDuration)
                .SetEase(Ease.OutQuad); // 添加缓动效果

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
