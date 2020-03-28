using Script.Role.Data;
using Script.Role.Fsm;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Role.Control
{
    public abstract class BaseControl : MonoBehaviour
    {
        public Animator anim;
        public FsmSystem fsmSystem;
        public BaseData data;

        public abstract void Init();
        public abstract void Hurt(int value);
        public abstract void ChangeLife(int value);
        public abstract void Die();
        public abstract void Damage();
    }
}