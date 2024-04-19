using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private SliderObject arraySizeSlider;
        [SerializeField]
        private SliderObject animationDelaySlider;
        [SerializeField]
        private SliderObject searchValueSlider;

        private void Start()
        {
            arraySizeSlider.OnSliderChange += ArraySizeChange;
            animationDelaySlider.OnSliderChange += (float value) => VisualData.Delay = value;
            searchValueSlider.OnSliderChange += (float value) => ArrayModifier.SearchValue = (int)value;
        }

        private void ArraySizeChange(float value)
        {
            ArrayGenerator.Size = (int)value;
            searchValueSlider.SetMax(value);
        }


    }
}