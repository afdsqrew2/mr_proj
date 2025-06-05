using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class TaskShakeCareCanvas : MonoBehaviour
{
    public Button Shake;
    public int CantileverNumber=4;
    public bool Inspected = false;
    
    public void Awake()
    {
        EventCenter.AddListener(EventTypeCare.TheCantileverIsFullyInspected, TheCantileverIsFullyInspected);
        EventCenter.AddListener(EventTypeCare.ShakeCare, ShakeCare);
        EventCenter.AddListener(EventTypeCare.Can_tShakeCare, Can_tShakeCare);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.TheCantileverIsFullyRotated);
        EventCenter.RemoveListener(EventTypeCare.ShakeCare);
        EventCenter.RemoveListener(EventTypeCare.Can_tShakeCare);
        EventCenter.RemoveListener(EventTypeCare.TaskThree);
    }
    void Start()//
    {
        Shake.gameObject.SetActive(false);
        Shake.onClick.AddListener(delegate {
            GameManager.instance.ShakeCarOver = true;
            Shake.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void TheCantileverIsFullyInspected()
    {
        if (CantileverNumber == 1)
            Inspected = true;
            
        else
            CantileverNumber--;

    }//
    void ShakeCare()
    {
        
        if (Inspected)
        {
            Shake.gameObject.SetActive(true);
            
        }
        
    }
    void Can_tShakeCare()
    {
        Shake.gameObject.SetActive(false);
    }
}
