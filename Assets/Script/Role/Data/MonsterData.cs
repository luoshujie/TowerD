namespace Script.Role.Data
{
    public class MonsterData : BaseData
    {
        public float speed;
        public MonsterData(int id, string roleName, int maxLife, float attackDistance,
            int attack, int defense,
            float attackInterval,StanceEnum stance,float speed)
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
            this.Stance = stance;
            this.speed = speed;
        }
    }
}