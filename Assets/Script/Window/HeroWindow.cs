using System;
using System.Collections.Generic;
using Script.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class HeroWindow : MonoBehaviour
    {
        public Button closeBtn;
        public Button tipsHeroBtn;
        public List<Button> heroBtnList;

        private void Awake()
        {
            closeBtn.onClick.AddListener(() =>
            {
                MainMgr.instance.PlayBackGroupAudio(0);

                Destroy(gameObject);
            });
            for (int i = 0; i < heroBtnList.Count; i++)
            {
                var i1 = i;
                heroBtnList[i].onClick.AddListener(()=>
                {
                    ShowHeroDesc(i1);
                });
            }
            tipsHeroBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<TipsWindow>(); });
            MainMgr.instance.PlayBackGroupAudio(1);
            MainMgr.instance.PlayOpenWindowAudio();

        }

        private void ShowHeroDesc(int index)
        {
            WindowMgr.instance.ShowWindow<HeroDescWindow>().Show(index);
        }
    }
}
