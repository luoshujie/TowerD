﻿using Script.Role.Data;
using Script.Role.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class GunmenControl : HeroControl
    {
        private Vector3 pos = new Vector3(-0.13f, 1.36f, 0);

        public override void InitSkill()
        {
            skill=new AddAttackSkill(data,10,5);
        }

        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitData()
        {
            data = new HeroData(5, "艾米丽", AttackTargetEnum.Monster, 40, 20,
                20, 30, 3, 2, OccupationEnum.Gunmen, StanceEnum.Highland);
            attackStance = StanceEnum.None;
        }
    }
}