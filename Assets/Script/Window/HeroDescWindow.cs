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
            closeBtn.onClick.AddListener(()=>{Destroy(gameObject);});
            closeAllBtn.onClick.AddListener(()=>{Destroy(gameObject);});
            MainMgr.instance.PlayOpenWindowAudio();
        }

        public void Show(int index)
        {
            herImg.sprite = heroImgList[index];
        }
    }
}
