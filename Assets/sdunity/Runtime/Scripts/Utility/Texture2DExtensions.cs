using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace DevGame.Utility
{
    public static class Texture2DExtensions
    {
        public static string EncodeToBase64(this Texture2D texture)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(texture.EncodeToJPG());
        }

        public static Texture2D Base64ToTexture2D(this string base64str, int width, int height)
        {
            var bytes = Convert.FromBase64String(base64str);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);
            return tex;
        }

        public static Texture2D ToTexture2D(this RenderTexture rt)
        {
            var tex = new Texture2D(rt.width, rt.height, rt.graphicsFormat, TextureCreationFlags.None);
            var old = RenderTexture.active;
            RenderTexture.active = rt;
            tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            tex.Apply();

            RenderTexture.active = old;
            return tex;
        }
    }
}