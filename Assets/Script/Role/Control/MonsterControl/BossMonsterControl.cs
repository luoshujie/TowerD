using System;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Script.Role.Control.MonsterControl
{
    public class BossMonsterControl : MonsterControl
    {
        private void Start()
        {
            isBoss = true;
            data = new MonsterData(4, "白爪", 1600, 1.5f, 80, 120, 1, StanceEnum.Lowland, 1);
        }
    }
}