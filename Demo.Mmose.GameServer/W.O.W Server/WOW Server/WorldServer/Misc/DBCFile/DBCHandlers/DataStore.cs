#region zh-CHS 版权所有 (C) 2006 - 2006 DemoSoft Corporation. 保留所有权利 | en Copyright (C) 2006 - 2006 DemoSoft Corporation. All Rights Reserved.

// COPYRIGHT NOTES
// ---------------
//
// This file is a part of the G.O.S.E(Game Online Server Engine) for .NET.
//
//           2007-2008 Demo Software, All Rights Reserved.
//
// This source code can only be used under the terms and conditions outlined
// in the accompanying license agreement.
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

#region zh-CHS 包含名字空间 | en Include namespace
using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
#endregion

namespace Demo.Wow.WorldServer.DBC
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataStore<T> where T : ILoad<T>, new()
    {
        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private DBCFile m_DBCFile = new DBCFile();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<uint, T> m_DataByID = new Dictionary<uint,T>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<uint, T> m_DataByRow = new Dictionary<uint,T>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<uint, uint> m_IndexRowByID = new Dictionary<uint,uint>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<uint, uint> m_IndexIDByRow = new Dictionary<uint,uint>();
        #endregion

        #region zh-CHS 共有属性 | en Public Properties

        #region zh-CHS 私有成员变量 | en Private Member Variables
        /// <summary>
        /// 
        /// </summary>
        private uint m_Count = 0;
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public uint Count
        {
            get { return m_Count; }
        }

        #endregion

        #region zh-CHS 共有方法 | en Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public bool LoadFile( string strFileName )
        {
            if ( m_DBCFile.Open( strFileName ) == false )
            {
                Debug.WriteLine( "DataStore.LoadFile(...) - m_DBCFile.Open(...) == false error!" );
                return false;
            }

            for ( uint iIndexRow = 0; iIndexRow < m_DBCFile.RecordCount; iIndexRow++ )
            {
                bool bReturn = true;
                do
                {
                    DBCRecord dbcRecord = m_DBCFile.GetRecord( iIndexRow );
                    if ( dbcRecord == null )
                    {
                        Debug.WriteLine( "DataStore.LoadFile(...) - dbcRecord == null error!" );

                        bReturn = false;
                        break;
                    }

                    T dataT = new T();
                    if ( dataT == null )
                    {
                        Debug.WriteLine( "DataStore.LoadFile(...) - dataT == null error!" );

                        bReturn = false;
                        break;
                    }

                    if ( dataT.Load( dbcRecord ) == false )
                    {
                        Debug.WriteLine( "DataStore.LoadFile(...) - dataT.Load(...) == false error!" );

                        bReturn = false;
                        break;
                    }

                    m_DataByID.Add( dataT.ID, dataT );
                    m_DataByRow.Add( iIndexRow, dataT );
                    m_IndexRowByID.Add( dataT.ID, iIndexRow );
                    m_IndexIDByRow.Add( iIndexRow, dataT.ID );

                } while ( false );

                if ( bReturn == false )
                {
                    m_DataByID.Clear();
                    m_DataByRow.Clear();
                    m_IndexRowByID.Clear();
                    m_IndexIDByRow.Clear();

                    m_DBCFile.Close();
                    return false;
                }
            }

            m_Count = m_DBCFile.RecordCount;

            m_DBCFile.Close();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIndexRow"></param>
        /// <returns></returns>
        public T LookupRowEntry( uint iIndexRow )
        {
            T returnDataT = default( T );
            m_DataByRow.TryGetValue( iIndexRow, out returnDataT );

            return returnDataT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIndexID"></param>
        /// <returns></returns>
        public T LookupIDEntry( uint iIndexID )
        {
            T returnDataT = default( T );
            m_DataByID.TryGetValue( iIndexID, out returnDataT );

            return returnDataT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIndexID"></param>
        /// <returns></returns>
        public uint GetRow( uint iIndexID )
        {
            uint iReturnRow = 0;
            m_IndexRowByID.TryGetValue( iIndexID, out iReturnRow );

            return iReturnRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iIndexRow"></param>
        /// <returns></returns>
        public uint GetID( uint iIndexRow )
        {
            uint iReturnID = 0;
            m_IndexIDByRow.TryGetValue( iIndexRow, out iReturnID );

            return iReturnID;
        }

        #endregion
    }
}
#endregion