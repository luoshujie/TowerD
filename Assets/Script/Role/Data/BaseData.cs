namespace Script.Role.Data
{
    public class BaseData
    {
        public AttackTargetEnum AttackTarget;

        public AscriptionEnum Ascription;

        public string RoleName;
        
        public int Id;
        public int Life;
        public int MaxLife;
        public bool Alive;
        public float AttackDistance;
        public int Attack;
        public int Defense;
        public float AttackInterval;
        public int CurrentAttackInterval;
    }

    public enum OccupationEnum
    {
        /// <summary>
        /// 枪手
        /// </summary>
        Gunmen,

        /// <summary>
        /// 肉盾
        /// </summary>
        MeatShield,

        /// <summary>
        /// 辅助
        /// </summary>
        Auxiliary,

        /// <summary>
        /// 战士
        /// </summary>
        Warrior
    }

    public enum StanceEnum
    {
        /// <summary>
        /// 高地
        /// </summary>
        Highland,

        /// <summary>
        /// 低地
        /// </summary>
        Lowland
    }

    /// <summary>
    /// 攻击的目标是谁
    /// </summary>
    public enum AttackTargetEnum
    {
        Monster,
        Player
    }

    /// <summary>
    /// 单位的归属
    /// </summary>
    public enum AscriptionEnum
    {
        Player,
        Monster
    }
}