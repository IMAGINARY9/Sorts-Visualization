using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SliderObject : MonoBehaviour
    {
        [SerializeField]
        private float initValue;
        [SerializeField]
        private float min, max;
        [SerializeField]
        private bool isWholeNumbers;

        [SerializeField]
        private TextMeshProUGUI tmp;

        [SerializeField]
        private Slider slider;

        public event Action<float> OnSliderChange;

        private void Start()
        {
            slider.wholeNumbers = isWholeNumbers;
            slider.minValue = min;
            slider.maxValue = max;

            slider.value = initValue;

            slider.onValueChanged.AddListener(delegate { UpdateData(); });
            StartCoroutine(InitRoutine());
        }

        IEnumerator InitRoutine()
        {
            yield return new WaitForFixedUpdate();
            UpdateData();
        }

        public void SetMax(float value)
        {
            slider.maxValue = value;
            if (slider.value > value)
                slider.value = slider.maxValue;
        }

        private void UpdateData()
        {
            tmp.SetText(slider.value.ToString());
            OnSliderChange?.Invoke(slider.value);
        }

    }
}