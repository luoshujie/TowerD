using Script.Manager;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class HightBeeMonsterControl : MonsterControl
    {
        private void Start()
        {
            data=new MonsterData(10,"高级空中毒峰",30,2.5f,20,0,1,StanceEnum.Highland,1);
        }

        private Transform dir;

        public Transform attackPosRight;
        public Transform attackPosLeft;
        public override void Damage()
        {
            bool state = false;
            if (renderer.flipX)
            {
                dir=attackPosLeft;
            }
            else
            {
                state = true;
                dir=attackPosRight;
            }
            EffectMgr.instance.BeeMonsterAttack(dir,state);
            base.Damage();
        }
    }
}
