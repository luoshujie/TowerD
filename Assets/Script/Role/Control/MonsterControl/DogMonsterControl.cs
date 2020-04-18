using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class DogMonsterControl : MonsterControl
    {
        void Start()
        {
            data = new MonsterData(3, "机器狗", 10, 10, 20, 10, 1, StanceEnum.Lowland, 1);
        }
    }
}