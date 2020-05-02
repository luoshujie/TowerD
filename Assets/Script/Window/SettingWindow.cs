using System;
using Script.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Window
{
    public class SettingWindow : MonoBehaviour,IPointerClickHandler
    {
        public Button audioBtn;
        public Button quitBtn;
        public Image audioImg;
        public Sprite audioOnSprite;
        public Sprite audioOffSprite;

        private void Awake()
        {
            audioBtn.onClick.AddListener(() =>
            {
                MainMgr.instance.SetAudioState();
                SetAudioImg();
            });
            quitBtn.onClick.AddListener(Application.Quit);
            SetAudioImg();
        }

        private void SetAudioImg()
        {
            audioImg.sprite = MainMgr.instance.GetBackGroupState() ? audioOffSprite : audioOnSprite;
        }

        private bool state;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (state)
            {
                return;
            }

            state = true;
            Destroy(gameObject);
        }
    }
}
