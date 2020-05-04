using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Role.Data;
using UnityEngine;

namespace Script.Config
{
    public static class LevelConfig
    {
        private static List<LevelData> _levelDataList = new List<LevelData>()
        {
            new LevelData(1, new List<List<LevelMonsterData>>()
            {
                new List<LevelMonsterData>()
                {
                    new LevelMonsterData(1,1),
                    new LevelMonsterData(1,4),
                    new LevelMonsterData(1,0),
                    new LevelMonsterData(1,0),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(0,0),
                    new LevelMonsterData(1,1),
                    new LevelMonsterData(1,1),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(2,0),
                    new LevelMonsterData(0,1),
                    new LevelMonsterData(0,1),
                    new LevelMonsterData(0,1),
                    new LevelMonsterData(0,1),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(0,4),
                    new LevelMonsterData(0,4),
                    new LevelMonsterData(0,4),
                    new LevelMonsterData(0,4),
                    new LevelMonsterData(0,4),
                    new LevelMonsterData(0,4),
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(0,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(1,3),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    new LevelMonsterData(2,4),
                    
                },new List<LevelMonsterData>()
                {
                    new LevelMonsterData(1,2),
                },
            }),
        };

        public static LevelData GetLevelData(int level)
        {
            for (int i = 0; i < _levelDataList.Count; i++)
            {
                if (_levelDataList[i].level==level)
                {
                    return _levelDataList[i].Clone();
                }
            }

            return _levelDataList[0].Clone();
        }
    }

    public class LevelMonsterData
    {
        public int pathId;
        public int monsterId;

        public LevelMonsterData(int pathId, int monsterId)
        {
            this.monsterId = monsterId;
            this.pathId = pathId;
        }
    }


    public class LevelData
    {
        public int level;
        public List<List<LevelMonsterData>> monsterIdList;

        public LevelData(int level, List<List<LevelMonsterData>> monsterIdList)
        {
            this.level = level;

            this.monsterIdList = monsterIdList;
        }

        public LevelData Clone()
        {
            return MemberwiseClone() as LevelData;
        }
    }
}