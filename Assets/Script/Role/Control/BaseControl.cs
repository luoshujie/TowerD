using Script.Role.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Role.Control
{
    public abstract class BaseControl : MonoBehaviour
    {
        protected Animator anim;
        public BaseData data;
        public abstract void Hurt(int value);
        public abstract void LifeChange(int value);
        public abstract void Die();
        public abstract void Damage();

        public abstract void Attack();
    }
}