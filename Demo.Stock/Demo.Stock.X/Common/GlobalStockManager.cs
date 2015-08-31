using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Mmose.Collections;

namespace Demo.Stock.X.Common
{
    public static class GlobalStockManager
    {
        /// <summary>
        /// 股票板块+股票种类检索股票管理信息
        /// </summary>
        private static Dictionary<string, Dictionary<string, StockManager>> m_StockManagerVarietyByPlate = new Dictionary<string, Dictionary<string, StockManager>>();
        public static StockManager GetStockManagerByPlateAndVariety( string strPlate, string strVariety )
        {
            Dictionary<string, StockManager> outStockManagerByVariety = null;
            if ( m_StockManagerVarietyByPlate.TryGetValue( strPlate, out outStockManagerByVariety ) == true )
            {
                StockManager outStockManager = null;
                if ( outStockManagerByVariety.TryGetValue( strVariety, out outStockManager ) == true )
                    return outStockManager;
            }

            return null;
        }

        /// <summary>
        /// 全部的股票信息
        /// </summary>
        private static HashSet<StockManager> m_StockManagerHashSet = new HashSet<StockManager>();
        public static IEnumerable<StockManager> ToArray()
        {
            return m_StockManagerHashSet;
        }

        /// <summary>
        /// 全部的股票板块信息
        /// </summary>
        private static HashSet<string> m_PlateArray = new HashSet<string>();
        public static IEnumerable<string> ToArrayPlate()
        {
            return m_PlateArray;
        }

        /// <summary>
        /// 股票板块检索全部的股票种类信息
        /// </summary>
        private static MultiDictionary<string, string> m_StockVarietyByPlate = new MultiDictionary<string, string>( false );
        public static IEnumerable<string> ToArrayVarietyByPlate( string strPlate )
        {
            return m_StockVarietyByPlate[strPlate];
        }

        /// <summary>
        /// 添加股票
        /// </summary>
        /// <param name="stockManager"></param>
        public static void AddStockManager( StockManager stockManager )
        {
            Dictionary<string, StockManager> outStockManagerByVariety = null;
            if ( m_StockManagerVarietyByPlate.TryGetValue( stockManager.StockPlate, out outStockManagerByVariety ) == false )
            {
                outStockManagerByVariety = new Dictionary<string, StockManager>();

                m_StockManagerVarietyByPlate.Add( stockManager.StockPlate, outStockManagerByVariety );
            }

            outStockManagerByVariety.Add( stockManager.StockVariety, stockManager );

            m_StockManagerHashSet.Add( stockManager );

            m_PlateArray.Add( stockManager.StockPlate );

            m_StockVarietyByPlate.Add( stockManager.StockPlate, stockManager.StockVariety );
        }

        public static void Clear()
        {
            m_StockManagerVarietyByPlate.Clear();
            m_StockManagerHashSet.Clear();
            m_PlateArray.Clear();
            m_StockVarietyByPlate.Clear();
        }
    }
}
