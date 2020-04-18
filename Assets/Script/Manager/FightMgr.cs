using System;
using System.Collections;
using System.Collections.Generic;
using Script.Role.Control.Hero;
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

        public List<GameObject> heroSpriteList;
        
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TouchHero();
            }
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
                monster.GetComponent<MonsterControl>().InitPath( monsterPathList);
                monster.SetActive(true);
                yield return waitForSeconds;
            }
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

        public HeroControl TouchHero()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,Mathf.Infinity,1 <<LayerMask.NameToLayer("Hero")))
            {
                Debug.LogWarning(hit.collider.name);
            }

            return null;
        }
    }
}