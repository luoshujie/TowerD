using DG.Tweening;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Skill
{
    public class AddDefenseSkill : ISkillInterface
    {
        private HeroData _data;
        private int valueDefense;
        private float time;

        public AddDefenseSkill(HeroData data, int value, float times)
        {
            _data = data;
            valueDefense = value;
            time = times;
        }
        public void UseSkill()
        {
            _data.Defense += valueDefense;
            DOTween.Sequence().InsertCallback(time, Reduction);
        }

        private void Reduction()
        {
            _data.Defense -= valueDefense;
        }
    }
}
