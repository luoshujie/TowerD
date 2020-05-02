using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Window
{
    public class DialogWindow : MonoBehaviour,IPointerClickHandler
    {
        public Image dialogImg;
        public List<Sprite> dialogSpriteList;

        private int startIndex;
        private int endIndex;
        private Action callback;

        public void Init(int start, int end,Action callback)
        {
            this.callback = callback;
            startIndex = start;
            endIndex = end;
            Show();
        }

        private void Show()
        {
            dialogImg.sprite = dialogSpriteList[startIndex];
            startIndex++;
        }

        private void Close()
        {
            callback?.Invoke();
            Destroy(gameObject);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (startIndex<endIndex)
            {
                Show();
            }
            else
            {
                Close();
            }
        }
    }
}
