using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameratest : MonoBehaviour
{
    // ��ȡ RawImage �����Ӧ�� Render Texture
    public RawImage rawImage;

    // ���¸���Ϊ��̬���� Render Texture
    [Header("��̬����--RenderTexture")]
    public int textureWidth = 512;
    public int textureHeight = 512;
    // ��ʽ, RenderTextureFormat.ARGB32 �� RenderTextureFormat.Default 
    // ò�ƶ��� [ R8B8G8A8_UNORM ]
    public RenderTextureFormat textureFormat = RenderTextureFormat.ARGB32;
    public RenderTexture renderTexture;
    public Camera cam;
    public Camera camout;


    void Start()
    {
        StartCoroutine(qwe());
    }

    IEnumerator qwe()
    {
        yield return new WaitForSeconds(1f);
        // ---------- ���ڶ�̬���� RT ---------
        // ��̬�����
        //cam = GameObject.Find("Camera_For_RT").GetComponent<Camera>();
        // ���� Render Texture
        renderTexture = new RenderTexture(textureWidth, textureHeight, 24, textureFormat);
        renderTexture.Create();
        //����Ϊ CameraClearFlags.SolidColor��CameraClearFlags.Depth��CameraClearFlags.Nothing ʱ�᲻��ʾ
        

        
        // �� Render Texture ���ӵ����
        cam.targetTexture = renderTexture;
        // ����Ӧ�õ�UI
        if (rawImage != null)
        {
            rawImage.texture = renderTexture;
        }
        // ----------------------------------
    }
    void OnDisable()
    {
        // ���� Render Texture
        if (renderTexture != null)
        {
            renderTexture.Release();
            renderTexture = null;
        }
    }


}
