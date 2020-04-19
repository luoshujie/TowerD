using System;
using System.Collections.Generic;
using Script.Manager;
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

        private void AddEvent()
        {
            fightBtn.onClick.AddListener(()=>{});
            heroBtn.onClick.AddListener(()=>{});
            for (int i = 0; i < btnList.Count; i++)
            {
                btnList[i].onClick.AddListener(BtnClick);
            }
        }

        private void BtnClick()
        {
            Debug.LogWarning("开发中");
        }
    }
}
