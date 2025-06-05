using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rawimageset : MonoBehaviour
{
    public RawImage sourceRawImage;
    public Image targetImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if (sourceRawImage.texture is RenderTexture)
        {
            // 转换 RenderTexture 为 Texture2D
            RenderTexture renderTexture = sourceRawImage.texture as RenderTexture;
            RenderTexture.active = renderTexture;
            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = null;

            // 生成 Sprite
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
            targetImage.sprite = sprite;
        }
        else if (sourceRawImage.texture is Texture2D)
        {
            // 直接转换 Texture2D
            Texture2D texture2D = sourceRawImage.texture as Texture2D;
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
            targetImage.sprite = sprite;
        }
    }
}
