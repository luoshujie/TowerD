using System;
using System.Collections.Generic;
using Script.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class HeroDescWindow : MonoBehaviour
    {
        public Button closeBtn;
        public Button closeAllBtn;
        public Image herImg;
        public List<Sprite> heroImgList;

        private void Awake()
        {
            closeBtn.onClick.AddListener(() =>
            {
                MainMgr.instance.PlayOpenWindowAudio();

                Destroy(gameObject);
            });
            closeAllBtn.onClick.AddListener(() =>
            {
                MainMgr.instance.PlayOpenWindowAudio();

                Destroy(gameObject);
            });
        }

        public void Show(int index)
        {
            herImg.sprite = heroImgList[index];
        }
    }
}
