using System;
using System.Collections;
using System.Collections.Generic;
using Script.Config;
using Script.Role.Control.Hero;
using Script.Role.Control.MonsterControl;
using Script.Role.Data;
using UnityEngine;

namespace Script.Manager
{
    [Serializable]
    public class PathData
    {
        public int id;
        public List<Transform> pathList;
    }
    
    public class FightMgr : MonoBehaviour
    {
        public static FightMgr instance;
        public List<PlatformItem> platformItemList;
        public List<GameObject> heroModelList;

        public List<GameObject> heroSpriteList;
        
        public List<GameObject> monsterList;
        public Transform monsterContent;

        public List<PathData> monsterPathList;

        private LevelData _levelData;
        private int monsterSpawnIndex;
        
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _levelData = LevelConfig.GetLevelData(1);
            monsterSpawnIndex = 0;
            InstantiateMonster();
        }
        

        public void InstantiateMonster()
        {
            StartCoroutine(SpawnMonster());
        }

        private WaitForSeconds waitForSeconds=new WaitForSeconds(2);
        IEnumerator SpawnMonster()
        {
            List<LevelMonsterData> levelMonsterData = _levelData.monsterIdList[monsterSpawnIndex];
            for (int i = 0; i < levelMonsterData.Count; i++)
            {
                GameObject monster=Instantiate(monsterList[levelMonsterData[i].monsterId],monsterContent);
                monster.GetComponent<MonsterControl>().InitPath( monsterPathList[levelMonsterData[i].pathId].pathList);
                monster.SetActive(true);
                yield return waitForSeconds;
            }

            monsterSpawnIndex++;
        }

        public GameObject GetHeroModel(int id)
        {
            if (heroSpriteList.Count > id)
            {
                return heroSpriteList[id];
            }
            else
            {
                return heroSpriteList[0];
            }
        }

        public GameObject GetHeroPrefab(int heroId)
        {
            if (heroModelList.Count > heroId)
            {
                return heroModelList[heroId];
            }
            else
            {
                return heroModelList[0];
            }
        }
        
        public void ShowHighlight(StanceEnum stanceEnum)
        {
            for (int i = 0; i < platformItemList.Count; i++)
            {
                if (platformItemList[i].hero == null && platformItemList[i].stance == stanceEnum)
                {
                    platformItemList[i].ShowHighlight();
                }
            }
        }

        public void CloseHighlight(int heroId, StanceEnum stanceEnum)
        {
            for (int i = 0; i < platformItemList.Count; i++)
            {
                platformItemList[i].CloseHighlight();
            }

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 10;

            for (int i = 0; i < platformItemList.Count; i++)
            {
                if (platformItemList[i].hero == null && platformItemList[i].stance == stanceEnum)
                {
                    if (Vector3.Distance(platformItemList[i].transform.position, pos) < 1)
                    {
                        platformItemList[i].InstantiateHero(GetHeroPrefab(heroId));
                    }
                }
            }
        }
    }
}