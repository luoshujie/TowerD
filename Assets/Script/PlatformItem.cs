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

        private HeroControl _heroControl;

        public GameObject highlightSprite;
        public bool CheckoutHero()
        {
            return hero == null;
        }

        public void InstantiateHero(GameObject heroModel)
        {
            hero = Instantiate(heroModel, transform);
            
            _heroControl=hero.GetComponent<HeroControl>();
            _heroControl.SetPos();
            hero.SetActive(true);
        }

        public void CancelHero()
        {
            Destroy(hero);
            hero = null;
            _heroControl = null;
        }

        public void Retreat(bool state)
        {
            if (_heroControl==null)
            {
                return;
            }
            _heroControl.natureUi.ShowCancelBtn(state);
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
