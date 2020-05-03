using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class WarriorControl : HeroControl
    {
        private Vector3 pos = new Vector3(-0.229f, 1.396f, 0);

        public override void InitSkill()
        {
        }

        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitData()
        {
            data = new HeroData(8, "刀可", AttackTargetEnum.Monster, 50, 20,
                30, 30, 2, 2, OccupationEnum.Warrior, StanceEnum.Lowland);
            attackStance = StanceEnum.Lowland;
        }
    }
}
