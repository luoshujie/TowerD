﻿using System.Collections.Generic;
using Script.Manager;
using Script.Role.Control.Hero;
using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Skill
{
    public class AddLifeSkill : ISkillInterface
    {
        private Transform tranf;
        private float distance;
        private int valueLife;
        private List<HeroControl> _heroControls;
        private Transform skillPos;

        public AddLifeSkill(Transform _tranf, float _distance, int _value,Transform skillPos)
        {
            this.skillPos = skillPos;
            tranf = _tranf;
            distance = _distance;
            valueLife = _value;
        }
        public void UseSkill()
        {
            EffectMgr.instance.PlayAddLifeSkill(skillPos);
            _heroControls = FightMgr.instance.GetOnDistanceHero(tranf.position, distance);
            for (int i = 0; i < _heroControls.Count; i++)
            {
                _heroControls[i].ReplyLife(valueLife);
            }
        }
    }
}
