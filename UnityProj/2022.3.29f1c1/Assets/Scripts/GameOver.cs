using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    public GameObject gameObject1;
    public float fadeDuration = 3f; // 淡出持续时间（秒）
    public float delayBeforeFade = 2f;  // 延迟时间（秒）
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
            .OnComplete(() => gameObject1.SetActive(true)); // 可选：淡出完成后执行回调
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
