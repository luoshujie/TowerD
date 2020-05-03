using Script.Role.Data;

namespace Script.Role.Control.MonsterControl
{
    public class HightBeeMonsterControl : MonsterControl
    {
        private void Start()
        {
            data=new MonsterData(10,"高级空中毒峰",30,2.5f,20,0,1,StanceEnum.Highland,1);
        }
    }
}
