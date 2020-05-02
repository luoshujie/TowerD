using System;
using System.Collections;
using System.Collections.Generic;
using Script.Config;
using Script.Role.Control.Hero;
using Script.Role.Control.MonsterControl;
using Script.Role.Data;
using Script.Window;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        private IList<GameObject>sceneMonsterList=new List<GameObject>();

        private LevelData _levelData;
        private int monsterSpawnIndex;
        
        private void Awake()
        {
            if (MainMgr.instance==null)
            {
                SceneManager.LoadScene("Init");
                return;
            }
            instance = this;
        }

        private void Start()
        {
            WindowMgr.instance.ShowWindow<DialogWindow>(false).Init(0,5,()=>{});
            MainMgr.instance.PlayBackGroupAudio(2);
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
                sceneMonsterList.Add(monster);
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

        public void MonsterDie(GameObject monster)
        {
            sceneMonsterList.Remove(monster);
            if (sceneMonsterList.Count<=0)
            {
                //下一波
                if (monsterSpawnIndex<_levelData.monsterIdList.Count)
                {
                    Invoke(nameof(InstantiateMonster),5);
                }
                else
                {
                    //打完了
                }
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