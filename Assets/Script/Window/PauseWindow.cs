﻿using System;
using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        private float scale;
        private void Awake()
        {
            continueBtn.onClick.AddListener(() =>
            {
                Time.timeScale = scale;
                MainMgr.instance.PlayOpenWindowAudio();
                Destroy(gameObject);
            });
            audioBtn.onClick.AddListener(SetAudio);
            quitBtn.onClick.AddListener(() =>
            {
                Time.timeScale = scale;
                SceneManager.LoadScene("Home");
                Destroy(gameObject);
            });
            scale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void Start()
        {
            SetAudioImg();
        }

        private void SetAudioImg()
        {
            audioImg.sprite = MainMgr.instance.GetBackGroupState() ? audioOffSprite : audioOnSprite;
        }
        private void SetAudio()
        {
            MainMgr.instance.SetAudioState();
            SetAudioImg();
        }
    }
}
