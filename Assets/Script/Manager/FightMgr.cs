using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Config;
using Script.Role.Control.Hero;
using Script.Role.Control.MonsterControl;
using Script.Role.Data;
using Script.Role.Skill;
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

        private List<MonsterControl> sceneMonsterList = new List<MonsterControl>();

        private LevelData _levelData;
        private int monsterSpawnIndex;

        public int crystalCnt = 10;
        public int coin = 1000;

        private void Awake()
        {
            if (MainMgr.instance == null)
            {
                SceneManager.LoadScene("Init");
                return;
            }

            instance = this;
        }

        public void Retreat(bool state)
        {
            for (int i = 0; i < platformItemList.Count; i++)
            {
                platformItemList[i].Retreat(state);
            }
        }

        private void Start()
        {
            WindowMgr.instance.ShowWindow<DialogWindow>(false).Init(0, 5, () => { });
            MainMgr.instance.PlayBackGroupAudio(2);
            _levelData = LevelConfig.GetLevelData(1);
            monsterSpawnIndex = 0;
            Game.instance.DisplayNum(monsterSpawnIndex + 1, _levelData.monsterIdList.Count);
            Game.instance.ShowCrystalCnt();
            Game.instance.DisplayCoin();
        }

        public List<HeroControl> GetOnDistanceHero(Vector3 pos, float distance)
        {
            List<HeroControl> heroControls = new List<HeroControl>();
            for (int i = 0; i < platformItemList.Count; i++)
            {
                if (!platformItemList[i].CheckoutHero())
                {
                    continue;
                }

                if (Vector3.Distance(pos, platformItemList[i].transform.position) < distance)
                {
                    if (platformItemList[i].heroControl.data.Alive)
                    {
                        heroControls.Add(platformItemList[i].heroControl);
                    }
                }
            }

            return heroControls;
        }

        public List<MonsterControl> GetAllMonster()
        {
            return sceneMonsterList;
        }

        public HeroControl GetHeroTarget(Vector3 pos, float distance, StanceEnum stanceEnum)
        {
            for (int i = 0; i < platformItemList.Count; i++)
            {
                if (platformItemList[i].stance != stanceEnum)
                {
                    continue;
                }

                if (platformItemList[i].CheckoutHero())
                {
                    if (Vector3.Distance(pos, platformItemList[i].transform.position) < distance)
                    {
                        if (platformItemList[i].heroControl.data.Alive)
                        {
                            return platformItemList[i].heroControl;
                        }
                    }
                }
            }

            return null;
        }

        public MonsterControl GetMonsterTarget(Vector3 pos, float distance, StanceEnum stanceEnum)
        {
            if (sceneMonsterList.Count <= 0)
            {
                return null;
            }

            for (int i = 0; i < sceneMonsterList.Count; i++)
            {
                if (Vector3.Distance(pos, sceneMonsterList[i].transform.position) < distance)
                {
                    if (stanceEnum == StanceEnum.None || stanceEnum == sceneMonsterList[i].data.Stance)
                    {
                        if (sceneMonsterList[i].data.Alive)
                        {
                            return sceneMonsterList[i];
                        }
                    }
                }
            }

            return null;
        }

        private bool gameEnd;

        public void RedueCrystal(bool isBoss = false)
        {
            Game.instance.ShowRedPanel();
            crystalCnt--;
            if (isBoss)
            {
                crystalCnt = 0;
                gameEnd = true;
            }

            Game.instance.ShowCrystalCnt();
            if (crystalCnt <= 0)
            {
                gameEnd = true;
                //游戏结束
                WindowMgr.instance.ShowWindow<GameEndWindow>().Init(false);
            }
        }

       

        public void InstantiateMonster()
        {
            StartCoroutine(SpawnMonster());
        }

        private IEnumerator YanShi(float time)
        {
            yield return  new WaitForSeconds(time);
            InstantiateMonster();
        }

        private WaitForSeconds waitForSeconds = new WaitForSeconds(2);

        IEnumerator SpawnMonster()
        {
            Debug.LogWarning(monsterSpawnIndex);
            Game.instance.DisplayNum(monsterSpawnIndex + 1, _levelData.monsterIdList.Count);
            List<LevelMonsterData> levelMonsterData = _levelData.monsterIdList[monsterSpawnIndex];
            for (int i = 0; i < levelMonsterData.Count; i++)
            {
                GameObject monster = Instantiate(monsterList[levelMonsterData[i].monsterId], monsterContent);
                MonsterControl monsterControl = monster.GetComponent<MonsterControl>();
                monsterControl.InitPath(monsterPathList[levelMonsterData[i].pathId].pathList);
                monster.SetActive(true);
                sceneMonsterList.Add(monsterControl);
                yield return waitForSeconds;
            }

            spawnState = false;
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

        public void MonsterDie(MonsterControl monster, bool alive = false)
        {
            if (!alive)
            {
                CoinChange(100);
            }

            sceneMonsterList.Remove(monster);
            if (sceneMonsterList.Count <= 0)
            {
                //下一波
                if (monsterSpawnIndex < _levelData.monsterIdList.Count)
                {
                    CoinChange(300);
                    if (monsterSpawnIndex == _levelData.monsterIdList.Count - 1)
                    {
                        if (spawnState)
                        {
                            return;
                        }

                        spawnState = true;
                        WindowMgr.instance.ShowWindow<DialogWindow>()
                            .Init(5, 7, () => { StartCoroutine(YanShi(5)); });
                    }
                    else
                    {
                        if (spawnState)
                        {
                            return;
                        }

                        spawnState = true;
                        StartCoroutine(YanShi(5));
                    }
                }
                else
                {
                    //打完了
                    if (monsterSpawnIndex >= _levelData.monsterIdList.Count)
                    {
                        if (!gameEnd)
                        {
                            WindowMgr.instance.ShowWindow<GameEndWindow>().Init(true);
                        }
                    }
                }
            }
        }

        private bool spawnState;

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


        public Action updateCoinChange;

        private void CoinChange(int value)
        {
            coin += value;
            Game.instance.DisplayCoin();
            updateCoinChange?.Invoke();
        }

        public void CloseHighlight(int heroId, StanceEnum stanceEnum)
        {
            for (int i = 0; i < platformItemList.Count; i++)
            {
                platformItemList[i].CloseHighlight();
            }

            int price = HeroConfig.GetHeroPrice(heroId);
            if (coin < price)
            {
                return;
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
                        CoinChange(-price);
                        return;
                    }
                }
            }
        }
    }
}