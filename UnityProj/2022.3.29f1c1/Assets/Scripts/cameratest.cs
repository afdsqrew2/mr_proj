using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameratest : MonoBehaviour
{
    // 获取 RawImage 组件并应用 Render Texture
    public RawImage rawImage;

    // 最新更改为动态生成 Render Texture
    [Header("动态生成--RenderTexture")]
    public int textureWidth = 512;
    public int textureHeight = 512;
    // 格式, RenderTextureFormat.ARGB32 或 RenderTextureFormat.Default 
    // 貌似都是 [ R8B8G8A8_UNORM ]
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
        // ---------- 用于动态生成 RT ---------
        // 动态找相机
        //cam = GameObject.Find("Camera_For_RT").GetComponent<Camera>();
        // 创建 Render Texture
        renderTexture = new RenderTexture(textureWidth, textureHeight, 24, textureFormat);
        renderTexture.Create();
        //必须为 CameraClearFlags.SolidColor或CameraClearFlags.Depth，CameraClearFlags.Nothing 时会不显示
        

        
        // 将 Render Texture 附加到像机
        cam.targetTexture = renderTexture;
        // 将其应用到UI
        if (rawImage != null)
        {
            rawImage.texture = renderTexture;
        }
        // ----------------------------------
    }
    void OnDisable()
    {
        // 清理 Render Texture
        if (renderTexture != null)
        {
            renderTexture.Release();
            renderTexture = null;
        }
    }


}
