using System;
using System.Collections;
using System.Collections.Generic;
using Script.Role.Control.MonsterControl;
using Script.Role.Data;
using UnityEngine;

namespace Script.Manager
{
    public class FightMgr : MonoBehaviour
    {
        public static FightMgr instance;
        public List<PlatformItem> platformItemList;
        public List<GameObject> heroModelList;
        
        public List<GameObject> monsterList;
        public Transform monsterContent;

        public List<Transform> monsterPathList;
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            InstantiateMonster();
        }

        public void InstantiateMonster()
        {
            StartCoroutine(SpawnMonster(2));
        }

        private WaitForSeconds waitForSeconds=new WaitForSeconds(2);
        IEnumerator SpawnMonster(int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                GameObject monster=Instantiate(monsterList[0],monsterContent);
                monster.GetComponent<BeeMonsterControl>().Init(monsterPathList);
                monster.SetActive(true);
                yield return waitForSeconds;
            }
        }

        public GameObject GetHeroModel(int id)
        {
            if (heroModelList.Count > id)
            {
                return heroModelList[id];
            }

            return heroModelList[0];
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

        public void CloseHighlight(GameObject heroModel, StanceEnum stanceEnum)
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
                        platformItemList[i].InstantiateHero(heroModel);
                    }
                }
            }
        }
    }
}