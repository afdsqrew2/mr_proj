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
            EditorApplication.isPlaying = false;  //Unity�����������˳�
#else
       Application.Quit(); //app�����˳�
#endif


        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
