using System.Collections.Generic;
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
            List<MonsterControl> allMonsterList = FightMgr.instance.GetAllMonster();
            for (int i = 0; i < allMonsterList.Count; i++)
            {
                allMonsterList[i].Hurt(attackValue);
            }
        }
    }
}
