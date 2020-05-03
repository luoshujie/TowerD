using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Manager
{
    public class EffectMgr : MonoBehaviour
    {
        public static EffectMgr instance;
        private Dictionary<int, List<GameObject>> EffectDic;

        private void Awake()
        {
            instance = this;
            EffectDic=new Dictionary<int, List<GameObject>>()
            {
                {0,new List<GameObject>()},
                {1,new List<GameObject>()},
            };
        }

        public void ShowEffect(Transform tranf,int id)
        {
            
        }

        public GameObject GetEffectGo(int id)
        {
            GameObject go=null;
            if (EffectDic[id].Count>0)
            {
                 go= EffectDic[id][0];
                EffectDic[id].RemoveAt(0);
            }
            else
            {
                go = InstantiateEffect();
            }

            return go;
        }

        private GameObject InstantiateEffect()
        {
           return Instantiate(gameObject, transform);
        }
        
        public void Reduction(GameObject go,int id)
        {
            go.SetActive(false);
            go.transform.parent = transform;
            EffectDic[id].Add(go);
        }
    }
}
