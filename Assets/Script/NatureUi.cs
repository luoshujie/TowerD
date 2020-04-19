using System;
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
        public Button cancelBtn;
        private HeroData data;

        private Action cancelComplete;
        private void Awake()
        {
            cancelBtn.onClick.AddListener(()=>{cancelComplete?.Invoke();});
            skillBtn.onClick.AddListener(()=>{});
        }

        public void Init(HeroData heroData,Action cancelCallback)
        {
            cancelComplete = cancelCallback;
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

        public void ShowCancelBtn()
        {
            cancelBtn.gameObject.SetActive(!cancelBtn.gameObject.activeSelf);
        }
    }
}