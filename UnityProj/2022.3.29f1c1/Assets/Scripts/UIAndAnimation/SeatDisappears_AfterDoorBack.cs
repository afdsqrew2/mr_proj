using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatDisappears_AfterDoorBack : MonoBehaviour
{
    public GameObject Seat;
    public GameObject TSLSeatControlCanvas ;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TSlDefaultProcessing>().uiButton.onClick.AddListener(() => {
            Seat.SetActive(false);
            TSLSeatControlCanvas.SetActive(true);
            TSLSeatControlCanvas.GetComponent<TSlDefaultProcessing>().uiButton.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
