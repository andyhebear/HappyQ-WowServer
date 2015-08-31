#region zh-CHS 2006 - 2008 DemoSoft �Ŷ� | en 2006 - 2008 DemoSoft Team

//     NOTES
// ---------------
//
// This file is a part of the MMOSE(Massively Multiplayer Online Server Engine) for .NET.
//
//                              2006-2008 DemoSoft Team
//
//
// First Version : by H.Q.Cai - mailto:caihuanqing@hotmail.com

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Lesser General Public License as published
 *   by the Free Software Foundation; either version 2.1 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

#region zh-CHS �������ֿռ� | en Include namespace

#endregion

namespace Demo.Mmose.Core.AIEngine
{
    #region zh-CHS ö�� | en Enum
    /// <summary>
    /// ָ�� MobileAI �ĵ������ȼ���
    /// </summary>
    public enum AIProcessPriority
    {
        /// <summary>
        /// ���Խ� MobileAI �����ھ����κ��������ȼ����߳�֮��
        /// </summary>
        Lowest = 0,
        /// <summary>
        /// ���Խ� MobileAI �����ھ��� Normal ���ȼ����߳�֮���ھ��� Lowest ���ȼ����߳�֮ǰ��
        /// </summary>
        BelowNormal = 1,
        /// <summary>
        /// ���Խ� MobileAI �����ھ��� AboveNormal ���ȼ����߳�֮���ھ��� BelowNormal ���ȼ����߳�֮ǰ��Ĭ������£��߳̾��� Normal ���ȼ���
        /// </summary>
        Normal = 2,
        /// <summary>
        /// ���Խ� MobileAI �����ھ��� Highest ���ȼ����߳�֮���ھ��� Normal ���ȼ����߳�֮ǰ��
        /// </summary>
        AboveNormal = 3,
        /// <summary>
        /// ���Խ� MobileAI �����ھ����κ��������ȼ����߳�֮ǰ��
        /// </summary>
        Highest = 4,
    }
    #endregion
}
#endregion