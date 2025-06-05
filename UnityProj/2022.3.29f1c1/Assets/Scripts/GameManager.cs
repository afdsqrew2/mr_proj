
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    # region 单例设置
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != null)
        {
            //Debug.Log("不创建");
            Destroy(this);
        }

    }
    #endregion
    public enum TaskStatusCar
    {
        One,
        Two,
        Three,
    }
    #region 汽车零件
    [Header("车前门")]
    public Transform driverCarDoor;
    [Header("车后门")]
    public Transform RearCarDoor;
    [Header("引擎盖子")]
    public Transform Hood;
    [Header("后座椅子")]
    public Transform RearSeats;
    #endregion
    #region 场景关联组件
    [Header("汽车熄火按钮UI")]
    public Button TSLScreen_CarStalled;
    #endregion
    public TaskStatusCar taskStatus = TaskStatusCar.One;

    public GameObject TaskTwoBracket;

    public GameObject TaskTwoCar;
    public GameObject TaskTwoBracketOne;
    public GameObject TaskTwoBracketTwo;
    public GameObject TaskTwoBracketThree;
    public GameObject TaskTwoBracketFour;

    public Button TaskTwoBracketOneButton;
    public Button TaskTwoBracketTwoButton;
    public Button TaskTwoBracketThreeButton;
    public Button TaskTwoBracketFourButton;

    public bool ShakeCarOver=false;
}
