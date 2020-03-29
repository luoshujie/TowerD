using System;
using System.Collections.Generic;
using Script.Item;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class HeroListWindow : MonoBehaviour
    {
        public Button closeBtn;
        public Button mainBtn;

        public Sprite downSprite;
        public Sprite upSprite;

        public Button combatBtn;
        private Image combatImg;
        public Button remoteBtn;
        private Image remoteImg;
        public Button auxiliaryBtn;
        private Image auxiliaryImg;

        public Transform content;
        public GameObject itemPrefab;
        private List<HeroItem> heroItemList;

        private void Awake()
        {
            heroItemList = new List<HeroItem>();
            closeBtn.onClick.AddListener(() => { });
            mainBtn.onClick.AddListener(() => { });

            combatImg = combatBtn.GetComponent<Image>();
            remoteImg = remoteBtn.GetComponent<Image>();
            auxiliaryImg = auxiliaryBtn.GetComponent<Image>();

            combatBtn.onClick.AddListener(() =>
            {
                ShowBtnSprite();
                combatImg.sprite = downSprite;
                ShowHero(OccupationEnum.Warrior);
            });
            remoteBtn.onClick.AddListener(() =>
            {
                ShowBtnSprite();
                remoteImg.sprite = downSprite;
                ShowHero(OccupationEnum.Gunmen);
            });
            auxiliaryBtn.onClick.AddListener(() =>
            {
                ShowBtnSprite();
                auxiliaryImg.sprite = downSprite;
                ShowHero(OccupationEnum.Auxiliary);
            });
        }


        private void ShowBtnSprite()
        {
            combatImg.sprite = upSprite;
            remoteImg.sprite = upSprite;
            auxiliaryImg.sprite = upSprite;
        }

        private void ShowHero(OccupationEnum occupationEnum)
        {
            List<HeroData> heroDataList = new List<HeroData>();
            for (int i = 0; i < heroDataList.Count; i++)
            {
                if (heroItemList.Count > i)
                {
                    heroItemList[i].Init(heroDataList[i]);
                }
                else
                {
                    InstantiateItem().Init(heroDataList[i]);
                }
            }

            for (int i = heroDataList.Count; i < heroItemList.Count; i++)
            {
                heroItemList[i].gameObject.SetActive(false);
            }
        }

        private HeroItem InstantiateItem()
        {
            GameObject item = Instantiate(itemPrefab, content);
            HeroItem heroItem = item.GetComponent<HeroItem>();
            heroItemList.Add(heroItem);
            return heroItem;
        }
    }
}