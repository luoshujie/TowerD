using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public int heroModelId;
        public Text priceText;
        public int price;
        public GameObject selectTips;

        private void Start()
        {
            priceText.text = price.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Game.instance.Move(true,heroModelId);
            selectTips.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Game.instance.Move(false,heroModelId);
            selectTips.SetActive(false);

        }
    }
}
