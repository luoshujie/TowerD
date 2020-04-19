using System;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PlatformItem : MonoBehaviour
    {
        public GameObject hero;
        public StanceEnum stance;

        public GameObject highlightSprite;
        public bool CheckoutHero()
        {
            return hero == null;
        }

        public void InstantiateHero(GameObject heroModel)
        {
            hero = Instantiate(heroModel, transform);
            
            hero.transform.localPosition = Vector3.zero;
            hero.SetActive(true);
        }

        public void CancelHero()
        {
            Destroy(hero);
            hero = null;
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
