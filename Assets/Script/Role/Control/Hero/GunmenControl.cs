using Script.Role.Data;
using Script.Role.Skill.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class GunmenControl : HeroControl
    {
        private Vector3 pos = new Vector3(-0.13f, 1.36f, 0);

        public override void InitSkill()
        {
        }

        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitData()
        {
            data = new HeroData(5, "艾米丽", AttackTargetEnum.Monster, 40, 20,
                20, 30, 100, 2, OccupationEnum.Gunmen, StanceEnum.Highland);
            attackStance = StanceEnum.None;
        }
    }
}