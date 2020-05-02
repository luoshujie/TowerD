using System;
using Script.Manager;
using UnityEngine;

namespace Script.Window
{
    public class LoadingWindow : MonoBehaviour
    {
        private Action callback;
        private float time = 3;

        private void Start()
        {
            Invoke(nameof(Close),time);
        }

        public void Loading(Action complete)
        {
            callback = complete;
        }
        private void Close()
        {
            callback?.Invoke();
            Invoke(nameof(Des),0.1f);
        }

        private void Des()
        {
            Destroy(gameObject);

        }
    }
}