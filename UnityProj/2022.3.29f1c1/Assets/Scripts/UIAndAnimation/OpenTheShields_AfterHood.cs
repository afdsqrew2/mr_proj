using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheShields_AfterHood : MonoBehaviour
{
    public GameObject Shields;
    public GameObject TSLPowerCordControlCanvas;
    // Start is called before the first frame update
    void Start()
    {
        TSLPowerCordControlCanvas.SetActive(false);
        GetComponent<TSlDefaultProcessing>().uiButton.onClick.AddListener(delegate { Shields.SetActive(false); TSLPowerCordControlCanvas.SetActive(true); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
