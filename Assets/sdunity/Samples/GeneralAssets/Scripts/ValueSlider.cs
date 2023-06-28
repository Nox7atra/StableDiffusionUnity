using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevGame.StableDiffusion.Samples
{
    public class ValueSlider : MonoBehaviour
    {
        [SerializeField] private float _minValue;
        [SerializeField] private float _maxValue;
        [SerializeField] private float _defaultValue;
        [SerializeField] private bool _isInteger;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _valuePreview;
        public int IntValue => (int) Mathf.Lerp(_minValue, _maxValue, _slider.value);
        public float FloatValue => Mathf.Lerp(_minValue, _maxValue, _slider.value);

        private void Start()
        {
            _slider.value = (_defaultValue - _minValue) / (_maxValue - _minValue);
        }

        private void Update()
        {
            _valuePreview.text = _isInteger ? IntValue.ToString() : FloatValue.ToString(CultureInfo.InvariantCulture);
        }
    }
}