using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Collbylou : MonoBehaviour
{
    VideoPlayer Videsos;
    // Start is called before the first frame update
    void Start()
    {
        Videsos= transform.GetChild(0).GetComponent<VideoPlayer>();
        Videsos.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"对象 {other.name} 进入触发区{gameObject.name}");
            Videsos.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"对象 {other.name} 持续停留在触发区");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家离开触发区！");
            Videsos.Pause();
        }
    }
}
