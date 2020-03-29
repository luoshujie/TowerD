using System.Collections.Generic;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Item
{
    public class HeroItem : MonoBehaviour
    {
        public Image img;
        public Image occupationImg;
        public List<GameObject> starList;
        public Text levelText;
        public Text nameText;
        public Image skillImg;

        public void Init(HeroData data)
        {
            if (data==null)
            {
                Debug.LogWarning("data is null");
                return;
            }
            gameObject.SetActive(true);
        }
    }
}
