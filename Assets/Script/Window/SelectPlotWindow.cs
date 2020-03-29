using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class SelectPlotWindow : MonoBehaviour
    {
        public Button closeBtn;
        public Button mainBtn;
        public Button plot1Btn;
        public Button plot2Btn;

        private void Awake()
        {
            closeBtn.onClick.AddListener(()=>{});
            mainBtn.onClick.AddListener(()=>{});
            plot1Btn.onClick.AddListener(()=>{});
            plot2Btn.onClick.AddListener(()=>{});
        }
    }
}
