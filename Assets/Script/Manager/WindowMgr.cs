using System;
using System.Collections.Generic;
using Script.Window;
using UnityEngine;

namespace Script.Manager
{
    public class WindowMgr : MonoBehaviour
    {
        public static WindowMgr instance;
        public Dictionary<Type,string>windowPath=new Dictionary<Type, string>()
        {
            {typeof(MainMgr),"Window/MainMgr"},
            {typeof(TipsWindow),"Window/TipsWindow"},
            {typeof(PauseWindow),"Window/PauseWindow"},
            {typeof(LevelSelectWindow),"Window/LevelSelectWindow"},
            {typeof(HeroWindow),"Window/HeroWindow"},
            {typeof(HeroDescWindow),"Window/HeroDescWindow"},
            {typeof(DialogWindow),"Window/DialogWindow"},
            {typeof(LoadingWindow),"Window/LoadingWindow"},
            {typeof(SettingWindow),"Window/SettingWindow"},
        };

        private void Awake()
        {
            instance = this;
        }
        

        public T ShowWindow<T>() where T : class
        {
            GameObject window = Resources.Load<GameObject>(windowPath[typeof(T)]);
            return Instantiate(window, transform).GetComponent<T>();
        }

        public void UpdateCamera()
        {
            GetComponent<Canvas>().worldCamera=Camera.main;
        }
    }
}
