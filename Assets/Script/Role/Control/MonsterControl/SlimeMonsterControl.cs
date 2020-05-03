using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class SlimeMonsterControl : MonsterControl
    {
        void Start()
        {
            data=new MonsterData(2,"史莱姆",20,1,20,0,1,StanceEnum.Lowland,1);
        }

    }
}
