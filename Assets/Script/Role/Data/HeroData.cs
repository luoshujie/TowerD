using UnityEngine;

namespace Script.Role.Data
{
    public class HeroData : BaseData
    {
        /// <summary>
        /// 职业
        /// </summary>
        public OccupationEnum Occupation;

        /// <summary>
        /// 站位
        /// </summary>
        public StanceEnum Stance;

        public int Energy;
        public int MaxEnergy;

        public float EnergyCoolTime;

        public HeroData(int id, string roleName, AttackTargetEnum attackTargetEnum, int maxLife,float energyCoolTime, int maxEnergy,
            int attack, int defense, float attackDistance, float attackInterval, OccupationEnum occupation,
            StanceEnum stance)
        {
            
            Alive = true;
            Id = id;
            RoleName = roleName;
            AttackTarget = attackTargetEnum;
            MaxLife = maxLife;
            Life = maxLife;
            MaxEnergy = maxEnergy;
            Energy = 0;
            EnergyCoolTime = MaxEnergy/energyCoolTime;
            Attack = attack;
            Defense = defense;
            AttackDistance = attackDistance;
            AttackInterval = attackInterval;
            Occupation = occupation;
            Stance = stance;
            Ascription = AscriptionEnum.Player;
            CurrentAttackInterval = 0;
        }
    }
}