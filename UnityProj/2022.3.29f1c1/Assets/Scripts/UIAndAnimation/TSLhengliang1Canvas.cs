using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class TSLhengliang1Canvas : MonoBehaviour
{
    public GameObject hengliang1;
    public Button is_Button;
    public bool is_OK=false;
    public Button CheckTheCardSlotSecurity;//
    public float resetDuration = 1f; // 归零持续时间
    public Ease easeType = Ease.OutBack; // 缓动效果
    public GantryState gantryState;

    public Vector3 targetRotation = new Vector3(0, 90, 0);
    // Start is called before the first frame update
    private void Awake()
    {
        EventCenter.AddListener(EventTypeCare.SoftwareSelfTest, SoftwareSelfTest);
        EventCenter.AddListener(EventTypeCare.TheSecurityCheckIsComplete, TheSecurityCheckIsComplete);
        EventCenter.AddListener(EventTypeCare.TheCantileverIsFullyRotatedInformation, TheCantileverIsFullyRotatedInformation);
        
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.SoftwareSelfTest);
        EventCenter.RemoveListener(EventTypeCare.TheCantileverIsFullyRotatedInformation);
        
    }
    void Start()
    {
        CheckTheCardSlotSecurity.gameObject.SetActive(false);
        is_Button.gameObject.SetActive(false);
        //hengliang1 = transform.parent.gameObject;
        //_Button=gameObject.GetComponent<Button>();
        is_Button.onClick.AddListener(delegate {
            if (!is_OK)
                return;
            hengliang1.transform.DORotate(targetRotation, resetDuration)
    .SetEase(easeType)
    .OnComplete(delegate { EventCenter.Broadcast(EventTypeCare.TheCantileverIsFullyRotated); is_Button.gameObject.SetActive(false); } );

        });
        CheckTheCardSlotSecurity.onClick.AddListener(delegate { EventCenter.Broadcast(EventTypeCare.TheCantileverIsFullyInspected); gameObject.SetActive(false); });

    }
    void SoftwareSelfTest()
    {
        if(GameManager.instance.taskStatus != TaskStatusCar.Two)
        {
            return;
        }
        if (gantryState != GantryState.CheckOver)
        {
            return;
        }
        gameObject.SetActive(true);
    }
    // Update is called once per frame    
    public void TheCantileverIsFullyRotatedInformation()
    {
        CheckTheCardSlotSecurity.gameObject.SetActive(true);
    }
    public void TheSecurityCheckIsComplete()
    {
        is_OK = true;
    }
}
