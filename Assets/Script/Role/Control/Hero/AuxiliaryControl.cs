using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class AuxiliaryControl : HeroControl
    {
        private Vector3 pos = new Vector3(-0.13f, 1.45f, 0);

        public override void InitSkill()
        {
        }

        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitData()
        {
            data = new HeroData(7, "安", AttackTargetEnum.Player, 30, 20,
                2, 10, 90, 2, OccupationEnum.Auxiliary, StanceEnum.Highland);
            attackStance = StanceEnum.None;
        }
    }
}
