using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using Script.Role.Skill;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Role.Control.Hero
{
    public abstract class HeroControl : BaseControl
    {
        protected StanceEnum attackStance;
        protected MonsterControl.MonsterControl targetControl;
        public new HeroData data;
        public ISkillInterface skill;

        public NatureUi natureUi;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            animList = anim.runtimeAnimatorController.animationClips;
        }

        private void Start()
        {
            anim.Play("Idle");
            Init();
            natureUi.Init(data,CancelHero,UseSkill);
        }

        private void CancelHero()
        {
            transform.parent.GetComponent<PlatformItem>().CancelHero();
        }

        public void Init()
        {
            InitData();
            InitSkill();
            InvokeRepeating(nameof(ReplyEnergy), 1, 1);
        }

        public void InvokeChangeState()
        {
            animState = false;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.Play("Idle");
            }
        }

        public virtual void SetPos()
        {
            
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

            CheckoutState();
        }

        public virtual void CheckoutState()
        {
            if (targetControl==null)
            {
                targetControl =
                    FightMgr.instance.GetMonsterTarget(transform.position, data.AttackDistance, attackStance);
            }
            if (targetControl != null && data.CurrentAttackInterval <= 0)
            {
                Attack();
            }
        }

        public abstract void InitSkill();
        public abstract void InitData();

        public virtual void ReplyEnergy()
        {
            if (data.Alive && data.Energy < data.MaxEnergy)
            {
                data.Energy += 1;
                if (data.Energy > data.MaxEnergy)
                {
                    data.Energy = data.MaxEnergy;
                }
                natureUi.UpdateEnergy();
            }
        }

        public virtual void UseSkill()
        {
            if (data.Alive && data.Energy >= data.MaxEnergy)
            {
                data.Energy = 0;
                Debug.LogWarning("使用技能");
                skill.UseSkill();
            }
        }

        public override void Hurt(int value)
        {
            value -= data.Defense;
            if (value<=0)
            {
                value = Random.Range(1, 5);
            }
            LifeChange(-value);
        }

        public virtual void ReplyLife(int value)
        {
            LifeChange(value);
        }

        public override void LifeChange(int value)
        {
            if (data.Alive)
            {
                data.Life += value;
                if (data.Life > data.MaxLife)
                {
                    data.Life = data.MaxLife;
                }

                if (data.Life <= 0)
                {
                    data.Life = 0;
                    Die();
                }
            }
            natureUi.UpdateLifeDisplay();
        }

        public override void Die()
        {
            data.Alive = false;
            CancelInvoke(nameof(ReplyEnergy));
            Destroy(gameObject);
        }

        public override void Attack()
        {
            if (targetControl != null && !targetControl.data.Alive)
            {
                targetControl = null;
                return;
            }

            if (targetControl != null && targetControl.data.Alive)
            {
                Damage();
                data.CurrentAttackInterval = data.AttackInterval;
            }
        }

        public override void Damage()
        {
            Debug.Log("英雄：攻击");
            //播放动作
            //延时造成伤害
            anim.Play("Attack");
            animState = true;
            Invoke(nameof(InvokeChangeState), GetAnimTime("Attack"));
            DOTween.Sequence().InsertCallback(0.4f, () => { targetControl.Hurt(data.Attack); });
        }
    }
}