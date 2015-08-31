
namespace Demo_R.O.S.E.Skill
{
    /// <summary>
    /// Skill Data
    /// </summary>
    public class ROSESkill
    {
        public uint m_iSkillGUID;
        public uint m_iSkillID;
        public uint m_iLevel;
        public uint m_iType;
        public uint m_iRange;
        public uint m_iTarget;
        public uint m_iDuration;
        public uint m_iAttackPower;
        public uint m_iMP;
        public uint[] Weapon = new uint[5];
        public uint[] rSkill = new uint[3];
        public uint[] lSkill = new uint[3];
        public uint[] c_Class = new uint[4];
        public uint cLevel;
        public uint Success;
        public uint SP;
        public uint[] buff = new uint[3];
        public uint[] value1 = new uint[3];
        public uint[] value2 = new uint[3];
        public uint nbuffs;
        public ushort aoe;
        public uint aoeradius;
        public uint Script;
        public uint svalue1;
    }
}
