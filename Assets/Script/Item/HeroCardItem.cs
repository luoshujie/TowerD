using System;
using Script.Config;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public int heroModelId;
        public Text priceText;
        private int price;
        public GameObject selectTips;
        public StanceEnum stanceEnum;

        private void Start()
        {
            price = HeroConfig.GetHeroPrice(heroModelId);
            priceText.text = price.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Game.instance.Move(true,heroModelId,stanceEnum);
            selectTips.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Game.instance.Move(false,heroModelId,stanceEnum);
            selectTips.SetActive(false);

        }
    }
}
