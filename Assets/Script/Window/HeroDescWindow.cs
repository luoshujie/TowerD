using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Window
{
    public class HeroDescWindow : MonoBehaviour
    {
        public Text levelText;
        public Text nameText;
        public Image person;
        public Text minNameText;
        public Text occupationText;
        public List<GameObject> starList;
        public Slider lifeSlider;
        public Slider defenseSlider;
        public Slider attackSlider;
    }
}
