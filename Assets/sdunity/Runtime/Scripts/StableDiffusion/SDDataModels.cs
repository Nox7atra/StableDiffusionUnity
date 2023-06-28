using System;
using System.Collections.Generic;
using DevGame.Utility;
using UnityEngine;

namespace DevGame.StableDiffusion
{
    [Serializable]
    public class SDConfig
    {
        [StringArray(new []{"Euler a",
            "Euler",
            "LMS",
            "Heun",
            "DPM2",
            "DPM2 a",
            "DPM++ 2S a",
            "DPM++ 2M",
            "DPM++ SDE",
            "DPM fast",
            "DPM adaptive",
            "LMS Karras",
            "DPM2 Karras",
            "DPM2 a Karras",
            "DPM++ 2S a Karras",
            "DPM++ 2M Karras",
            "DPM++ SDE Karras",
            "DDIM",
            "PLMS"})] public string sampler_name = "DPM++ 2M Karras";

        [TextArea] public string prompt;
        [TextArea] public string negative_prompt;
        public int seed;
        [Range(1, 150)] public int steps = 20;
        [Range(1, 30f)] public float cfg_scale = 7;
        public int width = 512;
        public int height = 512;
        public bool restore_faces;
        public int batch_size = 1;
    }
    [Serializable]
    public class ImgToImgConfig : SDConfig
    {
        public List<string> init_images;
        [Range(0, 1f)] public double denoising_strength = 0.7f;
    }

    [Serializable]
    public class ImgToImgResponse
    {
        public string[] images;
        public int width;
        public int height;
    }
}