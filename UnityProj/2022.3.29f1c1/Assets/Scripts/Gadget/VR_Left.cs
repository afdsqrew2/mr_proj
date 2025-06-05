using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Left : MonoBehaviour
{
    public GameObject Left;
    private void Awake()
    {
        
        EventCenter.AddListener(EventTypeCare.WearLeftGlove, WearLeftGlove);
    }
    // Start is called before the first frame update
    void Start()
    {
        Left.SetActive(false);
    }

    // Update is called once per frame
    void WearLeftGlove()
    {
        Left.SetActive(true);
    }
}
