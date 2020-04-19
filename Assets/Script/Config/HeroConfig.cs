using System.Collections.Generic;

namespace Script.Config
{
    public static class HeroConfig
    {
        private static readonly Dictionary<int,int>HeroPriceDic=new Dictionary<int, int>()
        {
            {0,100},
            {1,1000},
            {2,1000},
            {3,1000},
            {4,1000},
        };

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
