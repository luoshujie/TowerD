using Script.Role.Data;
using Script.Role.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class MeatshieldControl : HeroControl
    {
        private Vector3 pos=new Vector3(0.06f,1.222f,0);
        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public Transform skillPos;
        public override void InitSkill()
        {
            skill=new AddDefenseSkill(data,10,5,skillPos);
        }

        public override void InitData()
        {
            data  = new HeroData(6, "诺亚", AttackTargetEnum.Monster, 80, 20,
                10, 70, 2, 2, OccupationEnum.MeatShield, StanceEnum.Lowland);
            attackStance = StanceEnum.Lowland;
        }
    }
}
