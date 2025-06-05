using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class TaskStatusManager : MonoBehaviour
{
    public int TaskOneSteep=3;
    public int TaskTwoSteep=1;
    public int TaskThreeSteep=2;
   
    public void Awake()
    {
        EventCenter.AddListener(EventTypeCare.TaskOne, TaskOne);
        EventCenter.AddListener(EventTypeCare.TaskTwo, TaskTwo);
        EventCenter.AddListener(EventTypeCare.TaskThree, TaskThree);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypeCare.TaskOne);
        EventCenter.RemoveListener(EventTypeCare.TaskTwo);
        EventCenter.RemoveListener(EventTypeCare.TaskThree);
    }
    void TaskOne() 
    {
        if (TaskOneSteep == 0) 
        {
            GameManager.instance.taskStatus = TaskStatusCar.Two;
            EventCenter.Broadcast(EventTypeCare.SoftwareSelfTest);
            EventCenter.Broadcast(EventTypeCare.AnimationClears);
            
            //DOTween.RewindAll(); // 恢复所有动画到初始状态
        }
        else
        {
            TaskOneSteep --;
        }
    }
    void TaskTwo() 
    {
        if (TaskTwoSteep == 0)
        {
            GameManager.instance.taskStatus = TaskStatusCar.Three;
            EventCenter.Broadcast(EventTypeCare.SoftwareSelfTest);
            EventCenter.Broadcast(EventTypeCare.TaskThree);

        }
        else
        {
            TaskTwoSteep--;
        }
    }
    void TaskThree() { }
}
