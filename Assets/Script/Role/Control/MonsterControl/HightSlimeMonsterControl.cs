using Script.Role.Data;

namespace Script.Role.Control.MonsterControl
{
    public class HightSlimeMonsterControl :  MonsterControl
    {
        void Start()
        {
            data=new MonsterData(20,"高级史莱姆",30,50,30,0,1,StanceEnum.Lowland,1);
        }

    }
}
