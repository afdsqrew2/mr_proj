using System.Collections;
using UnityEngine;

public class Auto_Hide : MonoBehaviour
{
    [Tooltip("�����ӳ�ʱ�䣨�룩")]
    public float hideDelay = 3f;

    private void OnEnable()
    {
        // ÿ�ζ��󼤻�ʱ��������Э��
        StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        // �ȴ�ָ��������
        yield return new WaitForSeconds(hideDelay);

        // ������Ϸ����
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // ���󱻽���ʱֹͣ����Э�̣���ֹ�ڴ�й©
        StopAllCoroutines();
    }
}