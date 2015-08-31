using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Wow.WorldServer.Map
{
    class TerrainInfo
    {
        /// <summary>
        /// 
        /// </summary>
        ushort[,] m_AreaID = new ushort[2, 2];
        /// <summary>
        /// ������
        /// </summary>
        public ushort[,] AreaID
        {
            get { return m_AreaID; }
            set { m_AreaID = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        byte[,] m_LiquidType = new byte[2, 2];
        /// <summary>
        /// ˮ������
        /// </summary>
        public byte[,] LiquidType
        {
            get { return m_LiquidType; }
            set { m_LiquidType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        float[,] m_LiquidLevel = new float[2, 2];
        /// <summary>
        /// ˮ����Ϣ
        /// </summary>
        public float[,] LiquidLevel
        {
            get { return m_LiquidLevel; }
            set { m_LiquidLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        float[,] m_Z = new float[32, 32];
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public float[,] Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }
    }
}
