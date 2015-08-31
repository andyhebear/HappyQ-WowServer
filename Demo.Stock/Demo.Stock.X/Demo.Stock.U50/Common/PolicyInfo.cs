using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Stock.X.U50.Common
{
    public class U50PolicyInfo
    {
        public string Guid = string.Empty;
        public string Name = string.Empty;

        public U50Policy Policy = new U50Policy();
        public U50Filtrate Filtrate = new U50Filtrate();
        public U50Extend Extend = new U50Extend();
    }

    public enum U50PriorityType
    {
        None = 0,
        BaseDate = 1,
        BaseKN = 2,
    }

    public enum U50OutputType
    {
        None = 0,
        All = 1,
        One = 2,
    }

    public class U50Policy
    {
        public bool IsDateNow = true;
        public DateTime DateSelect = DateTime.Now;
        public uint KN = 3;

        public U50PriorityType Priority = U50PriorityType.None;
        public U50OutputType Output = U50OutputType.None;

        public bool IsAllowDate = false;
        public uint DateStep = 0;
        public DateTime DateEnd = DateTime.MinValue;

        public bool IsAllowKN = false;
        public uint KNStep = 0;
        public uint KNEnd = 50;
    }

    public enum U50SelectType
    {
        Any = -1,
        Big = 0,
        Small = 1,
        BigAndSmall = 2,
    }

    public class FiltrateInfo
    {
        public bool Enabled = false;
        public U50SelectType Select = U50SelectType.BigAndSmall;
        public float Small = 0.1F;
        public float Small2 = 0.1F;
        public float Big = 100.0F;
        public float Big2 = 100.0F;
    }

    public class U50Filtrate
    {
        public FiltrateInfo PDU = new FiltrateInfo();
        public FiltrateInfo PCU = new FiltrateInfo();
        public FiltrateInfo TDU = new FiltrateInfo();
        public FiltrateInfo TCD = new FiltrateInfo();
        public FiltrateInfo TBU = new FiltrateInfo();
        public FiltrateInfo VacUC = new FiltrateInfo();
    }

    public enum U50ExtendInfo01Type
    {
        Any = -1,
        High = 0,
        HighNumber = 1,
    }

    public class U50ExtendInfo01
    {
        public bool Enabled = false;
        public U50ExtendInfo01Type Select = U50ExtendInfo01Type.HighNumber;
        public int HighNumber = 10;
    }

    public class U50ExtendInfo02
    {
        public bool Enabled = false;
        public U50SelectType Select = U50SelectType.BigAndSmall;
        public long Small = 1;
        public long Small2 = 1;
        public long Big = 1000000000;
        public long Big2 = 1000000000;
    }

    public class U50ExtendInfo03
    {
        public bool Enabled = false;
        public U50SelectType Select = U50SelectType.BigAndSmall;
        public int Small = 1;
        public int Small2 = 1;
        public int Big = 1000;
        public int Big2 = 1000;
    }

    public enum U50ExtendInfo04Type
    {
        Any = -1,
        Yes = 0,
        No = 1,
    }

    public class U50ExtendInfo04
    {
        public bool Enabled = false;
        public U50ExtendInfo04Type Select = U50ExtendInfo04Type.Any;
    }

    public class U50ExtendInfo05
    {
        public bool Enabled = false;
        public U50SelectType Select = U50SelectType.BigAndSmall;
        public int Small = 1;
        public int Small2 = 1;
        public int Big = 10000;
        public int Big2 = 10000;
    }

    public class U50Extend
    {
        //public object Option = new object();
        public U50ExtendInfo01 Info01 = new U50ExtendInfo01();
        public U50ExtendInfo02 Info02 = new U50ExtendInfo02();
        public U50ExtendInfo03 Info03 = new U50ExtendInfo03();
        public U50ExtendInfo04 Info04 = new U50ExtendInfo04();
        public U50ExtendInfo05 Info05 = new U50ExtendInfo05();
    }
}
