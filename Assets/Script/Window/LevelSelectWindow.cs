using System;
using System.Collections.Generic;
using Script.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Window
{
    public class LevelSelectWindow : MonoBehaviour
    {
        public Button closeBtn;
        public Button fightBtn;
        public List<Button> btnList;

        private void Awake()
        {
            closeBtn.onClick.AddListener(() =>
            {
                MainMgr.instance.PlayOpenWindowAudio();
                Destroy(gameObject);
            });
            fightBtn.onClick.AddListener(() =>
            {
                WindowMgr.instance.ShowWindow<LoadingWindow>().Loading(() =>
                {
                    SceneManager.LoadScene("Game");
                    Destroy(gameObject);
                });
                
            });
            for (int i = 0; i < btnList.Count; i++)
            {
                btnList[i].onClick.AddListener(() => { WindowMgr.instance.ShowWindow<TipsWindow>();});
            }
        }
    }
}
