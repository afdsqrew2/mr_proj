using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheHood : MonoBehaviour
{
    public GameObject Hood;
    public GameObject TSLShieldsControlCanvas;
    public float duration = 1f; // ��ת����ʱ��
    public Vector3 rotationAmount = new Vector3(0, 0, 90); // ��ת�Ƕ�
    public Vector3 initialRotation; // �洢��ʼ��ת
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
          }); // ��ӻ���Ч��
    }
    void AnimationClears()
    {
        Hood.transform.localEulerAngles = initialRotation;
        //Hood.transform.localRotation= initialRotation;
    }
}
