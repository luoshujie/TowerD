using System;
using UnityEngine;

namespace Script.Manager
{
    public class MainMgr : MonoBehaviour
    {
        public static MainMgr instance;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
