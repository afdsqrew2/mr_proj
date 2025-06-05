
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    # region ��������
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
            //Debug.Log("������");
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
    #region �������
    [Header("��ǰ��")]
    public Transform driverCarDoor;
    [Header("������")]
    public Transform RearCarDoor;
    [Header("�������")]
    public Transform Hood;
    [Header("��������")]
    public Transform RearSeats;
    #endregion
    #region �����������
    [Header("����Ϩ��ťUI")]
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
