
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskwwybCanvas : MonoBehaviour
{
    public GameObject hong;
    public GameObject hei;
    public GameObject wwyb;
    public GameObject _image;
    public Button tiaoxuanniu;
    public Button celiang;
    public float duration = 1f;
    public Vector3 targetRotation ; // Ä¿±êÅ·À­½Ç
    // Start is called before the first frame update
    void Start()
    {
        tiaoxuanniu.gameObject.SetActive(true);
        celiang.gameObject.SetActive(true);
        tiaoxuanniu.onClick.AddListener(delegate {
            wwyb.transform.DORotate(targetRotation, duration, RotateMode.LocalAxisAdd)
          .SetEase(Ease.OutQuad);
        });
        celiang.onClick.AddListener(delegate { hei.SetActive(true); hong.SetActive(true); _image.SetActive(true); EventCenter.Broadcast(EventTypeCare.GameOver); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
