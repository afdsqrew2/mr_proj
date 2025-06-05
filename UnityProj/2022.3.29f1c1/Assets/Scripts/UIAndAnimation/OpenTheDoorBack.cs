using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoorBack : MonoBehaviour
{
    public GameObject Door;
    public GameObject CarStartsButton;
    public GameObject TSLSeatControlCanvas;
    public float duration = 1f; // 旋转持续时间
    public Vector3 rotationAmount = new Vector3(0, 90, 0); // 旋转角度
    public Vector3 initialRotation; // 存储初始旋转
    void Awake()
    {
        EventCenter.AddListener(EventTypeCare.AnimationClears, AnimationClears);
        EventCenter.AddListener(EventTypeCare.OpenTheDoorBack, OpenTheDoorBySubscriptionAfter);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.OpenTheDoorBack);

    }
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = Door.transform.localEulerAngles;
        GetComponent<TSlDefaultProcessing>().uiButton.onClick.AddListener(delegate { EventCenter.Broadcast(EventTypeCare.OpenTheDoorBack); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenTheDoorBySubscriptionAfter()
    {
        Door.transform.DORotate(rotationAmount, duration, RotateMode.LocalAxisAdd)
          .SetEase(Ease.OutQuad).OnComplete(delegate { 
              CarStartsButton.SetActive(true);
              TSLSeatControlCanvas.SetActive(true);
          }); // 添加缓动效果
    }
    void AnimationClears()
    {
        Door.transform.localEulerAngles = initialRotation;
    }
}
