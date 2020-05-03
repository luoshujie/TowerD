using System.Collections.Generic;

namespace Script.Config
{
    public static class HeroConfig
    {
        private static readonly Dictionary<int,int>HeroPriceDic=new Dictionary<int, int>()
        {
            {0,600},
            {1,400},
            {2,300},
            {3,500},
        };
        private static Dictionary<int ,int>monsterPriceDic=new Dictionary<int, int>()
        {
            
        };

        private static int GetMonsterPrice(int id)
        {
            if (monsterPriceDic.ContainsKey(id))
            {
                return monsterPriceDic[id];
            }

            return 1000;
        }

        public static int GetHeroPrice(int id)
        {
            if (HeroPriceDic.ContainsKey(id))
            {
                return HeroPriceDic[id];
            }

            return 1000;
        }
    }
}
