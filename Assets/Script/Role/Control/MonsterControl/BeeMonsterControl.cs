using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class BeeMonsterControl : MonsterControl
    {
        private void Start()
        {
            data = new MonsterData(1, "空中毒峰", 15, 2.5f, 16, 0, 1, StanceEnum.Highland, 1);
        }

        private Transform dir;

        public Transform attackPosRight;
        public Transform attackPosLeft;
        public override void Damage()
        {
            if (renderer.flipX)
            {
                dir=attackPosLeft;
            }
            else
            {
                dir=attackPosRight;
            }
            EffectMgr.instance.BeeMonsterAttack(dir);
            base.Damage();
        }
    }
}