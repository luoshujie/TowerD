using System;
using System.Collections.Generic;
using Script.Manager;
using Script.Window;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Scene
{
    public class Home : MonoBehaviour
    {
        public Button fightBtn;
        public Button heroBtn;
        public List<Button> btnList;
        public Button settingBtn;
        private void Awake()
        {
            if (MainMgr.instance==null)
            {
                SceneManager.LoadScene("Init");
                return;
            }
            WindowMgr.instance.UpdateCamera();
            AddEvent();
        }

        private void Start()
        {
            MainMgr.instance.PlayBackGroupAudio(0);
        }

        private void AddEvent()
        {
            settingBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<SettingWindow>(); });
            fightBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<LevelSelectWindow>();});
            heroBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<HeroWindow>();});
            for (int i = 0; i < btnList.Count; i++)
            {
                btnList[i].onClick.AddListener(BtnClick);
            }
        }

        private void BtnClick()
        {
            WindowMgr.instance.ShowWindow<TipsWindow>();
        }
    }
}
