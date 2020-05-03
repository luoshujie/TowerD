using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class MeatshieldControl : HeroControl
    {
        private Vector3 pos=new Vector3(-0.533f,1.226f,0);
        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitSkill()
        {
            
        }

        public override void InitData()
        {
            data  = new HeroData(6, "诺亚", AttackTargetEnum.Monster, 80, 20,
                10, 70, 100, 2, OccupationEnum.MeatShield, StanceEnum.Lowland);
            attackStance = StanceEnum.Lowland;
        }
    }
}
