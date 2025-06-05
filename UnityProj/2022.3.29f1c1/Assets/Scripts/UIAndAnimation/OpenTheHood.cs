using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheHood : MonoBehaviour
{
    public GameObject Hood;
    public GameObject TSLShieldsControlCanvas;
    public float duration = 1f; // 旋转持续时间
    public Vector3 rotationAmount = new Vector3(0, 0, 90); // 旋转角度
    public Vector3 initialRotation; // 存储初始旋转
    void Awake()
    {
        
        EventCenter.AddListener(EventTypeCare.OpenTheHood, OpenTheHoodBySubscription);
        EventCenter.AddListener(EventTypeCare.AnimationClears, AnimationClears);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.OpenTheHood);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = Hood.transform.localEulerAngles;
        //initialRotation = Hood.transform.localRotation;
        GetComponent<TSlDefaultProcessing>().uiButton.onClick.AddListener(delegate { EventCenter.Broadcast(EventTypeCare.OpenTheHood); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenTheHoodBySubscription()
    {
        Hood.transform.DORotate(rotationAmount, duration, RotateMode.LocalAxisAdd)
          .SetEase(Ease.OutQuad).OnComplete(() => {

              TSLShieldsControlCanvas.SetActive(true);
          }); // 添加缓动效果
    }
    void AnimationClears()
    {
        Hood.transform.localEulerAngles = initialRotation;
        //Hood.transform.localRotation= initialRotation;
    }
}
