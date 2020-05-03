using System;
using Script.Role.Control.Hero;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PlatformItem : MonoBehaviour
    {
        public GameObject hero;
        public StanceEnum stance;

        public HeroControl heroControl;

        public GameObject highlightSprite;
        public bool CheckoutHero()
        {
            return hero != null;
        }

        public void InstantiateHero(GameObject heroModel)
        {
            hero = Instantiate(heroModel, transform);
            
            heroControl=hero.GetComponent<HeroControl>();
            heroControl.SetPos();
            hero.SetActive(true);
        }

        public void CancelHero()
        {
            Destroy(hero);
            hero = null;
            heroControl = null;
        }

        public void Retreat(bool state)
        {
            if (heroControl==null)
            {
                return;
            }
            heroControl.natureUi.ShowCancelBtn(state);
        }

        public void ShowHighlight()
        {
            highlightSprite.SetActive(true);
        }

        public void CloseHighlight()
        {
            highlightSprite.SetActive(false);
        }
    }
}
