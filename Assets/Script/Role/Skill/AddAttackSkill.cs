using DG.Tweening;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Skill
{
    public class AddAttackSkill : ISkillInterface
    {
        private HeroData _data;
        private int valueAttack;
        private float time;
        public AddAttackSkill(HeroData data, int value, float times)
        {
            _data = data;
            valueAttack = value;
            time = times;
        }
        public void UseSkill()
        {
            _data.Attack += valueAttack;
            DOTween.Sequence().InsertCallback(time, Reduction);
        }

        private void Reduction()
        {
            _data.Attack -= valueAttack;
        }
    }
}
