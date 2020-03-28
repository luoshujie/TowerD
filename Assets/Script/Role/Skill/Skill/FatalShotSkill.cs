using Script.Role.Data;
using UnityEngine;

namespace Script.Role.Skill.Skill
{
    public class FatalShotSkill : ISkillInterface
    {
        public Transform TargetTrans;
        public FatalShotSkill(Transform targetTrans)
        {
            this.TargetTrans = targetTrans;
        }
        public void UseSkill(HeroData data)
        {
            
        }
    }
}
