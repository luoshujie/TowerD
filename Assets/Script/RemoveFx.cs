using System;
using Script.Manager;
using UnityEngine;

namespace Script
{
    public class RemoveFx : MonoBehaviour
    {
        private int id;
        private ParticleSystem ps;
        private float removeTime = 0;

        public void Init(int id)
        {
            this.id = id;
            ps = GetComponent<ParticleSystem>();
            removeTime = EffectMgr.instance.GetPsLen(ps);
        }
        public void Show()
        {
            ps.Play();
            Invoke(nameof(Remove),removeTime);
        }

        private void Remove()
        {
            EffectMgr.instance.Reduction(this,id);
        }
    }
}
