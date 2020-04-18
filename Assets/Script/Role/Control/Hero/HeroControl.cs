using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Script.Role.Data;
using Script.Role.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public abstract class HeroControl : BaseControl
    {
        protected StanceEnum attackStance;
        protected MonsterControl.MonsterControl targetControl;
        public new HeroData data;
        public ISkillInterface skill;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            InitData();
            InitSkill();
            InvokeRepeating(nameof(ReplyEnergy), data.EnergyCoolTime, data.EnergyCoolTime);
        }

        private void FixedUpdate()
        {
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
            }
        }

        public virtual bool UseSkill()
        {
            if (data.Alive && data.Energy >= data.MaxEnergy)
            {
                data.Energy = 0;
                skill.UseSkill(data);
            }

            return false;
        }

        public override void Hurt(int value)
        {
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
            //播放动作
            //延时造成伤害
            targetControl.Hurt(data.Attack);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (attackStance == StanceEnum.None)
            {
                if (targetControl != null && targetControl.data.Stance != StanceEnum.Highland)
                {
                    if (other.CompareTag("Monster"))
                    {
                        MonsterControl.MonsterControl control =
                            other.transform.parent.GetComponent<MonsterControl.MonsterControl>();

                        if (attackStance == StanceEnum.Highland)
                        {
                            if (control.data.Alive)
                            {
                                targetControl = control;
                            }
                        }
                    }
                }
            }

            if (targetControl == null)
            {
                if (other.CompareTag("Monster"))
                {
                    MonsterControl.MonsterControl control =
                        other.transform.parent.GetComponent<MonsterControl.MonsterControl>();

                    if (attackStance == StanceEnum.None)
                    {
                        if (control.data.Alive)
                        {
                            targetControl = control;
                        }
                    }
                    else if (control.data.Alive && control.data.Stance == attackStance)
                    {
                        targetControl = control;
                    }
                }
            }
        }
    }
}