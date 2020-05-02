using System;
using System.Collections.Generic;
using Script.Manager;
using UnityEngine;
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
            closeBtn.onClick.AddListener(()=>{Destroy(gameObject);});
            fightBtn.onClick.AddListener(()=>{});
            for (int i = 0; i < btnList.Count; i++)
            {
                btnList[i].onClick.AddListener(() => { WindowMgr.instance.ShowWindow<TipsWindow>();});
            }
        }
    }
}
