using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Right : MonoBehaviour
{
    
    public GameObject right;
    private void Awake()
    {
        
        EventCenter.AddListener(EventTypeCare.WearRightGlove, WearRightGlove);
    }
    // Start is called before the first frame update
    void Start()
    {
        right.SetActive(false);
    }

    // Update is called once per frame
    void WearRightGlove()
    {
        right.SetActive(true);
    }
}
