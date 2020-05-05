using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Manager
{
    public class EffectMgr : MonoBehaviour
    {
        public static EffectMgr instance;
        private Dictionary<int, List<RemoveFx>> EffectDic;

        public List<GameObject> fxPrefabList;


        private void Awake()
        {
            instance = this;
            Init();
        }

        private void Init()
        {
            EffectDic = new Dictionary<int, List<RemoveFx>>(){ };
            for (int i = 0; i < fxPrefabList.Count; i++)
            {
                if (!EffectDic.ContainsKey(i))
                {
                    EffectDic.Add(i,new List<RemoveFx>());
                }

                for (int j = 0; j < 5; j++)
                {
                    RemoveFx fx=InstantiateEffect(fxPrefabList[i]);
                    fx.Init(i);
                    EffectDic[i].Add(fx);
                }
            }
        }

        public void PlayAddLifeFx(Transform tranf)
        {
            RemoveFx fx=GetEffectGo(0);
            fx.transform.parent = tranf;
            fx.transform.localPosition = Vector3.zero;
            ShowEffect(fx);
        }
        public void PlayHurtFx(Transform tranf)
        {
            RemoveFx fx=GetEffectGo(1);
            fx.transform.parent = tranf;
            fx.transform.localPosition = Vector3.zero;
            ShowEffect(fx);
        }

        public void PlayMonsterDie(Vector3 pos)
        {
            RemoveFx fx=GetEffectGo(2);
            fx.transform.position = pos;
            ShowEffect(fx);
        }
        

        public void BeeMonsterAttack(Transform tranf,bool rotate)
        {
            RemoveFx fx=GetEffectGo(3);
            Vector3 scale=new Vector3(fx.transform.localScale.x,fx.transform.localScale.y,Mathf.Abs(fx.transform.localScale.z));
            
            if (!rotate)
            {
                scale.z = -scale.z;
            }

            fx.transform.localScale = scale;
            fx.transform.parent = tranf;
            fx.transform.localPosition =Vector3.zero;
            ShowEffect(fx);
        }
        public void PlayGunFire(Transform tranf)
        {
            RemoveFx fx=GetEffectGo(4);
            fx.transform.parent = tranf;
            fx.transform.localPosition = Vector3.zero;
            ShowEffect(fx);
        }
        
        public void PlayHeroDie(Vector3 pos)
        {
            RemoveFx fx=GetEffectGo(5);
            fx.transform.position = pos;
            ShowEffect(fx);
        }
        
        public void PlayAddLifeSkill(Transform tranf)
        {
            RemoveFx fx=GetEffectGo(6);
            fx.transform.parent = tranf;
            fx.transform.localPosition = Vector3.zero;
            ShowEffect(fx);
        }
        public void PlayAddDefenseSkill(Transform tranf)
        {
            RemoveFx fx=GetEffectGo(7);
            fx.transform.parent = tranf;
            fx.transform.localPosition = Vector3.zero;
            ShowEffect(fx);
        }
        public void PlaBigMoveSkill()
        {
            RemoveFx fx=GetEffectGo(8);
            fx.transform.position = Vector3.zero;
            ShowEffect(fx);
        }

        private void ShowEffect(RemoveFx fx)
        {
            fx.gameObject.SetActive(true);
            fx.Show();
        }

        private RemoveFx GetEffectGo(int id)
        {
            RemoveFx go = null;
            if (EffectDic[id].Count > 0)
            {
                go = EffectDic[id][0];
                EffectDic[id].RemoveAt(0);
            }
            else
            {
                go = InstantiateEffect(fxPrefabList[id]);
                go.Init(id);
            }

            return go;
        }

        public float GetPsLen(ParticleSystem ps)
        {
            float maxDuration = 0;
            if (ps.enableEmission)
            {
                if (ps.loop)
                {
                    return -1f;
                }

                float dunration = 0f;
                if (ps.emissionRate <= 0)
                {
                    dunration = ps.startDelay + ps.startLifetime;
                }
                else
                {
                    dunration = ps.startDelay + Mathf.Max(ps.duration, ps.startLifetime);
                }

                if (dunration > maxDuration)
                {
                    maxDuration = dunration;
                }
            }

            return maxDuration;
        }

        private RemoveFx InstantiateEffect(GameObject go)
        {
            return Instantiate(go, transform).GetComponent<RemoveFx>();
        }

        public void Reduction(RemoveFx go, int id)
        {
            go.gameObject.SetActive(false);
            go.transform.parent = transform;
            EffectDic[id].Add(go);
        }
    }
}