using System;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Script.Role.Control.MonsterControl
{
    public class BossMonsterControl : MonsterControl
    {
        private float skillIntervalTime;
        private void Start()
        {
            data = new MonsterData(4, "白爪", 800, 100, 30, 100, 1, StanceEnum.Lowland, 1);
            InvokeRepeating(nameof(Skill),skillIntervalTime,skillIntervalTime);
        }
        
        

        public void Skill()
        {
            Debug.LogWarning("释放技能");
        }
    }
}