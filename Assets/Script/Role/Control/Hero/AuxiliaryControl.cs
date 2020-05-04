using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using Script.Role.Skill;
using UnityEngine;

namespace Script.Role.Control.Hero
{
    public class AuxiliaryControl : HeroControl
    {
        private Vector3 pos = new Vector3(-0.12f, 1.36f, 0);

        public Transform skillPos;
        public override void InitSkill()
        {
            skill=new AddLifeSkill(transform,5,10,skillPos);
        }

        public override void SetPos()
        {
            transform.localPosition = pos;
        }

        public override void InitData()
        {
            data = new HeroData(7, "安", AttackTargetEnum.Player, 30, 20,
                2, 10, 3, 2, OccupationEnum.Auxiliary, StanceEnum.Highland);
            attackStance = StanceEnum.None;
        }

        private List<HeroControl> distanceHeroList;
        public override void CheckoutState()
        {
            Attack();
        }

        private bool addLifeState;
        public override void Attack()
        {
            if (data.CurrentAttackInterval<=0)
            {
                addLifeState = false;
                distanceHeroList = FightMgr.instance.GetOnDistanceHero(transform.position, data.AttackDistance);
                if (distanceHeroList.Count>0)
                {
                    for (int i = 0; i < distanceHeroList.Count; i++)
                    {
                        if (distanceHeroList[i].data.Life<distanceHeroList[i].data.MaxLife)
                        {
                            addLifeState = true;
                            break;
                        }
                    }

                    if (addLifeState)
                    {
                        Damage();
                    }
                }
            }
        }

        public override void Damage()
        {
            ChangeDir();
            if (_audioSource)
            {
                if (MainMgr.instance.GetBackGroupState())
                {
                    _audioSource.PlayOneShot(_audioSource.clip);
                }
            }
            data.CurrentAttackInterval = data.AttackInterval;
            Debug.LogWarning(distanceHeroList.Count);
            Debug.Log("英雄：恢复");
            //播放动作
            //延时造成伤害
            anim.Play("Attack");
            animState = true;
            Invoke(nameof(InvokeChangeState), GetAnimTime("Attack"));
            DOTween.Sequence().InsertCallback(0.4f, () =>
            {
                for (int i = 0; i < distanceHeroList.Count; i++)
                {
                    distanceHeroList[i].ReplyLife(data.Attack);
                }
            });
        }
    }
}
