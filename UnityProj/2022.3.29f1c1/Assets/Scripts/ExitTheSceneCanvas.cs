using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExitTheSceneCanvas : MonoBehaviour
{
    public Button ExitButton;
    void Start()
    {
        ExitButton.onClick.AddListener(delegate {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;  //Unity调试器运行退出
#else
       Application.Quit(); //app本体退出
#endif


        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
