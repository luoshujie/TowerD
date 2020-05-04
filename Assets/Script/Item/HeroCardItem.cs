using System;
using Script.Config;
using Script.Manager;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public int heroModelId;
        public Text priceText;
        private int price;
        public GameObject selectTips;
        public StanceEnum stanceEnum;
        public GameObject mask;

        private void Start()
        {
            price = HeroConfig.GetHeroPrice(heroModelId);
            priceText.text = price.ToString();
            FightMgr.instance.updateCoinChange += UpdateMask;
            UpdateMask();
        }

        private void OnDestroy()
        {
            FightMgr.instance.updateCoinChange -= UpdateMask;
        }

        private bool state;
        private void UpdateMask()
        {
            state= FightMgr.instance.coin >= price;
            mask.SetActive(!state);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!state)
            {
                return;
            }
            Game.instance.Move(true, heroModelId, stanceEnum);
            selectTips.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!state)
            {
                return;
            }
            Game.instance.Move(false, heroModelId, stanceEnum);
            selectTips.SetActive(false);
        }
    }
}