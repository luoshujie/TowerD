namespace Script.Role.Data
{
    public class MonsterData : BaseData
    {
        public MonsterData(int id, string roleName, int maxLife, float attackDistance,
            int attack, int defense,
            float attackInterval)
        {
            AttackTarget = AttackTargetEnum.Player;
            RoleName = roleName;
            Id = id;
            Ascription = AscriptionEnum.Monster;
            Life = maxLife;
            MaxLife = maxLife;
            Alive = true;
            AttackDistance = attackDistance;
            Attack = attack;
            Defense = defense;
            AttackInterval = attackInterval;
            CurrentAttackInterval = 0;
        }
    }
}