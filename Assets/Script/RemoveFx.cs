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
        private AudioSource _audioSource;

        public void Init(int id)
        {
            this.id = id;
            ps = GetComponent<ParticleSystem>();
            removeTime = EffectMgr.instance.GetPsLen(ps);
            _audioSource = GetComponent<AudioSource>();
        }
        public void Show()
        {
            if (_audioSource)
            {
                if (MainMgr.instance.GetBackGroupState())
                {
                    _audioSource.PlayOneShot(_audioSource.clip);
                }
            }
            
            ps.Play();
            Invoke(nameof(Remove),removeTime);
        }

        private void Remove()
        {
            EffectMgr.instance.Reduction(this,id);
        }
    }
}
