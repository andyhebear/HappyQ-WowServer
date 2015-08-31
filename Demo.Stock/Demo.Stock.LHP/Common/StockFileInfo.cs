using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.LHP.Common
{
    public class StockFileInfo
    {
        // 股票全称
        private string m_StockName = string.Empty;
        public string StockName
        {
            get { return m_StockName; }
            set { m_StockName = value; }
       }

        // 股票符号
        private string m_StockSymbol = string.Empty;
        public string StockSymbol
        {
            get { return m_StockSymbol; }
            set { m_StockSymbol = value; }
        }

        // 文件路径
        private string m_FilePath = string.Empty;
        public string StockFilePath
        {
            get { return m_FilePath; }
            set { m_FilePath = value; }
        }
    }
}
