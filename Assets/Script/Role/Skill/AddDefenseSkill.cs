using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Skill
{
    public class AddDefenseSkill : ISkillInterface
    {
        private HeroData _data;
        private int valueDefense;
        private float time;
        private Transform skillPos;

        public AddDefenseSkill(HeroData data, int value, float times,Transform skillPos)
        {
            this.skillPos = skillPos;
            _data = data;
            valueDefense = value;
            time = times;
        }
        public void UseSkill()
        {
            EffectMgr.instance.PlayAddDefenseSkill(skillPos);
            _data.Defense += valueDefense;
            DOTween.Sequence().InsertCallback(time, Reduction);
        }

        private void Reduction()
        {
            _data.Defense -= valueDefense;
        }
    }
}
