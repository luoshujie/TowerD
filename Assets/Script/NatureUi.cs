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
        public Button cancelBtn;
        private HeroData data;

        private Action cancelComplete;
        private Action skillComplete;
        private void Awake()
        {
            cancelBtn.onClick.AddListener(()=>{cancelComplete?.Invoke();});
            skillBtn.onClick.AddListener(()=>{skillComplete?.Invoke();});
        }

        public void Init(HeroData heroData,Action cancelCallback,Action skillCallback)
        {
            cancelComplete = cancelCallback;
            skillComplete = skillCallback;
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
            if (skillProgressImg.fillAmount==1)
            {
                skillBtn.interactable = true;
            }
            else if (skillBtn.interactable)
            {
                skillBtn.interactable = false;
            }
            
        }

        public void ShowCancelBtn(bool state)
        {
            cancelBtn.gameObject.SetActive(state);
        }
    }
}