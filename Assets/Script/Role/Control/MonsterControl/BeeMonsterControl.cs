using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class BeeMonsterControl : MonsterControl
    {
        private void Start()
        {
            data=new MonsterData(1,"空中毒峰",15,100,8,0,1,StanceEnum.Highland,1);
        }
    }
}