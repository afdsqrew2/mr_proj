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
            Debug.Log($"���� {other.name} ���봥����{gameObject.name}");
            Videsos.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"���� {other.name} ����ͣ���ڴ�����");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����뿪��������");
            Videsos.Pause();
        }
    }
}
