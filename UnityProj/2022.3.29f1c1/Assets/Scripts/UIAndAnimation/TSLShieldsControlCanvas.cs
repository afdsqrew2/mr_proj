using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TSLShieldsControlCanvas : MonoBehaviour
{
    
    public GameObject model;
   

    // Start is called before the first frame update
    void Start()
    {
        model.SetActive(false);
        GetComponent<TSlDefaultProcessing>().uiButton.onClick.AddListener(delegate { model.SetActive(true); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
