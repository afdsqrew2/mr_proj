using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject Door;
    public float duration = 1f; // ��ת����ʱ��
    public Vector3 rotationAmount = new Vector3(0, 90, 0); // ��ת�Ƕ�
    public Vector3 initialRotation; // �洢��ʼ��ת
    void Awake()
    {
        EventCenter.AddListener(EventTypeCare.OpenTheDoorFront, OpenTheDoorBySubscription);
        EventCenter.AddListener(EventTypeCare.AnimationClears, AnimationClears);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.OpenTheDoorFront);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = Door.transform.localEulerAngles;
        GetComponent<TSlDefaultProcessing>(). uiButton.onClick.AddListener(delegate { OpenTheDoorBySubscription(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OpenTheDoorBySubscription()
    {
        Door. transform.DORotate(rotationAmount, duration, RotateMode.LocalAxisAdd)
          .SetEase(Ease.OutQuad); // ��ӻ���Ч��
    }
    void AnimationClears()
    {
        Door.transform.localEulerAngles = initialRotation;
    }
}
