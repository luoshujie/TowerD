using Script.Role.Data;
using Script.Role.Skill.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class GunmenControl : HeroControl
    {
        public override void InitSkill()
        {
            
        }
        public override void InitData()
        {
            data  = new HeroData(1, "艾米丽", AttackTargetEnum.Monster, 40, 20,
                1, 30, 100, 2, OccupationEnum.Gunmen, StanceEnum.Lowland);
            attackStance = StanceEnum.None;
        }
    }
}