using Script.Role.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class NatureUi : MonoBehaviour
    {
        public Slider lifeSlider;
        public Button skillBtn;
        public Image skillProgressImg;
        public Image skillImg;

        private HeroData data;

        public void Init(HeroData heroData)
        {
            data = heroData;
//            skillImg.sprite
            UpdateLifeDisplay();
            UpdateEnergy();
        }

        public void UpdateLifeDisplay()
        {
            lifeSlider.maxValue = data.MaxLife;
            lifeSlider.value = data.Life;
        }

        public void UpdateEnergy()
        {
            skillProgressImg.fillAmount = data.Energy * 1f / data.MaxEnergy;
        }
    }
}