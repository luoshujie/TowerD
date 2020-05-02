using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class PauseWindow : MonoBehaviour
    {
        public Button continueBtn;
        public Button audioBtn;
        public Button quitBtn;
        public Image audioImg;
        public Sprite audioOnSprite;
        public Sprite audioOffSprite;

        private void Awake()
        {
            continueBtn.onClick.AddListener(()=>{});
            audioBtn.onClick.AddListener(()=>{});
            quitBtn.onClick.AddListener(()=>{});
        }
    }
}
