using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using DogSE.Library.Log;

namespace DogSE.Library.Util
{
    /*
    /// ��Ϸ�ڵ���Ϣ��ͨ��ʹ��ö�ٽ��ж���
    /// ����Ϸ������뷽��Ļ����Ϣ���Ӧ�����ƺ�����
    /// ���Լ̳б�����
    /// ���磺
    ///     public enum OpCode 
    ///     {
    ///// <summary>
    ///// ��Ϣ������ֺ�������ȡ������
    ///// </summary>
    ///         Code = 1,
    ///     }
    /// ֻ��Ҫ��һ���̳�
    ///     public class OpCodeName:OpCodeNameUtil&lt;OpCode&gt;
    ///     {
    ///     }
    /// �Ϳ����ڼ̳���ľ�̬����������Ϣ���Ӧ�����ƺ�����
    /// ��Ҫע��ĵط������Ҫ������Ϣ�����������Ҫ��Ϣ����Ŀ��xml����ĵ�
    /// ����ʹ�ÿ��Կ���Ԫ��������
    */
        /// <summary>
        /// ��Ϣ������ֺ�������ȡ������
        /// </summary>
        /// <remarks>
        /// </remarks>
        public class OpCodeNameUtil<T>
        {

            /// <summary>
            /// 
            /// </summary>
            private static readonly Dictionary<int, string> s_opCodeName = new Dictionary<int, string>();

            /// <summary>
            /// �����Ϣ�������
            /// </summary>
            /// <param name="iOpCode"></param>
            public static string GetOpCodeName(int iOpCode)
            {
                var str = Enum.GetName(typeof(T), iOpCode);
                if (string.IsNullOrEmpty(str))
                    return "Unknow";
                return str;
            }

            /// <summary>
            /// �����Ϣ�������
            /// </summary>
            /// <param name="iOpCode"></param>
            public static string GetOpCodeDescription(int iOpCode)
            {
                InitGameOpCodeName();

                if (s_opCodeName.Count > 0)
                {
                    string ret;
                    if (s_opCodeName.TryGetValue(iOpCode, out ret))
                        return ret;
                }

                return GetOpCodeName(iOpCode);
            }

            private static bool isInit;

            /// <summary>
            /// 
            /// </summary>
            static void InitGameOpCodeName()
            {
                if (isInit)
                    return;
                isInit = true;

                XmlDocument xmlDoc = null;

                string xmlFile = typeof(T).Assembly.FullName.Substring(0, typeof(T).Assembly.FullName.IndexOf(',')) + ".xml";
                if (File.Exists(xmlFile))
                {
                    try
                    {
                        xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(File.ReadAllText(xmlFile));
                        if (xmlDoc.DocumentElement == null)
                            xmlDoc = null;
                    }
                    catch (Exception ex)
                    {
                        Logs.Error("Load OpCode file fail.", ex);
                        xmlDoc = null;
                    }

                }
                
                foreach(var ev in Enum.GetValues(typeof (T)))
                {
                    var name = Enum.GetName(typeof (T), ev);
                    if (xmlDoc != null)
                    {
                        var key = string.Format("//member[@name='F:{0}.{1}']/summary", typeof(T).FullName, name);
                        var node = xmlDoc.DocumentElement.SelectSingleNode(key);
                        if (node != null)
                            name = node.InnerText.Trim();
                    }
                    s_opCodeName[(int) ev] = name;
                }

            }


        }   // class WorldOpCodeName


}
