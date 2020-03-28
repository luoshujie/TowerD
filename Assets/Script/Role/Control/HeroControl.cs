using System;
using Script.Role.Data;
using Script.Role.Fsm;
using Script.Role.Skill;
using UnityEngine;

namespace Script.Role.Control
{
    public abstract class HeroControl : BaseControl
    {
        public new HeroData data;
        public ISkillInterface skill;

        protected void Start()
        {
            Init();
        }

        public override void Init()
        {
            fsmSystem = new FsmSystem();
            anim = GetComponent<Animator>();
            InitData();
            InitSkill();
            InitFsmState();
            InvokeRepeating(nameof(ReplyEnergy), data.EnergyCoolTime, data.EnergyCoolTime);
        }

        public abstract void InitSkill();
        public abstract void InitData();
        public abstract void InitFsmState();

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

        public override void Hurt(int value)
        {
            ChangeLife(-value);
        }

        public virtual void ReplyLife(int value)
        {
            ChangeLife(value);
        }

        public override void ChangeLife(int value)
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
        }

        public override void Damage()
        {
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
    }
}