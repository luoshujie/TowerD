using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Control.MonsterControl;

namespace Script.Role.Skill
{
    public class BigMoveSkill : ISkillInterface
    {
        private int attackValue;

        public BigMoveSkill(int attackValue)
        {
            this.attackValue = attackValue;
        }
        public void UseSkill()
        {
            EffectMgr.instance.PlaBigMoveSkill();
            DOTween.Sequence().InsertCallback(0.2f, () =>
            {
                List<MonsterControl> allMonsterList = FightMgr.instance.GetAllMonster();
                for (int i = 0; i < allMonsterList.Count; i++)
                {
                    allMonsterList[i].Hurt(attackValue);
                }
            });
        }
    }
}
