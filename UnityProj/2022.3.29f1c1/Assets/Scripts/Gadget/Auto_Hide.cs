using System.Collections;
using UnityEngine;

public class Auto_Hide : MonoBehaviour
{
    [Tooltip("隐藏延迟时间（秒）")]
    public float hideDelay = 3f;

    private void OnEnable()
    {
        // 每次对象激活时启动隐藏协程
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(hideDelay);

        // 隐藏游戏对象
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // 对象被禁用时停止所有协程，防止内存泄漏
        StopAllCoroutines();
    }
}