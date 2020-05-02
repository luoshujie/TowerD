using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class HeroWindow : MonoBehaviour
    {
        public Button closeBtn;
        public List<Button> heroBtnList;

        private void Awake()
        {
            closeBtn.onClick.AddListener(()=>{Destroy(gameObject);});
            for (int i = 0; i < heroBtnList.Count; i++)
            {
                var i1 = i;
                heroBtnList[i].onClick.AddListener(()=>
                {
                    ShowHeroDesc(i1);
                });
            }
        }

        private void ShowHeroDesc(int index)
        {
            
        }
    }
}
