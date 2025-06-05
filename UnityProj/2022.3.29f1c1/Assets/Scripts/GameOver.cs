using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    public GameObject gameObject1;
    public float fadeDuration = 3f; // ��������ʱ�䣨�룩
    public float delayBeforeFade = 2f;  // �ӳ�ʱ�䣨�룩
    private void Awake()
    {
        EventCenter.AddListener(EventTypeCare.GameOver, GameOverqwe);
    }
    // Start is called before the first frame update
    void GameOverqwe()
    {
       
    }
    IEnumerator qwe()
    {  yield return new WaitForSeconds(delayBeforeFade);
        gameObject1.SetActive(true);
        gameObject1.GetComponent<Image>().DOFade(0f, fadeDuration).SetDelay(delayBeforeFade)
            .OnComplete(() => gameObject1.SetActive(true)); // ��ѡ��������ɺ�ִ�лص�
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
