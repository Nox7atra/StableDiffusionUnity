using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevGame.StableDiffusion.Samples
{
    public class Txt2ImgGenerator : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _promt;
        [SerializeField] private TMP_InputField _negativePromt;
        [SerializeField] private ValueSlider _width;
        [SerializeField] private ValueSlider _height;
        [SerializeField] private ValueSlider _samples;
        [SerializeField] private ValueSlider _cfgScale;
        [SerializeField] private Button _generateButton;
        [SerializeField] private GameObject _loader;
        [SerializeField] private SDConfig _sdConfig;
        [SerializeField] private SDProcessor _sdProcessor;
        [SerializeField] private RawImage _resultPreview;

        private Texture2D[] _result;

        public void GenerateImage()
        {
            _sdConfig.prompt = _promt.text;
            _sdConfig.negative_prompt = _negativePromt.text;
            _sdConfig.width = _width.IntValue;
            _sdConfig.height = _height.IntValue;
            _sdConfig.steps = _samples.IntValue;
            _sdConfig.cfg_scale = _cfgScale.IntValue;
            _generateButton.interactable = false;
            _loader.SetActive(true);
            StartCoroutine(_sdProcessor.TextToImageAsync(_sdConfig, result =>
            {
                _generateButton.interactable = true;
                _loader.SetActive(false);
                _result = result;
                _resultPreview.texture = _result[0];
            }));
        }
    }
}