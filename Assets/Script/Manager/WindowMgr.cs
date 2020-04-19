using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Manager
{
    public class WindowMgr : MonoBehaviour
    {
        public static WindowMgr instance;
        public Dictionary<Type,string>windowPath=new Dictionary<Type, string>()
        {
            {typeof(MainMgr),"Window/MainMgr"}
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
