using Script.Role.Data;
using Script.Role.Skill.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class GunmenControl : HeroControl
    {
        public Transform target;

        public override void InitSkill()
        {
            skill = new FatalShotSkill(target);
        }

        public override void InitData()
        {
            data = new HeroData(1, "艾米丽", AttackTargetEnum.Monster, 40, 20, 100,
                20, 30, 100, 2, OccupationEnum.Gunmen, StanceEnum.Highland);
        }

        public override void InitFsmState()
        {
        }

        public override void Damage()
        {
        }
    }
}