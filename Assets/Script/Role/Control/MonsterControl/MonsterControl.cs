using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Control.Hero;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Role.Control.MonsterControl
{
    public class MonsterControl : BaseControl
    {
        private List<Vector3> pathPosList;
        private Vector3 nextPos;
        public new MonsterData data;
        protected HeroControl targetControl;
        protected SpriteRenderer renderer;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            renderer = GetComponent<SpriteRenderer>();
            animList = anim.runtimeAnimatorController.animationClips;
        }

        public void InvokeChangeState()
        {
            animState = false;
        }

        public float GetAnimTime(string animName)
        {
            for (int i = 0; i < animList.Length; i++)
            {
                if (animList[i].name == animName)
                {
                    return animList[i].length;
                }
            }

            return 0;
        }

        public void InitPath(List<Transform> posList)
        {
            pathPosList = new List<Vector3>();
            transform.position = posList[0].position;
            for (int i = 1; i < posList.Count; i++)
            {
                pathPosList.Add(posList[i].position);
            }

            nextPos = pathPosList[0];
            pathPosList.RemoveAt(0);
            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (animState)
            {
                return;
            }
            if (data == null)
            {
                return;
            }

            if (!data.Alive)
            {
                return;
            }

            if (data.CurrentAttackInterval > 0)
            {
                data.CurrentAttackInterval -= Time.fixedDeltaTime;
            }

            if (targetControl == null)
            {
                targetControl = FightMgr.instance.GetHeroTarget(transform.position, data.AttackDistance, data.Stance);
                OnMoveForTarget();
            }
            else
            {
                Attack();
            }
        }

        public override void Attack()
        {
            if (!targetControl.data.Alive)
            {
                targetControl = null;
                return;
            }

            if (targetControl != null && targetControl.data.Alive)
            {
                if (data.CurrentAttackInterval <= 0)
                {
                    Debug.Log("怪物：攻击");
                    //攻击
                    Damage();
                    data.CurrentAttackInterval = data.AttackInterval;
                }
            }
        }

        public override void Damage()
        {
            //播放攻击动画
            //一定时间后造成伤害
            anim.Play("Attack");
            animState = true;
            Invoke(nameof(InvokeChangeState),GetAnimTime("Attack"));
            DOTween.Sequence().InsertCallback(0.2f, () => { targetControl.Hurt(data.Attack); });
        }

        public void OnMoveForTarget()
        {
            if (Vector3.Distance(transform.position, nextPos) > 0.2f)
            {
                if (nextPos.x<transform.position.x)
                {
                    renderer.flipX = true;
                }
                else
                {
                    renderer.flipX = false;
                }
                transform.position += (nextPos - transform.position).normalized * Time.fixedDeltaTime * data.speed;
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                {
                    anim.Play("Walk");
                }
            }
            else
            {
                if (pathPosList.Count > 0)
                {
                    nextPos = pathPosList[0];
                    pathPosList.RemoveAt(0);
                }
                else
                {
                    Debug.LogWarning("到达目的地");
                    FightMgr.instance.RedueCrystal();
                    FightMgr.instance.MonsterDie(this,true);
                    Destroy(gameObject);
                }
            }
        }

        public override void Hurt(int value)
        {
            if (data.Alive)
            {
                LifeChange(-value);
            }
        }

        public override void LifeChange(int value)
        {
            data.Life += value;
            if (data.Life < 0)
            {
                data.Life = 0;
                data.Alive = false;
                Die();
            }
        }

        public override void Die()
        {
            FightMgr.instance.MonsterDie(this);
            Destroy(gameObject);
        }

//        private void OnTriggerStay2D(Collider2D other)
//        {
//            if (targetControl == null)
//            {
//                if (other.CompareTag("Hero"))
//                {
//                    HeroControl control = other.transform.parent.GetComponent<HeroControl>();
//                    if (control.data.Alive && control.data.Stance == data.Stance)
//                    {
//                        targetControl = control;
//                    }
//                }
//            }
//        }
    }
}